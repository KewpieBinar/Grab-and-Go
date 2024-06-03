using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    [SerializeField]
    private List<Text> scoreListText;
    [SerializeField]
    private List<Text> playerListText;

    [SerializeField]
    private List<GameObject> yourResult;
    [SerializeField]
    private List<GameObject> yourBackGround;

    public void OpenGameEndUI(List<PlayerInfoBox> infoBox,List<int> winnerList,int myID)
    {
        UI.SetActive(true);
        
        for(int i = 0; i < infoBox.Count; i++ )
        {
            for(int j = 0; j < winnerList.Count; j++)
            {
                    
                break;
            }
        }
    }
}
