using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDrawer : MonoBehaviour
{
    private PlayerEffectManager _playerEffectManager;

    [SerializeField]
    private GameObject cardUI;
    [SerializeField]
    private GameObject _drawCardObj;
    [SerializeField]
    private GameObject _acceptCardObj;

    [SerializeField]
    private Button _drawCardButton;
    [SerializeField]
    private Button _acceptCardButton;

    private Card _cardDrawn;

    [SerializeField]
    private TrafficLightUI trafficLightUI;
    [SerializeField]
    private CardImageUI cardImageUI;

    private void Start()
    {
        _drawCardButton.onClick.AddListener(OnClick_CardDraw);
        _acceptCardButton.onClick.AddListener(OnClick_AcceptCard);
    }

    public void OpenCardDrawer (PlayerEffectManager effectManager)
    {
        //cardUI.SetActive(true);
        trafficLightUI.ActivateCardButton(true);

       /* _drawCardObj.SetActive(true);
        _acceptCardObj.SetActive(false);*/
        _playerEffectManager = effectManager;
        //ToggleButtonListener(true);
    }

    private void CloseCardDrawer()
    {
        //ToggleButtonListener(false);
        _drawCardObj.SetActive(true);
        _acceptCardObj.SetActive(false);
        _playerEffectManager.Set_CardDrawn(_cardDrawn);
        cardUI.SetActive(false);
        trafficLightUI.ActivateCardButton(false);
        
    }

    public void OnClick_CardDraw()
    {
        Card card =  DrawCardFromPool();
        _cardDrawn = card;
        cardImageUI.OnCardDrawn(card.EffectSprite);
        _drawCardObj.SetActive(false);
        _acceptCardObj.SetActive(true);

    }

    public void OnClick_AcceptCard()
    {
        cardImageUI.OnCardClose();
        CloseCardDrawer();
        
    }

    

    public Card DrawCardFromPool ()
    {    
        return CardPool.pooler.GetRandomCard();
    }

    
}
