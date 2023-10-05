using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public Text pointText;
    public void Setup(int Score)
    {
        gameObject.SetActive(true);
        pointText.text = Score.ToString() + " points";
        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
