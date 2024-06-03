using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCounterUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _counterInChild;

    /*private void Awake()
    {
        for(int i = 0;i<transform.childCount;i++)
        {
            _counterInChild.Add(transform.GetChild(i).gameObject);
        }
    }*/
    public void UpdateUpgradeCounter(int upgradeLevel)
    {
        for(int i = 0; i < _counterInChild.Count;i++)
        {
            Debug.Log("jalan kok");
            if (i < upgradeLevel)
                _counterInChild[i].SetActive(true);
            else
                _counterInChild[i].SetActive(false);
        }
    }
}
