using UnityEngine;

namespace Game {
    public class WoodSpin : MonoBehaviour {

        public static WoodSpin Instance;

        public GameObject _woodPrefab;
        public float _rotationSpeed;
        [SerializeField]
        private float _maxSpeed = 10f;

        private void Awake() {
            Instance = this; // singleton used for increasing speed of wood rotating after hitting the wood
        }

        private void FixedUpdate() {
            _woodPrefab.transform.Rotate(0, 0, _rotationSpeed);
            if (_rotationSpeed < _maxSpeed) {
                _rotationSpeed += _rotationSpeed * Time.deltaTime * 0.1f;
            }
        }
    }
}
