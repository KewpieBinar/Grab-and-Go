using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataCache : MonoBehaviour
{
    public int locationSize;
    public List<Sprite> locationSprite;
    public List<Node> locationNode; 
    public List<string> locationName;
    public List<Sprite> locationNameSprite;

    public bool NoNull()
    {
        if (locationSprite.Count < locationSize) return false;
        if (locationNode.Count < locationSize) return false;
        return true;
    }
}
