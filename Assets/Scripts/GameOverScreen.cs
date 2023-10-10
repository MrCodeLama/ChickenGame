using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public GameObject backButton;
    public GameObject isNewHighScoreTextField;
    public Text pointText;
    public bool _isNewHighScore;
    public void Setup(int Score)
    {
        _isNewHighScore = Camera.main.GetComponent<ScoreManager>()._isNewHighScore;
        gameObject.SetActive(true);
        backButton.GetComponent<Button>().enabled = false;
        pointText.text = Score.ToString() + " points";
        isNewHighScoreTextField.SetActive(_isNewHighScore);
    }
}
