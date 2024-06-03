using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxUI : MonoBehaviour
{
    [SerializeField]
    private Text _CO_Pickup;
    [SerializeField]
    private Text _CO_Destination;

    [SerializeField]
    private Text _playerMoney;
    [SerializeField]
    private Text _playerFuel;

    [SerializeField]
    private Text _playerText;

    public void DisplayInfo(PlayerInfoBox infoBox)
    {
        _playerText.text = infoBox.playerText;
        _CO_Destination.text = infoBox.co_destination;
        _CO_Pickup.text = infoBox.co_pickup;
        _playerFuel.text = infoBox.player_fuel.ToString();
        _playerMoney.text = infoBox.player_money.ToString();
    }
}

