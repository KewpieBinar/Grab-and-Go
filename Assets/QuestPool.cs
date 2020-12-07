using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPool : MonoBehaviour
{
    public static QuestPool pooler;
    public List<ScriptableQuest> scriptables;

    [SerializeField]
    private List<Quest> _questPools;

    private void Awake() => pooler = this;

    private void Start()
    {
        foreach(ScriptableQuest scr in scriptables)
        {
            _questPools.Add(scr.GetQuest());
        }
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
}
