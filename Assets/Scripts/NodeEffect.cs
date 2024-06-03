
using UnityEngine;
using System;

public class NodeEffect : MonoBehaviour 
{
    public EffectManager effectManager;
    public Card cardOnNode;
    //public bool IsNull => (cardOnNode == null);
    public bool effectOnNode = false;

    private void Awake()
    {

        if (effectManager == null)
            effectManager = GameMechanicReference.Instance.GetEffectManager;
    }


    public void SetCardOnNode(Card card)
    {
        cardOnNode = card;
        effectOnNode = true;

        //change color ok
    }

    /*private void OnMouseDown()
    {
        if (!effectManager.placeEffectOnNode) return;
        Debug.Log(this.gameObject.name);
    }*/
}
