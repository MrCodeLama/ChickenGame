using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenModel : MonoBehaviour
{
   [SerializeField] private GameObject[] chickenModels;

   private void Awake()
   {
      ChooseChickenModel(SaveManager.instance.currentChicken);
   }

   private void ChooseChickenModel(int _index)
   {
      Instantiate(chickenModels[_index], transform.position, Quaternion.identity, transform);
   }
}
