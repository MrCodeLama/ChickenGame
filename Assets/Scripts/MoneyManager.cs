using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public void AddMoney(bool _isLegendary)
    {
        SaveManager.instance.money += (_isLegendary) ? 10 : 1;
        SaveManager.instance.Save();
    }
}
