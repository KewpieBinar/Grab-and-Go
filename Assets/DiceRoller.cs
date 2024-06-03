using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    /*[SerializeField]
    private GameObject _diceRollUI;
    [SerializeField]
    private GameObject _diceRollButtonUI;
    [SerializeField]
    private GameObject _acceptButtonUI;*/
    public bool IsRolling = false;

    [SerializeField]
    private Button _rollButton;
    [SerializeField]
    private Button _acceptButton;
    /*[SerializeField]
    private Text _rollResultText;*/

    

    [SerializeField]
    private int maxDiceRoll;
    private int _diceResult = 0;
    private int _numberDisplay = 0;

    private Player _playerToRoll;

    //new UI settings
    public TurnMeterUi turnMeterUI;
    public RollDisplayer display;

    private void Start()
    {
        if (GameSettingsSingleton.Settings == null) return;

        _acceptButton.onClick.AddListener(OnAccept);
        _rollButton.onClick.AddListener(OnRollDice);
        maxDiceRoll = GameSettingsSingleton.Settings.gameSettings.maxDiceRoll;
        
    }

    public void OpenDiceRoller(Player player)
    {
        _playerToRoll = player;

        IsRolling = true;
        turnMeterUI.MoveTurnMeter(true);
        /*_rollButton.transform.gameObject.SetActive(true);

        display.SetDisplay(0);*/

    }

    public void OnCenter()
    {
        _rollButton.transform.gameObject.SetActive(true);
        display.SetDisplay(0);
    }


    private void UpdateDisplay(int num)
    {
        display.UpdateDisplay(num, 0.04f);

    }

    private void OnRollDice()
    {
        
        int max = _playerToRoll.playerMaxStepsModifier + maxDiceRoll;
        int min = _playerToRoll.playerMinStepsModifier;
        _diceResult = UnityEngine.Random.Range(min, max);

        // filter the fuel or sumthin
        if (_playerToRoll.playerFuelManager.EmptyFuel)
            _diceResult = _diceResult / 2;

        UpdateDisplay(_diceResult);

        _rollButton.transform.gameObject.SetActive(false);
        _acceptButton.transform.gameObject.SetActive(true);

        
    }

    private void OnAccept()
    {
        CloseDiceRoller();
    }

    private void CloseDiceRoller()
    {
        

        /*_diceRollUI.SetActive(false);*/
        
        _acceptButton.transform.gameObject.SetActive(false);
        turnMeterUI.MoveTurnMeter(false);
        /*_playerToRoll.AddStep(_diceResult);
        *//*_acceptButton.onClick.RemoveAllListeners();*//*

        _playerToRoll = null;
        _diceResult = 0;
        IsRolling = false;*/
    }

    public void OnOriginal()
    {
        _playerToRoll.AddStep(_diceResult);
        /*_acceptButton.onClick.RemoveAllListeners();*/

        _playerToRoll = null;
        _diceResult = 0;
        IsRolling = false;
    }
}
