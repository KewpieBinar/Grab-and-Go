using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Data/ScriptableQuestData")]
public class ScriptableQuestData : ScriptableObject
{
    //UnUsable
    public int locationSize;
    public List<Sprite> locationSprite;
    public List<Node> locationNode;
    public List<string> locationName;
}
