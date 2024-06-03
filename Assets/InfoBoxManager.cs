using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject infoBox;

    [SerializeField]
    private InfoBoxUI _infoboxUI;

    [SerializeField]
    private int selectedBox;

    [SerializeField]
    private List<PlayerInfoBox> InfoBoxList = new List<PlayerInfoBox> { new PlayerInfoBox(1), new PlayerInfoBox(2), new PlayerInfoBox(3), new PlayerInfoBox(4) };

    public List<PlayerInfoBox> GetInfoboxList => InfoBoxList;

    [SerializeField]
    List<Button> infoBoxButton;


    private void Start()
    {
        for(int i = 0; i < infoBoxButton.Count; i ++)
        {
            Debug.Log("display box ");
            int n = i;
            infoBoxButton[n].onClick.AddListener(delegate { ToggleInfoBox(n); });
        }
    }
    public void SendInfo_Money(int playerId, int moneyModifier)
    {
        InfoBoxList[playerId].player_money += moneyModifier;
    }

    public void SendInfo_Fuel(int playerId, int fuel)
    {
        InfoBoxList[playerId].player_fuel = fuel;
    }


    public void SendInfo_CurrentOrder(int playerId, string pickup, string destination)
    {
        InfoBoxList[playerId].co_pickup = pickup;
        InfoBoxList[playerId].co_destination = destination;
    }

    public void ToggleInfoBox(int selected)
    {
        Debug.Log("display box "+selected);
        if(selectedBox != selected)
        {
            OpenInfoBox(selected);
        }
        else
        {
            CloseInfoBox(selected);
        }
    }

    public void OpenInfoBox(int selected)
    {
        
        infoBox.SetActive(true);
        _infoboxUI.DisplayInfo(InfoBoxList[selected]);
        selectedBox = selected;
    }

    public void CloseInfoBox(int selected)
    {
        infoBox.SetActive(false);
        selectedBox = -1;
    }

}

[System.Serializable]
public class PlayerInfoBox
{
    public int ID;
    public string playerText;
    public string co_pickup;
    public string co_destination;
    public int player_money;
    public int player_fuel;

    public PlayerInfoBox(int id)
    {
        ID = id + 1;
        playerText = string.Format("player {0}", id);
        co_pickup = "null";
        co_destination = "null";
        player_money = 0;
        player_fuel = 0;
    }
}