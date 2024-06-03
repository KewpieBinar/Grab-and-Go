
using Photon.Pun;
using UnityEngine;

public class PlayerNotificationManager : MonoBehaviourPun
{
    private NotificationManager _notificationManager;
    private InfoBoxManager _infoBoxManager;
    private Player _player;
    
    private void Awake()
    {
        _player = this.GetComponent<Player>();
        _notificationManager = GameMechanicReference.Instance.GetNotificationManager;
        _infoBoxManager = GameMechanicReference.Instance.GetInfoBoxManager;
    }

    [PunRPC]
    private void RPC_SendNotification(string message)
    {
        /*_notificationManager.SendNotificaton(_player.playerID, message);*/
    }

    public void SendNotification (string message)
    {
        this.photonView.RPC("RPC_SendNotification", RpcTarget.AllBufferedViaServer, message);
    }

    [PunRPC]
    private void RPC_MoneyNotifInfo(string message,int modifier)
    {
        /*_notificationManager.SendNotificaton(_player.playerID, message);

        _infoBoxManager.SendInfo_Money(_player.playerID, modifier);*/
          
    }

    public void MoneyNotifInfo(string message,int modifier)
    {
        this.photonView.RPC("RPC_MoneyNotifInfo", RpcTarget.AllBufferedViaServer,message,modifier);
    }

    [PunRPC]
    private void RPC_CurrentOrderNotifInfo(string message,string pickup,string destination)
    {
        /*int id = _player.playerID;
        _infoBoxManager.SendInfo_CurrentOrder(id, pickup, destination);
        _notificationManager.SendNotificaton(id, message);*/
    }

    public void CurrentOrderNotifInfo(string message, string pickup, string destination)
    {
        this.photonView.RPC("RPC_CurrentOrderNotifInfo", RpcTarget.AllBufferedViaServer, message, pickup, destination);
    }

    [PunRPC]
    private void RPC_Fuel(string message)
    {
        /*int id = _player.playerID;
        _infoBoxManager.SendInfo_Fuel(id, _player.playerFuelManager.GetFuel);
        _notificationManager.SendNotificaton(id, message);*/
    }

    public void FuelNotifInfo(string message)
    {
        this.photonView.RPC("RPC_CurrentOrderNotInfo", RpcTarget.AllBufferedViaServer, message);
    }

}