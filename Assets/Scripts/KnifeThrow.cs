using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game {
    public class KnifeThrow : MonoBehaviour {

        public static KnifeThrow Instance;

        public GameObject _knifePrefab;
        public List<GameObject> _knifeIconPrefabs;
        private GameObject _knife;
        public List<GameObject> _knifes = new List<GameObject>();
        public Text scoreLabel;
        public ScriptableIntValue score;
        public GameObject resultScreen;
        public AudioSource throwSound;
        public GameObject gameScreen;

        public float _force;
        public bool _resultScreenEnabled = false;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            score.value = 0;
            _knife = Instantiate(_knifePrefab, transform);
            foreach (var prefab in _knifeIconPrefabs) {
                _knifes.Add(prefab);
            }
        }

        private void Update() {
            scoreLabel.text = score.value.ToString();

            if (_knifes.Count == 0) {
                if (!_resultScreenEnabled) {
                    StartCoroutine(WaitAndShowRSCoroutine());
                }

            } else if (Input.GetMouseButtonDown(0)) {
                _knife.transform.parent = null;
                _knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                throwSound.Play();
                _knife = Instantiate(_knifePrefab, transform);
                _knifes.RemoveAt(_knifes.Count - 1);
                Destroy(_knifeIconPrefabs[_knifeIconPrefabs.Count - 1]);
                _knifeIconPrefabs.RemoveAt(_knifeIconPrefabs.Count - 1);
                WoodSpin.Instance._rotationSpeed += 0.3f;
                }
        }

        // корутина для показа экрана результата после 2-х секунд после броска последнего ножа
        private IEnumerator WaitAndShowRSCoroutine() {
            yield return new WaitForSeconds(2);
            Instantiate(resultScreen);
            resultScreen.SetActive(true);
            _resultScreenEnabled = true;
        }
    }
}
