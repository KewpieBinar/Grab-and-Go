using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "newQuest", menuName = "Scriptable/NewCard")]
public class ScriptableQuest : ScriptableObject
{
    public Node pickupNode;
    public Node destinationNode;
    public float reward;
    public Quest GetQuest()
    {
        return new Quest(pickupNode, destinationNode, reward);
    }
}