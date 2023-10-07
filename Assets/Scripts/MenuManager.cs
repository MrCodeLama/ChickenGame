using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menumanager : MonoBehaviour
{
    public GameObject settingsPanel;
     
    public void PlayGame()
    { 
        Application.LoadLevel("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void Exit()
    {
        settingsPanel.SetActive(false);
    }

    public void ScinChange()
    {
        Application.LoadLevel("Waredrobe");
    }
    public void BackToMenu()
    { 
        Application.LoadLevel("Menu");
    }
    public void Shop()
    { 
        Application.LoadLevel("Shop");
    }
}
