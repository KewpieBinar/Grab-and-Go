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
    public int playerID = -1;
    public double playerMoney = 0;

    //MovementState    
    public int steps = 0;

    public int carFuel;

    //playerEffectManager
    public PlayerEffectManager playerEffectManager;

    private void Update()
    {
        ///DEBUGING ONLY     
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("MONEY :" +playerMoney);
        }
    }


    public void AddMoney(double modifier)
    {
        playerMoney += modifier;
    }
    
}
