using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _gameVersion;
    public string GameVersion 
    { 
        get 
        { 
            return _gameVersion;
        } 
    }

    [SerializeField]
    private string _nickName;
    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);
            return _nickName + value.ToString();
        }
    }

}
