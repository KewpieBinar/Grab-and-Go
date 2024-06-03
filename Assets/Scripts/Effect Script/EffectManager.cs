using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public EffectPlacementManager effectPlacement;
    public bool placeEffectOnNode = false;

    private void Awake()
    {
        effectPlacement = this.GetComponent<EffectPlacementManager>();
    }
    public void ActivateEffect(Player player, Card card)
    {
        if (card == null) return;
        var effectTag = card.EffectTag;
        
        IEffect effect = null;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            string test = t.name;
            bool isTrue = effectTag.Equals(test);

            if (isTrue)
            {
                effect = t.GetComponent<IEffect>();
                break;
            }
        }

        if (effect == null) return;

        effect.OnEffect(player, card);
    }

    public void PlaceEffectOnNode(Player player, Card card)
    {
        placeEffectOnNode = true;
    }

}



public interface IEffect
{
    void OnEffect(Player player , Card card);

}
