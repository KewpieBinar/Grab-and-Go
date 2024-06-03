using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardPool : MonoBehaviour
{
    public static CardPool pooler;

    //[SerializeField] public List<ScriptableCard> scriptables;
    [SerializeField] private List<Card> _cardPool;
    [SerializeField] private CardDataCache cardDataCache;

    private void Awake()
    {
        pooler = this;  
    }

    private void Start()
    {
        if(cardDataCache == null)
        {
            Debug.LogError("no Card Data",this);
        }

        CreatePool(cardDataCache.CardDataSize);
         
    }


    public void CreatePool(int cardTypes)
    {
        ScriptableCardData scriptable = cardDataCache.CardData;

        for (int i = 0; i <cardTypes;i++)
        {
            Card card = CreateCard(i,scriptable);
            _cardPool.Add(card);
        }
    }

    private Card CreateCard(int index, ScriptableCardData scriptable)
    {
        return new Card(
            scriptable.EffectNames[index],
            scriptable.EffectTags[index],
            scriptable.EffectSprites[index],
            scriptable.EffectOnPlayer[index],
            scriptable.EffectDurations[index],
            scriptable.EffectModifiers[index]
            );
    }

    public Card GetRandomCard ()
    {
        var rand = UnityEngine.Random.Range(0, _cardPool.Count);
        return _cardPool[rand]; 
    }
    
}
