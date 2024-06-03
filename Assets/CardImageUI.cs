using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardImageUI : MonoBehaviour
{
    public Image CardImage;
    public RectTransform BackCardTransform;
    public RectTransform FrontCardTransform;
    private Vector3 _backOrigin;
    private Vector3 _frontOrigin;

    [SerializeField]
    private float delayPerLoop = 0.02f;

    private void Start()
    {
        _backOrigin = BackCardTransform.localScale;
        _frontOrigin = FrontCardTransform.localScale;
    }
    public void OnCardDrawn(Sprite cardImageDrawn)
    {
        BackCardTransform.localScale = _backOrigin;
        FrontCardTransform.localScale = _frontOrigin;
        CardImage.sprite = cardImageDrawn;
        StartCoroutine(Cor_OnCardDrawn());
    }
    private IEnumerator Cor_OnCardDrawn()
    {
        float scale = 1;
        //Vector3 origin = BackCardTransform.localScale;
        Vector3 target = new Vector3(0, BackCardTransform.localScale.y, BackCardTransform.localScale.z);

        while (BackCardTransform.localScale != target)//scale > 0)
        {
            BackCardTransform.localScale = Vector3.MoveTowards(BackCardTransform.localScale,target,0.1f);
            //scale = Mathf.Lerp(scale, 0, 0.04f);
            //BackCardTransform.localScale = new Vector3(scale, BackCardTransform.localScale.y, BackCardTransform.localScale.z);
            yield return null;
        }

        target = new Vector3(1, FrontCardTransform.localScale.y, FrontCardTransform.localScale.z);

        while (FrontCardTransform.localScale != target)
        {
            FrontCardTransform.localScale = Vector3.MoveTowards(FrontCardTransform.localScale, target, 0.1f);
            //scale = Mathf.Lerp(scale, 0, 0.04f);
            //BackCardTransform.localScale = new Vector3(scale, BackCardTransform.localScale.y, BackCardTransform.localScale.z);
            yield return null;
        }

    }

    public void OnCardClose()
    {
        FrontCardTransform.localScale = Vector3.zero;
        BackCardTransform.localScale = new Vector3(1, BackCardTransform.localScale.y, BackCardTransform.localScale.z);
    }
}
