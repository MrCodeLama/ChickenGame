using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScinControll : MonoBehaviour
{
    public int scinIndex = 0;
    public GameObject[] scins;
    

    void Start()
    {
        scinIndex = PlayerPrefs.GetInt("SelectedScin", 0);
        foreach(GameObject sck in scins)
            sck.SetActive(false);


        scins[scinIndex].SetActive(true);
    }
}
