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
        public GameObject bestScoreLabel;
        private bool bestScoreActive = false;

        private void Start() {
            scoreLabel.text = score.value.ToString(); // shows value of points received on result screen
        }


        private void Awake() {
            restartButton.onClick.AddListener(OnRestartButtonClick);
            menuButton.onClick.AddListener(OnMenuButtonClick);
            bestScoreLabel.SetActive(false);
            if (!bestScoreActive && score.value > PlayerPrefs.GetInt("ScoreInt")) {
                PlayerPrefs.SetInt("ScoreInt", score.value);
                PlayerPrefs.Save();
                bestScoreLabel.SetActive(true);
                bestScoreActive = true;
            }
        }

        public void OnRestartButtonClick() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload game scene
            Destroy(gameObject); //destroys resultscreen
            score.value = 0;
        }

        public void OnMenuButtonClick() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // load menu scene
            Destroy(gameObject);
            score.value = 0;
        } 
    }
}
