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

    public List<Button> questButtons;

    // selecting ID
    private int selectorsID;
    private PlayerQuestManager _playerQuestManager;

    public void OpenQuestSelector(PlayerQuestManager questManager)
    {
        questUI.SetActive(true);
        _playerQuestManager = questManager;
        var questList = QuestPool.pooler.GetRandomQuestList(2);
        ToggleButtonListener(true);
        
    }


    public void CloseQuestSelector()
    {

        ToggleButtonListener(false);
        selectorsID = -1;
        _playerQuestManager = null;
        questUI.SetActive(false);

    }

    private void OnQuestSelected (int selected)
    {
        _playerQuestManager.SetQuest(questOptions[selected]);
        CloseQuestSelector();
    }

    private void ToggleButtonListener(bool open)
    {
        if (open)
        {
            for (int i = 0; i < 2; i++)
            {
                int n = i;
                questButtons[i].onClick.AddListener(delegate { OnQuestSelected(n); });

            }
        }
        else
        {
            foreach (Button bt in questButtons)
            {
                bt.onClick.RemoveAllListeners();
            }
        }

    }



}