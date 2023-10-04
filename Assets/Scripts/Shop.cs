using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public int scinIndex = 0;
    public GameObject[] scin;
    public ScinBlueprint[] scins;
    public Button buyButton;
    private CoinText Coin;


    void Start()
    {   
        foreach(ScinBlueprint sck in scins)
        {
            if(sck.price == 0)
                sck.isUnlocked = true;
            else
                sck.isUnlocked = PlayerPrefs.GetInt(sck.name, 0)== 0 ? false: true;
        }
        scinIndex = PlayerPrefs.GetInt("SelectedScin", 0);
        foreach(GameObject sck in scin)
            sck.SetActive(false);


        scin[scinIndex].SetActive(true);
    }

    void Update()
    {
        UpdateUI();
        
    }

    public void ChangeNext()
    {
        scin[scinIndex].SetActive(false);

        scinIndex++;
        if(scinIndex == scin.Length)
            scinIndex = 0;

        scin[scinIndex].SetActive(true);
        ScinBlueprint c = scins[scinIndex];
        if(!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedScin", scinIndex);
    }

    public void ChangePrewious()
    {
        scin[scinIndex].SetActive(false);

        scinIndex--;
        if(scinIndex == -1)
            scinIndex = scin.Length -1;

        scin[scinIndex].SetActive(true);
        ScinBlueprint c = scins[scinIndex];
        if(!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedScin", scinIndex);
    }

    public void UnLockScin()
    {
        ScinBlueprint c = scins[scinIndex];

        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedScin", scinIndex);
        c.isUnlocked = true;
        CoinText.Coin -= c.price;
        PlayerPrefs.SetInt("Coins", CoinText.Coin);
        
        
        
    }

    private void UpdateUI()
    {
        ScinBlueprint c = scins[scinIndex];
        if(c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "" + c.price;
            if (PlayerPrefs.GetInt("Coins", 0) > c.price)
            {
                buyButton.interactable = true;
                
            }
            else
            {
                buyButton.interactable = false;
            }

            
        }
    }
}
