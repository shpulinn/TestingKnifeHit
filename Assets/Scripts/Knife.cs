using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game {
    public class Knife : MonoBehaviour {

        public Rigidbody2D _rb; // knife rigitbody
        public bool inWood; // for knifes stucked in wood
        public GameObject appleLeft; 
        public GameObject appleRight;
        public ScriptableIntValue score;
        public GameObject resultScreen;
        public AudioSource appleHitSound;
        public AudioSource woodHitSound;
        public AudioSource knifeHitSound;
        private Animator animator;

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Apple")) {
                AppleDestroy(collision);
                appleHitSound.Play();
            }
            else

            if (collision.gameObject.CompareTag("Wood")) {
                _rb.velocity = Vector2.zero;
                _rb.transform.parent = collision.transform; // now knife stucked in wood spins with the wood
                inWood = true; // if another object collide with one with inWood true > game over
                animator.SetBool("inWood", true);
                score.value++;
                woodHitSound.Play();

            } else

            if (collision.gameObject.GetComponent<Knife>().inWood) {
                Instantiate(resultScreen);
                KnifeThrow.Instance._resultScreenEnabled = true;
                KnifeThrow.Instance._knifes.Clear();
                knifeHitSound.Play();
            }
        }

        private void AppleDestroy(Collider2D col) {
            StartCoroutine(AppleDestroyCoroutine(col));
            score.value += 4; // +1 point for wood hit
        }

        private IEnumerator AppleDestroyCoroutine(Collider2D col) {
            Destroy(col.gameObject); // destroys apple
            var aL = Instantiate(appleLeft, transform); // left half of Apple
            var aR = Instantiate(appleRight, transform); // right half of Apple
            aL.transform.parent = null; //remove parent for right gravity
            aR.transform.parent = null;
            aL.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse); // apple halfs floating in separate directions
            aR.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
            float randSpeed = Random.Range(2f, 6f); // random speed of spin
            for (float i = 0; i < 60; i += randSpeed) { //rotates apple halfs while falling
                aL.transform.Rotate(0, 0, i);
                aR.transform.Rotate(0, 0, i);
                yield return new WaitForSeconds(0.1f);
            }
            Destroy(aR);
            Destroy(aL);
        }
    }
}
