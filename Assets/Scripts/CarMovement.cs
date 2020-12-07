using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { stop, move, getNode, checkStep, checkSpecialNode,drawCard,checkEffect,effectOnNode,specialNode, quest, nodeCheck }
public class CarMovement : MonoBehaviour
{

    public PlayerNodeManager nodeManager;
    public PlayerMovement playerMove;
    public PlayerQuestManager questManager;
    public PlayerEffectManager effectManager;
    //player
    public Player player;

    //PlayerState
    
    public PlayerState pState = PlayerState.stop;


    //CheckQUEST

    private void Update()
    {

        if (pState == PlayerState.stop)
        {
            //PlayerController For the Momnet
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pState = PlayerState.getNode;
                player.steps = 10;
            }
        }

        if (pState == PlayerState.getNode)
        {
            if (nodeManager.destinationTransform != null)
            {
                pState = PlayerState.move;
                return;
            }

            nodeManager.GetNextDestination();
        }

        if (pState == PlayerState.move)
        {
            var move = playerMove.OnMove();
            if (move) return;
            pState = PlayerState.nodeCheck;

        }


        if (pState == PlayerState.nodeCheck)
        {
            var currentnode = nodeManager.currentNode;
            questManager.CheckQuestNode(currentnode);
            effectManager.CheckSpecialNode(currentnode);
            pState = PlayerState.quest;
        }


        if (pState == PlayerState.quest)
        {
            if (questManager.NoActiveQuest) return;
            else pState = PlayerState.checkEffect;
        }

        if (pState == PlayerState.checkEffect)
        {
            if (effectManager.specialNode)
            {
                pState = PlayerState.specialNode;
            }
            else if (effectManager.effectOnNode)
            {
                pState = PlayerState.effectOnNode;
            }
            else pState = PlayerState.checkStep;

        }

        EffectState();


        if (pState == PlayerState.checkStep)
        {
            if (player.steps > 0) pState = PlayerState.getNode;
            else pState = PlayerState.stop;
        }

    }



    private void EffectState()
    {
        if(pState == PlayerState.specialNode)
        {
            effectManager.ActivateDrawCardEffect(player);
            pState = PlayerState.checkStep;
        }

        if(pState == PlayerState.effectOnNode)
        {
            pState = PlayerState.checkStep;
        }
    }
}

