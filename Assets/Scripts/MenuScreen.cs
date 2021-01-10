using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game {
    public class MenuScreen : MonoBehaviour {

        public Button playButton;
        public AudioSource menuMusic;
        
        private void Awake() {
            menuMusic.Play();
        }

        public void PlayButton() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            menuMusic.Stop();
        }
    }
}
