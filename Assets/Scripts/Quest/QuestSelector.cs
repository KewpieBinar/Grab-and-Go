using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSelector : MonoBehaviour
{
    public List<Quest> questOptions;

    //ambil random dari pool tapi nanti doooong
    private List<Quest> questPool;

    public GameObject questUI;
    public GameObject questDetailsUI;

    [SerializeField]
    private QuestDetailsUI detailsUI;

    public List<Button> questButtons;
    public List<Button> detailsButtons;

    // selecting ID
    //private int selectorsID;
    private PlayerQuestManager _playerQuestManager;

    private int _selectedQuest;
    private int _selectedDetails =-1;

    [SerializeField]
    private TrafficLightUI trafficLightUI;

    private void Awake()
    {
        detailsUI = questDetailsUI.GetComponent<QuestDetailsUI>();
        for (int i = 0; i < 3; i++)
        {
            int n = i;
            questButtons[i].onClick.AddListener(delegate { OnQuestSelected(n); });
            detailsButtons[i].onClick.AddListener(delegate { ToggleDetailsUI(n); });

        }
    }

    public void OpenQuestSelector(PlayerQuestManager questManager)
    {
        //questUI.SetActive(true);
        trafficLightUI.ActivateQuestButton(true);

        _playerQuestManager = questManager;

        var questList = QuestPool.pooler.GetQuestList(3);
        questOptions = questList;

        //ToggleButtonListener(true);
        
    }


    public void CloseQuestSelector()
    {

        //ToggleButtonListener(false);
        
        _playerQuestManager = null;
        _selectedQuest = -1;
        _selectedDetails = -1;
        questUI.SetActive(false);
        trafficLightUI.ActivateQuestButton(false);

    }

    private void OnQuestSelected (int selected)
    {
        _playerQuestManager.SetQuest(questOptions[selected]);
        CloseQuestSelector();
    }

    private void ToggleDetailsUI(int selected)
    {
        Debug.Log("toggle details ");
        if (_selectedDetails == selected)
        {
            Debug.Log("tutup detail " + selected);
            questDetailsUI.SetActive(false);
            _selectedDetails = -1;
        }
        else
        {
            Debug.Log("buka detail " + selected);
            questDetailsUI.SetActive(true);
            ShowQuestDetails(selected);
            _selectedDetails = selected;
            
        }

    }

    private void ShowQuestDetails(int selected)
    {
        var quest = questOptions[selected];
        //show quest
        detailsUI.DisplayDetails(quest);
    }

    private void ToggleButtonListener(bool open)
    {
        if (open)
        {
            for (int i = 0; i < 3; i++)
            {
                int n = i;
                questButtons[i].onClick.AddListener(delegate { OnQuestSelected(n); });
                detailsButtons[i].onClick.AddListener(delegate { ToggleDetailsUI(n); });

            }
        }
        else
        {
            for(int i = 0; i < 3; i++)
            {
                questButtons[i].onClick.RemoveAllListeners();
                detailsButtons[i].onClick.RemoveAllListeners();
            }
        }

    }



}