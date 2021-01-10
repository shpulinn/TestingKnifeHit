using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {
    public class ResultScreen : MonoBehaviour {

        public ScriptableIntValue score;
        public Text scoreLabel;
        public Button restartButton;
        public Button menuButton;
        public GameObject gameScreen;

        private void Start() {
            scoreLabel.text = score.value.ToString();
            //gameScreen = GameObject.Find("GameScreen");
            //gameScreen.SetActive(false);
        }


        private void Awake() {
            restartButton.onClick.AddListener(OnRestartButtonClick);
            menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        public void OnRestartButtonClick() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
            score.value = 0;
        }

        public void OnMenuButtonClick() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Destroy(gameObject);
            score.value = 0;
        } 
    }
}
