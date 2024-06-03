using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPool : MonoBehaviour
{ 
    public static QuestPool pooler;
    public QuestDataCache questData; //janlup bikin ini
    public ScriptableQuestParam questParam;

    [SerializeField]
    private List<Quest> _questPools;

    private void Awake() => pooler = this;

    private void Start()
    {
        //if (questData == null) return;
        //if (!questData.NoNull()) return;
        //CreateRandomPool(questData.locationSize);
        CreateRandomPool(questParam.maxPairing/5);
        
    }

    private void CreateRandomPool(int maxPairing)
    {
        for(int i = 0; i < maxPairing; i++)
        {
            var quest = CreateQuest(questParam.locationSize);
            _questPools.Add(quest);
        }
        
    }

    private Quest CreateQuest(int paramSize)
    {
        var pickupIndex  = -1;
        var dropOffIndex = -1;
        var reward = UnityEngine.Random.Range(0, 101);

        for (int i = 0; i < 50; i++)
        {
            pickupIndex = UnityEngine.Random.Range(0, paramSize);
            dropOffIndex = UnityEngine.Random.Range(0, paramSize);

            if (pickupIndex != dropOffIndex) break;
        }

        if (pickupIndex < 0 || dropOffIndex < 0) return null;
        Node pickup = NodeMapList.nodeMapList.GetNodeByObjectName(questParam.locationName[pickupIndex]);
        Node dropOff = NodeMapList.nodeMapList.GetNodeByObjectName(questParam.locationName[dropOffIndex]);
        return new Quest(
            pickup,
            dropOff,
            reward,
            questParam.locationSprite[pickupIndex],
            questParam.locationSprite[dropOffIndex],
            questParam.locationNameSprite[pickupIndex],
            questParam.locationNameSprite[dropOffIndex]
            );

        //return new Quest(questData.locationNode[pickupIndex], questData.locationNode[dropOffIndex], reward ,questData.locationSprite[pickupIndex],questData.locationSprite[dropOffIndex],questData.locationNameSprite[pickupIndex], questData.locationNameSprite[dropOffIndex]);
    }

    public List<Quest> GetRandomQuestList(int numberOfQuest)
    {
        if (numberOfQuest > _questPools.Count) return null;

        List<Quest> list = new List<Quest>();

        for(int i = 0; i < numberOfQuest; i++)
        {
            var random = UnityEngine.Random.Range(0, _questPools.Count);
            list.Add(_questPools[random]);
        }

        return list;
    }

    public List<Quest> GetQuestList(int numberOfQuest)
    {
        if (numberOfQuest > _questPools.Count) return null;

        List<Quest> list = new List<Quest>();

        for (int i = 0; i < numberOfQuest; i++)
        {
            var quest = _questPools[i];
            list.Add(quest);
        }

        return list;
    }
}
