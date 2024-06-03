using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Data/ScriptableQuest")]
public class ScriptableQuestParam : ScriptableObject
{
    public int locationSize;
    public List<Sprite> locationSprite;
    public List<Sprite> locationNameSprite;
    public List<string> locationName;
    public int maxPairing => locationSize ^ 2;

   /* public bool NoNull()
    {
        if (locationSprite.Count < locationSize) return false;
        if (locationNode.Count < locationSize) return false;
        //ff (locationName.Count < locationSize) return false;
        return true;
    }
*/
    
    
}
