using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public void AddMoney()
    {
        SaveManager.instance.money += 1;
        SaveManager.instance.Save();
    }
}
