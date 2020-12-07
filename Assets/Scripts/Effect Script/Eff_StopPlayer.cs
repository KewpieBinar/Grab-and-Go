using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eff_StopPlayer : MonoBehaviour, IEffect
{
    public void OnEffect(Player player, Card card)
    {
        player.steps = 0;
        Debug.Log("stop Player");
        // run Anim
    }
}
