using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ambil dari pool kartu id
public class CardManager : MonoBehaviour
{
    public List<ScriptableCard> scriptablePool;
    private int _poolLength => scriptablePool.Count;

    public Card GetNewRandomCard()
    {
        var random = UnityEngine.Random.Range(0, _poolLength);
        var selectedScriptable = scriptablePool[random];

        return new Card(selectedScriptable);
    }

}
