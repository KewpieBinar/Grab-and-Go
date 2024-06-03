using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;
    private int _currentMoney;

    public void DisplayMoney(int money)
    {
        _currentMoney = money;
        moneyText.text = money.ToString();
    }
}
