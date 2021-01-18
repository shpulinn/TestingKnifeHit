using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class KnifeThrow : MonoBehaviour {

        public static KnifeThrow Instance;

        public GameObject _knifePrefab; 
        public List<GameObject> _knifeIconPrefabs;
        private GameObject _knife;
        public List<GameObject> _knifes = new List<GameObject>(); // list of knifes stash that player can use
        public Text scoreLabel;
        public ScriptableIntValue score;
        public GameObject resultScreen;
        public AudioSource throwSound;
        public GameObject gameScreen;

        public float _force;
        public bool _resultScreenEnabled = false;

        private void Awake() {
            Instance = this; // singleton used for clearing list of knifes stash that player can use (_knifes)
        }

        private void Start() {
            score.value = 0;
            _knife = Instantiate(_knifePrefab, transform);
            foreach (var prefab in _knifeIconPrefabs) { // fills list of knifes stash that player can use with amount of knife icons
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
                _knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force, ForceMode2D.Impulse); // push knife
                throwSound.Play();
                _knife = Instantiate(_knifePrefab, transform); // spawn new knife 
                _knifes.RemoveAt(_knifes.Count - 1); // remove knife from list of knifes stash that player can use
                Destroy(_knifeIconPrefabs[_knifeIconPrefabs.Count - 1]); // destroy icon for showing right amount of knifes left
                _knifeIconPrefabs.RemoveAt(_knifeIconPrefabs.Count - 1);
                WoodSpin.Instance._rotationSpeed += 0.3f; // increase wood spin speed after hitting wood
                }
        }

        // Wait and show ResultScreen coroutine waits 2 sec after last knife pushed and shows the ResultScreen
        private IEnumerator WaitAndShowRSCoroutine() {
            yield return new WaitForSeconds(2);
            Instantiate(resultScreen);
            resultScreen.SetActive(true);
            _resultScreenEnabled = true;
        }
    }
}
