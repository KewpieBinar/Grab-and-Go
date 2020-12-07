using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestManager : MonoBehaviour
{
    private PlayerQuestManager _questManager;
    public Player player;

    public bool NoActiveQuest; // atur lagi
    public Quest activeQuest;
    public QuestSelector questSelector;

    public bool pickUp = false;
    public bool dropOff = false;

    private void Awake()
    {
        _questManager = this.GetComponent<PlayerQuestManager>();
    }
    public void SetQuest(Quest qt) // SET ACTIVE QUEST WAJIB PAKE INI
    {
        activeQuest = qt;
        dropOff = false;
        pickUp = false;
        NoActiveQuest = false;
    }

    public void CheckQuestNode(Node currentNode)
    {

        if (currentNode == activeQuest.pickupNode)
        {
            pickUp = true;
            //trigger anim if avaialable
        }

        if (currentNode == activeQuest.destinationNode && pickUp)
        {

            dropOff = true;
            player.AddMoney(activeQuest.reward);

            activeQuest = null;// hanya null isi variable dari class (class != null / activeQuest != null )

            NoActiveQuest = true; // mark klo ga ada quest

            questSelector.OpenQuestSelector(_questManager);
            // triger anim if avaialble

        }


    }

}