using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menumanager : MonoBehaviour
{
    public GameObject settingsPanel;
     
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
    
    public void SettingsPanel()
    {
        Invoke("SettingsPanelDelay", 0.15f);
    }
    void SettingsPanelDelay()
    {
        settingsPanel.SetActive(true);
    }

    public void Exit()
    {
        Invoke("ExitDelay", 0.15f);
    }
    void ExitDelay()
    {
        settingsPanel.SetActive(false);
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
    
    public void Shop()
    { 
        Invoke("ShopDelay", 0.15f);
    }
    void ShopDelay()
    {
        Application.LoadLevel("Shop");
    }
}
