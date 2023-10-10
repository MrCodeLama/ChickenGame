using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menumanager : MonoBehaviour
{
    public float delay = 0.2f;
    public void PlayGame()
    { 
        Invoke("PlayGameDelay", delay);
    }
    void PlayGameDelay()
    {
        Application.LoadLevel("Game");
    }

    public void ExitGame()
    {
        Invoke("ExitGameDelay", delay);
    }
    void ExitGameDelay()
    {
        Application.Quit();
    }

    public void SkinChange()
    {
        Invoke("SkinChangeDelay", delay);
    }
    void SkinChangeDelay()
    {
        Application.LoadLevel("Waredrobe");
    }
    
    public void BackToMenu()
    {
        Invoke("BackToMenuDelay", delay);
    }
    void BackToMenuDelay()
    {
        Application.LoadLevel("Menu");
    }
}
