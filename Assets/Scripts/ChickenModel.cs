using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenModel : MonoBehaviour
{
    [SerializeField] private GameObject[] chickenModels;

    private SaveManager saveManager;
   
    private void Awake()
    {
        saveManager = SaveManager.instance; 
        ChooseChickenModel(saveManager.currentChicken);
    }

    private void ChooseChickenModel(int _index)
    {
        if (_index >= 0 && _index < chickenModels.Length)
        {
            if (saveManager.chickenUnlocked[_index])
            {
                Instantiate(chickenModels[_index], transform.position, Quaternion.identity, transform);
            }
            else
            {
                for (int i = 0; i < saveManager.chickenUnlocked.Length; i++)
                {
                    if (saveManager.chickenUnlocked[i])
                    {
                        Instantiate(chickenModels[i], transform.position, Quaternion.identity, transform);
                        return;
                    }
                }
            }
        }
        else
        {
        }
    }
}