using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters;
    private int index;

    private void Start()
    {
        characters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        if (characters[0])
        {
            characters[0].SetActive(true);
        }
    }

    public void SelectLeft()
    {
        characters[index].SetActive(false);
        index--;
        if (index<0)
        {
            index = characters.Length - 1;
        }
        characters[index].SetActive(true);
    }
    
    public void SelectRight()
    {
        characters[index].SetActive(false);
        index++;
        if (index == characters.Length)
        {
            index = 0;
        }
        characters[index].SetActive(true);
    }
}
