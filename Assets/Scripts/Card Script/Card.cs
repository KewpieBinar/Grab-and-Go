using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string EffectName;

    public string EffectTag;
    
    public bool effectOnPlayer;

    public int effectDuration;

    public int modifier;

    public ScriptableCard CardData;

    public Card(ScriptableCard cardData)
    {
        CardData = cardData;
        if (cardData == null) return;

        effectDuration = cardData.effectDuration;
        EffectTag = cardData.EffectTag;
        EffectName = cardData.EffectName;
        modifier = cardData.modifier;
        effectOnPlayer = cardData.effectOnPlayer;

    }

/*    public Card( effectName)
    {


        this.effectDuration = effectDuration;
        this.EffectTag = EffectTag;
        this.EffectName = EffectName;
        this.modifier = modifier;
        this.effectOnPlayer = effectOnPlayer;

    }*/
}
