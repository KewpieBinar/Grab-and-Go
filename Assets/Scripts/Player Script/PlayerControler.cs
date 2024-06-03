using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Player player;
    public CarMovement carMove;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var diceRoll = RollDice();
            MoveCar(diceRoll);
            
        }
    }

    private int RollDice()
    {
        return UnityEngine.Random.Range(0, 7);
    }

    private void MoveCar(int roll)
    {
        /*carMove.SetSetp();*/
    }

}
