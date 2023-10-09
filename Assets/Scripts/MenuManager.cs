using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menumanager : MonoBehaviour
{
    public void PlayGame()
    { 
        Invoke("PlayGameDelay", 0.15f);
    }
    void PlayGameDelay()
    {
        Application.LoadLevel("Game");
    }

    public void ExitGame()
    {
        Invoke("ExitGameDelay", 0.15f);
    }
    void ExitGameDelay()
    {
        Application.Quit();
    }

    public void SkinChange()
    {
        Invoke("SkinChangeDelay", 0.15f);
    }
    void SkinChangeDelay()
    {
        Application.LoadLevel("Waredrobe");
    }
    
    public void BackToMenu()
    {
        Invoke("BackToMenuDelay", 0.15f);
    }
    void BackToMenuDelay()
    {
        Application.LoadLevel("Menu");
    }
}
