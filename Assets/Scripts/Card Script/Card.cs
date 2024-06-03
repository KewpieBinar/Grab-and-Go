using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    [SerializeField]
    private string _effectName;
    public string EffectName => _effectName;
    [SerializeField]
    private string _effectTag ;
    public string EffectTag => _effectTag;
    [SerializeField]
    public bool EffectOnPlayer;
    [SerializeField]
    private int _effectDuration;
    public int EffectDuration => _effectDuration;
    [SerializeField]
    private int _modifier;
    public int Modifier => _modifier;

    private Sprite _effectSprite;
    public Sprite EffectSprite => _effectSprite;

    public ScriptableCard CardData;

    public Card(string effectName, string effectTag, Sprite effectSprite,bool effectOnPlayer,int effectDuration, int modifier)
    {
        _effectName = effectName;
        _effectTag = effectTag;
        _effectSprite = effectSprite;
        EffectOnPlayer = effectOnPlayer;
        _effectDuration = effectDuration;
        _modifier = modifier;
        
    }
}
