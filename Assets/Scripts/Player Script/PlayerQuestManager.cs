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
        player = this.GetComponent<Player>();
        activeQuest = null;
        NoActiveQuest = true;
    }

    private void Start()
    {
        questSelector = GameMechanicReference.Instance.GetQuestSelector;
    }

    public void SetQuest(Quest qt) // SET ACTIVE QUEST WAJIB PAKE INI
    {
        var pickupName = qt.pickupNode.transform.name;
        var destinationName = qt.destinationNode.transform.name;
        var tex = string.Format("Accept order from {0} to {1}",pickupName , destinationName);
        player.PlayerNotif.CurrentOrderNotifInfo(tex, pickupName, destinationName);
        player.Notification(tex);

        activeQuest = qt;
        dropOff = false;
        pickUp = false;
        NoActiveQuest = false;
    }

    public void CheckQuestNode(Node currentNode)
    {
        if (activeQuest == null)
        {
            questSelector.OpenQuestSelector(_questManager);
            return;
        }

        if (currentNode == activeQuest.pickupNode)
        {
            pickUp = true;
            //trigger anim if avaialable
        }

        if (currentNode == activeQuest.destinationNode && pickUp)
        {

            dropOff = true;
            player.AddMoney((int)activeQuest.reward);

            activeQuest = null;// hanya null isi variable dari class (class != null / activeQuest != null )

            NoActiveQuest = true; // mark klo ga ada quest

            questSelector.OpenQuestSelector(_questManager);
            // triger anim if avaialble

        }


    }

}