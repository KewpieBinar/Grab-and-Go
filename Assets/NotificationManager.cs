using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    PlayerNotificationManager playerNotif;

    private List<NotificationUI> _notificationUI = new List<NotificationUI>();

    public List<Button> Btn_infobox;

    public List<PlayerInfoBox> InfoBoxes = new List<PlayerInfoBox>(4) { new PlayerInfoBox(1), new PlayerInfoBox(2), new PlayerInfoBox(3), new PlayerInfoBox(4)};
    
    [SerializeField]
    public InfoBoxContainer _infoDisplay;

    private int _currentlyOpened = -1;

    private void Awake()
    {
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            var component = transform.GetChild(i).GetComponent<NotificationUI>();



            if (component != null)
                _notificationUI.Add(transform.GetChild(i).GetComponent<NotificationUI>());
        }

        for(int i = 0; i<Btn_infobox.Count; i++)
        {
            int n = i;
            Btn_infobox[i].onClick.AddListener(delegate { TogglePlayerInfoBox(n); });
        }

        

    }
    
    //Notification
    public void SendNotificaton(int playerId, string message)
    {
        _notificationUI[playerId].DisplayNotification(message);
    }

    // InfoSharing
    public void SendInfo_Money(int playerId, int money)
    {
        InfoBoxes[playerId].player_money = money;
    }

    public void SendInfo_Fuel(int playerId, int fuel)
    {
        InfoBoxes[playerId].player_fuel = fuel;
    }

    
    public void SendInfo_CurrentOrder(int playerId, string pickup,string destination)
    {
        InfoBoxes[playerId].co_pickup = pickup; //mungkin pake image lebih menarik
        InfoBoxes[playerId].co_destination = destination;
    }


    public void TogglePlayerInfoBox(int playerBox)
    {
        if(playerBox == _currentlyOpened)
        {
            _infoDisplay.CloseDisplay();
            _currentlyOpened = -1;
            return;
        }else
        {
            _infoDisplay.transform.gameObject.SetActive(true);
            _infoDisplay.DisplayInfoBox(InfoBoxes[playerBox]);
            _currentlyOpened = playerBox;
        }
        
    }

    
}
