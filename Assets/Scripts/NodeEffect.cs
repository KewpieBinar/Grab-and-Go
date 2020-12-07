using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeEffect : MonoBehaviour 
{
    public EffectManager effectManager;
    public Card cardOnNode;
    public bool IsNull => (cardOnNode == null);

    public void OnSelect(Player player)
    {
        effectManager.ActivateEffect(player,cardOnNode);
    }
}
