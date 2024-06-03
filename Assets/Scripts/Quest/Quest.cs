using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public Node pickupNode;
    public Node destinationNode;
    public int reward = -1;

    

    public Sprite pickupSprite;
    public Sprite dropOffSprite;
    public Sprite dropOffNameSprite;
    public Sprite pickupNameSprite;
    
    public Quest (Node pickupNode, Node destinationNode, int reward)
    {
        this.pickupNode = pickupNode;
        this.destinationNode = destinationNode;
        this.reward = reward;
    }

    public Quest(Node pickupNode, Node destinationNode, int reward, Sprite pickupSprite, Sprite dropOffSprite, Sprite pickupNameSprite, Sprite dropOffNameSprite)
    {
        this.pickupNode = pickupNode;
        this.destinationNode = destinationNode;
        this.reward = reward;
        this.pickupSprite = pickupSprite;
        this.dropOffSprite = dropOffSprite;
        this.pickupNameSprite = pickupNameSprite;
        this.dropOffNameSprite = dropOffNameSprite;

    }

    public bool isNull ()
    {
        if (pickupNode == null || destinationNode == null || reward < 0)
            return true;
        else 
            return false;
    }
}
