using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviourPun
{

    public PlayerNodeManager nodeManager;
    public PlayerMovement playerMove;
    public PlayerQuestManager questManager;
    public PlayerEffectManager effectManager;
    //player
    public Player player;

    //PlayerState
    public PlayerState pState = PlayerState.stop;

    private void Awake()
    {
        player = this.GetComponent<Player>();
        nodeManager = this.GetComponent<PlayerNodeManager>();
        playerMove = this.GetComponent<PlayerMovement>();
        questManager = this.GetComponent<PlayerQuestManager>();
        effectManager = this.GetComponent<PlayerEffectManager>();
    }

    private void Start()
    {
        pState = PlayerState.stop;
        
    }

    //CheckQUEST
    private void Update()
    {
        if (!photonView.IsMine) return;


        if (pState == PlayerState.stop)
        {

            
            
        }

        if(pState == PlayerState.rollDice)
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
            else pState = PlayerState.drawCard;
        }

        if (pState == PlayerState.drawCard)
        {         
            if(!effectManager.specialNode)
            {
                pState = PlayerState.checkEffect;
                return;
            }              
        }

        

        if (pState == PlayerState.checkEffect)
        {
            if (effectManager.ActivateDrawnCard)
            {
                pState = PlayerState.specialNode;
            }
            else if (effectManager.effectOnNode)
            {
                pState = PlayerState.effectOnNode;
            }
            else if(effectManager.placeEffectOnNode)
            {
                pState = PlayerState.placeEffect;
            }
            else pState = PlayerState.checkStep;

        }

        if (pState == PlayerState.specialNode)
        {
            effectManager.ActivateDrawnCardEffect(player);
            pState = PlayerState.checkStep;
        }

        if (pState == PlayerState.effectOnNode)
        {
            effectManager.ActivateEffectOnNode(player);
            pState = PlayerState.checkStep;
        }

        if(pState == PlayerState.placeEffect)
        {
            if (effectManager.placeEffectOnNode) return;
            pState = PlayerState.checkStep;
        }


        if (pState == PlayerState.checkStep)
        {
            if (player.steps > 0) pState = PlayerState.getNode;
            else {    
                pState = PlayerState.stop;
                player.EndTurn();
            }
            
        }

    }

    public void StartTurn()
    {
        pState = PlayerState.rollDice;
    }

}

