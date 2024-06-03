using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetailsUI : MonoBehaviour
{

    [SerializeField]
    private Text rewardUI;
    [SerializeField]
    private Image imagePickup;
    [SerializeField]
    private Image imageDestination;
    [SerializeField]
    private Image imagePickupName;
    [SerializeField]
    private Image imageDestinationName;
    public void DisplayDetails(Quest quest)
    {
        rewardUI.text = quest.reward.ToString();
        imagePickup.sprite = quest.pickupSprite;
        imageDestination.sprite = quest.dropOffSprite;
        imageDestinationName.sprite = quest.dropOffNameSprite;
        imagePickupName.sprite = quest.pickupNameSprite;
    }
}
