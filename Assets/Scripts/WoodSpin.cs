using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class WoodSpin : MonoBehaviour {

        public static WoodSpin Instance;

        public GameObject _woodPrefab;
        public float _rotationSpeed;
        private const float _maxSpeed = 10f;

        private void Awake() {
            Instance = this;
        }

        private void FixedUpdate() {
            _woodPrefab.transform.Rotate(0, 0, _rotationSpeed);
            if (_rotationSpeed < _maxSpeed) {
                _rotationSpeed += _rotationSpeed * Time.deltaTime * 0.1f;
            }
        }

        //private void Awake() {
        //    StartCoroutine(WoodRotation());
        //}

        //private IEnumerator WoodRotation() {
        //    _woodPrefab.transform.rotation = new Quaternion(1f * _rotationSpeed, 0, 0, 0);
        //    yield return new WaitForSeconds(1);
        //}
    }
}
