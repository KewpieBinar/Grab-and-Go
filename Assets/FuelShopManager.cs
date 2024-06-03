using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelShopManager : MonoBehaviour
{
    [SerializeField]
    private Text _fuelPriceText;

    private int _fuelPrice;

    [SerializeField]
    private Button _buyFuelBtn;

    private Player _player;  
    private void Start()
    {
        SetupShop(GameSettingsSingleton.Settings.gameSettings);
        //FuelPriceText.text
    }

    private void SetupShop(ScriptableGameSettings settings)
    {
        _player = GameMechanicReference.Instance.GetPlayer;
        _fuelPrice = settings.fuelBuyPrice;
        _fuelPriceText.text = _fuelPrice.ToString();
        _buyFuelBtn.onClick.AddListener(BuyFuel);
    }

    private void BuyFuel()
    {
        GetPlayerIfNull();
        if (_player.playerMoney < _fuelPrice) return;
        _player.DecreaseMoney(_fuelPrice);
        _player.playerFuelManager.AddFuel();
    }

    private void GetPlayerIfNull()
    {
        if (_player != null) return;
        _player = GameMechanicReference.Instance.GetPlayer;
    }
}
