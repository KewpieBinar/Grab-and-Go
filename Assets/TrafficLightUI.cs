using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightUI : MonoBehaviour
{
    public Button questButtonUI;
    private bool questIsOpen;
    [SerializeField]
    private GameObject questUI;

    public Button cardButtonUI;
    private bool cardIsOpen;
    [SerializeField]
    private GameObject cardUI;

    public Button shopButtonUI;
    private bool shopIsOpen;
    [SerializeField]
    private GameObject shopUI;

    private void Start()
    {
        questButtonUI.onClick.AddListener(OnClick_Quest);
        cardButtonUI.onClick.AddListener(OnClick_Card);
        shopButtonUI.onClick.AddListener(OnClick_Shop);
    }
    public  void ActivateQuestButton(bool open)
    {
        questButtonUI.transform.gameObject.SetActive(open);
        questIsOpen = false;
    }

    public void OnClick_Quest()
    {
        if (questIsOpen)
        {
            questIsOpen = false;
            questUI.SetActive(false);
        } 
        else
        {
            Debug.Log("openup");
            questIsOpen = true;
            questUI.SetActive(true);
            return;//open
        } 
    }

    public void ActivateShopButton(bool open)
    {
        shopButtonUI.transform.gameObject.SetActive(open);
        shopIsOpen = false;
        
    }

    public void OnClick_Shop()
    {
        if (shopIsOpen)
        {
            shopIsOpen = false;
            shopUI.SetActive(false); // close
        }
        else 
        {  
            shopIsOpen = true;
            shopUI.SetActive(true);
            return;
        }
        // open
    }

    public void ActivateCardButton(bool open)
    {
        cardButtonUI.transform.gameObject.SetActive(open);
        cardIsOpen = false;
    }

    public void OnClick_Card()
    {
        if (cardIsOpen)
        {
            cardIsOpen = false;
            cardUI.SetActive(false);
        }  // close
        else // open
        {
            cardIsOpen = true;
            cardUI.SetActive(true);
            return;
        }
    }
}
