using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Class
/// Contains all variable that can be effected by a card effect
/// variable can be accessed by more than 2 class
/// Contain Basic Info & stats Of Player
/// Contains method that affect variable
/// </summary>

public class Player : MonoBehaviour
{
    public int playerID;
    public int playerMoney = 0;

    private PlayerNotificationManager _playerNotification;
    public PlayerNotificationManager PlayerNotif => _playerNotification;
    
    public PlayerNetworkController pNetwork;
    public CarMovement carMovement;

    public PlayerQuestManager playerQuestManager;
    public PlayerEffectManager playerEffectManager;
    public PlayerNodeManager playerNodeManager;
    public PlayerFuelManager playerFuelManager;

    [SerializeField]
    private MoneyUI moneyUI;

    //MovementState    
    public int steps = 0;

    public int playerFuelModifier = 0 ;
    public int playerMaxStepsModifier = 0;
    public int playerMinStepsModifier = 0;

    private void Awake()
    {
        playerNodeManager = this.GetComponent<PlayerNodeManager>();
        _playerNotification = this.GetComponent<PlayerNotificationManager>();
        pNetwork = this.GetComponent<PlayerNetworkController>();
        playerEffectManager = this.GetComponent<PlayerEffectManager>();
        carMovement = this.GetComponent<CarMovement>();
        playerFuelManager = this.GetComponent<PlayerFuelManager>();

        
    }

    public void StartTurn ()
    {
        moneyUI = GameMechanicReference.Instance.GetMoneyUI;
        carMovement.StartTurn();
    }

    public void EndTurn()
    {
       pNetwork.EndTurn();
    }

    public void AddMoney(int modifier)
    {
        //Notification(string.Format("Player {0} gains {1} coin", playerID + 1, modifier));
        playerMoney += modifier;
        moneyUI.DisplayMoney(playerMoney);
        _playerNotification.MoneyNotifInfo(string.Format("Player {0} gains {1} coin", playerID + 1, modifier),modifier);
    }

    public void DecreaseMoney(int modifier)
    {
        //Notification(string.Format("Player {0} gains {1} coin", playerID + 1, modifier));
        playerMoney -= modifier;
        int decreaseVal = -modifier; 
        moneyUI.DisplayMoney(playerMoney);
        _playerNotification.MoneyNotifInfo(string.Format("Player {0} pays {1} coin", playerID + 1, decreaseVal), decreaseVal);
    }

    public void Notification(string message)
    {
        _playerNotification.SendNotification(message);
    }

    public void SetStep(int modifier)
    {
        steps = modifier;
    }

    public void AddStep(int modifier)
    {
        var tex = string.Format("Player {0} TANCAP GAS {1} Steps",playerID+1,modifier);
        PlayerNotif.SendNotification(tex);
        steps += modifier;
    }
}
