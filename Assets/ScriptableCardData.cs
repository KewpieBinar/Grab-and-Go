using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Data/ScriptableCardData")]
public class ScriptableCardData : ScriptableObject
{
    public int CardDataSize;

    [SerializeField]
    private List<string> _effectName;
    [SerializeField]
    private List<string> _effectTag;
    [SerializeField]
    private List<bool> _effectOnPlayer;
    [SerializeField]
    private List<int> _effectDuration;
    [SerializeField]
    private List<int> _effectModifier;
    [SerializeField]
    private List<Sprite> _effectSprite;

    public List<string> EffectNames { get { return _effectName; } }
    public List<Sprite> EffectSprites { get { return _effectSprite; } }
    public List<string> EffectTags { get { return _effectTag; } }
    public List<bool> EffectOnPlayer { get { return _effectOnPlayer; } }
    public List<int> EffectDurations { get { return _effectDuration; } }
    public List<int> EffectModifiers { get { return _effectModifier; } }

    public string CheckIsi (int i)
    {
        return EffectNames[i];
    }

}
