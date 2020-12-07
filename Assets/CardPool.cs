using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool pooler;

    [SerializeField] public List<ScriptableCard> scriptables;
    [SerializeField]private List<Card> _cardPool;

    private void Awake()
    {
        pooler = this;
        
    }

    private void Start()
    {
        //StartCoroutine(GeneratePool());

        for (int i = 0; i < scriptables.Count; i++)
        {
            var newCard = new Card(scriptables[i]);
            _cardPool.Add(newCard);
        }

    }

    public Card GetRandomCard ()
    {
        var rand = UnityEngine.Random.Range(0, _cardPool.Count);
        return _cardPool[rand];
    }

    IEnumerator GeneratePool()
    {
        

        yield return null;
    }

    
}
