using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerEffectManager : MonoBehaviourPun
{
    private Player _player;
    private PlayerEffectManager _playerEffectManager;

    public EffectManager effectManager;
    public CardDrawer cardDrawer;

    private bool _onEffect;
    private bool _drawCard;

    public bool specialNode;

    public bool ActivateDrawnCard;
    public bool placeEffectOnNode;
    public bool effectOnNode;

    public Card cardDrawn;
    public Card cardToPlace;

    //public CardManager cardManager;

    private void Awake()
    {
        _player = this.GetComponent<Player>();
        _playerEffectManager = this.GetComponent<PlayerEffectManager>();
    }

    private void Start()
    {
        cardDrawer = GameMechanicReference.Instance.GetCardDrawer;
        effectManager = GameMechanicReference.Instance.GetEffectManager;
        if (cardDrawer == null) Debug.LogError("cannot get cardDrawer");
    }

    public void Set_CardDrawn(Card card)
    {    
        
        specialNode = false;
        
        if(card.EffectOnPlayer)
        {
            ActivateDrawnCard = true;
            cardDrawn = card;
        }
        else
        {
            ActivateEffectPlacement();
            placeEffectOnNode = true;
            cardToPlace = card;
        }
        
    }

    public void CheckSpecialNode(Node currentNode)
    {

        if (currentNode.isSpecial())
        {
            specialNode = true;
            cardDrawer.OpenCardDrawer(_playerEffectManager);
            return;
        }

        if(currentNode.nodeEffect.effectOnNode)
        {
            effectOnNode = true;
            return;
        }
    }

    public void ActivateEffectPlacement()
    {
        effectManager.effectPlacement.StartPlaceEffect(_playerEffectManager);
    }

    public void ActivateDrawnCardEffect(Player player)
    {
        //notification Text
        var tex = string.Format("Player {0} Drew {1}", player.playerID + 1, cardDrawn.EffectName);
        _player.Notification(tex);

        effectManager.ActivateEffect(player, cardDrawn);
        ActivateDrawnCard = false;
    }

    public void ActivateEffectOnNode(Player player)
    {
        var tex = string.Format("Player {0} Step On Effect: {1}", player.playerID + 1, cardDrawn.EffectName);
        _player.Notification(tex);

        Node nd = player.playerNodeManager.currentNode;
        effectManager.ActivateEffect(player, nd.nodeEffect.cardOnNode);
        RemoveEffectOnNode(nd.GetTransform().name);

        effectOnNode = false;
    }
    
    // TO BE REVIEWED KALO BISA UR DONE BOIIIII
    private void RemoveEffectOnNode(string nodeName)
    {
        //REMOVE THE EFFECT NODE ON MAP
        photonView.RPC("RPC_RemoveEffectOnNode", RpcTarget.AllBufferedViaServer,nodeName);
    }

    [PunRPC]
    private void RPC_RemoveEffectOnNode(string nodeName)
    {
        Node node = NodeMapList.nodeMapList.GetNodeByObjectName(nodeName);
        if (node == null) return;
        node.nodeEffect.cardOnNode = null;
        node.nodeEffect.effectOnNode = false;
        node.nodeColor.Color_Original();

        Debug.Log("bruh bisa");
    }

    

    //Place Card Effect
    [PunRPC]
    public void RPC_SetOnNode (string nodeName, string cardName,string cardTag, int modifier) //IT WORKS I GUESS
    {
        //set secara manual
        //effectManager.effectPlacement.

        //Search Node tersebut
        //PlaceEffect over the network
        //Debug.Log("activate" + nodeName);

        //givesEffectAndColors
        Node node = NodeMapList.nodeMapList.GetNodeByObjectName(nodeName);
        node.nodeEffect.SetCardOnNode(new Card(cardName, cardTag, null, true, 0, modifier));
        node.nodeColor.Color_OnEffect();

        if (!photonView.IsMine) return;
        placeEffectOnNode = false;
    }

    public void SetOnNode (string nodeName)
    {
        Card card = cardToPlace;
        photonView.RPC("RPC_SetOnNode", RpcTarget.AllBufferedViaServer, nodeName, card.EffectName, card.EffectTag, card.Modifier);
    }
}