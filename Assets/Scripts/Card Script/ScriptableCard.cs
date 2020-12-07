using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="newCard", menuName ="Scriptable/NewCard")]
public class ScriptableCard : ScriptableObject
{
    public string EffectName;

    public string EffectTag;

    public Sprite cardImage;

    public bool effectOnPlayer;
    public int modifier;

    public int effectDuration;
}
