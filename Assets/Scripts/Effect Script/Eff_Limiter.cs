using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eff_Limiter : MonoBehaviour,IEffect
{
    public void OnEffect(Player player, Card card)
    {
        var limit = card.Modifier;

        if (player.steps <= limit) return;

        player.steps = limit;
    }

    
}
