using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState 
{ 
    stop, 
    rollDice, 
    move, 
    getNode, 
    checkStep, 
    checkSpecialNode, 
    drawCard, 
    checkEffect, 
    effectOnNode, 
    placeEffect, 
    specialNode, 
    quest, 
    nodeCheck 
}

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState pState;
    private Player player;
    private PlayerMovement playerMove;

    private void Update()
    {
        if (pState == PlayerState.stop)
        {



        }

        if (pState == PlayerState.rollDice)
        {
            if (player.steps <= 0)
            {
                playerMove.RollDice();
                return;
            }

            pState = PlayerState.getNode;
        }

        if (pState == PlayerState.getNode)
        {
            if (player.playerNodeManager.destinationTransform != null)
            {
                pState = PlayerState.move;
                return;
            }

            player.playerNodeManager.GetNextDestination();
        }

        if (pState == PlayerState.move)
        {
            var move = playerMove.OnMove();
            if (move) return;
            pState = PlayerState.nodeCheck;

        }


        if (pState == PlayerState.nodeCheck)
        {
            var currentnode = player.playerNodeManager.currentNode;
            player.playerQuestManager.CheckQuestNode(currentnode);
            player.playerEffectManager.CheckSpecialNode(currentnode);
            pState = PlayerState.quest;
        }

        if (pState == PlayerState.quest)
        {
            if (player.playerQuestManager.NoActiveQuest) return;
            else pState = PlayerState.drawCard;
        }

        if (pState == PlayerState.drawCard)
        {
            if (!player.playerEffectManager.specialNode)
            {
                pState = PlayerState.checkEffect;
                return;
            }
        }



        if (pState == PlayerState.checkEffect)
        {
            if (player.playerEffectManager.ActivateDrawnCard)
            {
                pState = PlayerState.specialNode;
            }
            else if (player.playerEffectManager.effectOnNode)
            {
                pState = PlayerState.effectOnNode;
            }
            else if (player.playerEffectManager.placeEffectOnNode)
            {
                pState = PlayerState.placeEffect;
            }
            else pState = PlayerState.checkStep;

        }

        if (pState == PlayerState.specialNode)
        {
            player.playerEffectManager.ActivateDrawnCardEffect(player);
            pState = PlayerState.checkStep;
        }

        if (pState == PlayerState.effectOnNode)
        {
            player.playerEffectManager.ActivateEffectOnNode(player);
            pState = PlayerState.checkStep;
        }

        if (pState == PlayerState.placeEffect)
        {
            if (player.playerEffectManager.placeEffectOnNode) return;
            pState = PlayerState.checkStep;
        }


        if (pState == PlayerState.checkStep)
        {
            if (player.steps > 0) pState = PlayerState.getNode;
            else
            {
                pState = PlayerState.stop;
                player.EndTurn();
            }

        }
    }
}
