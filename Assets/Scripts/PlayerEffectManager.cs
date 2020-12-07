using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerEffectManager : MonoBehaviour
{
    private Player _player;
    public EffectManager effectManager;

    private bool _onEffect;
    private bool _drawCard;

    public bool specialNode;
    public bool effectOnNode;

    public Card cardDrawn;

    public CardManager cardManager;

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("lol wkwk");
            cardDrawn = null;
        }*/
    }

    private void Awake()
    {
        _player = this.GetComponent<Player>();
    }

    public void GetCard()
    {
        if (_onEffect) return;
        cardDrawn = cardManager.GetNewRandomCard();
    }

    public void DrawCard()
    {
        if (_drawCard) return;
        //Draw CArd
    }

    public void CheckSpecialNode(Node currentNode)
    {
        if (currentNode.isSpecial())
        {
            specialNode = true;
            Debug.Log("SPECIAL NODE");
        }

        if(!currentNode.nodeEffect.IsNull)
        {
            effectOnNode = true;
            Debug.Log("Effect Node");
        }
    }

    public void ActivateDrawCardEffect(Player player)
    {
        effectManager.ActivateEffect(player, cardDrawn);
        Debug.Log("effect activates :" + cardDrawn.EffectName);
        specialNode = false;
    }
}