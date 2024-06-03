using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataCache : MonoBehaviour
{
    [SerializeField] private ScriptableCardData _cardData;
    public ScriptableCardData CardData { get { return _cardData; } }

    public int CardDataSize { get {return CardData.CardDataSize; } }
}
