using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public Node pickupNode;
    public Node destinationNode;
    public float reward = -1;
    
    public Quest (Node pickupNode, Node destinationNode, float reward)
    {
        this.pickupNode = pickupNode;
        this.destinationNode = destinationNode;
        this.reward = reward;
    }

    public bool isNull ()
    {
        if (pickupNode == null || destinationNode == null || reward < 0)
            return true;
        else 
            return false;
    }
}
