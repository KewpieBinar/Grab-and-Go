using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public ObjectPool<Quest, ScriptableQuest> questPool;
    public ObjectPool<Card, ScriptableCard> cardPool;

    public void GeneratePool()
    {
        foreach(ScriptableQuest scr in questPool.scriptablesType)
        {
            questPool._items.Add(new Quest(scr.pickupNode , scr.destinationNode, scr.reward));
        }

        foreach(ScriptableCard scr in cardPool.scriptablesType)
        {
            cardPool._items.Add(new Card(scr));
        }

    }

    public Quest GetRandomQuest()
    {
        var quest = questPool._items;
        var rand = UnityEngine.Random.Range(0, quest.Count);
        return quest[rand];
    }

    public Card GetRandomCard()
    {
        var card = cardPool._items;
        var rand = UnityEngine.Random.Range(0, card.Count);
        return card[rand];
    }
}

[System.Serializable]
public class ObjectPool<T1, T2> 
{
    public List<T1> _items;
    public List<T2> scriptablesType;
}

