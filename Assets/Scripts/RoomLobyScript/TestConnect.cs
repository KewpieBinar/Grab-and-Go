using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("connecting to server");
        PhotonNetwork.NickName = GameSettingsSingleton.Settings.gameSettings.Nickname;//MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = GameSettingsSingleton.Settings.gameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //print("connected to server");
        Debug.Log("connected to photon", this);
        //print(PhotonNetwork.LocalPlayer.NickName);
        Debug.Log("Nickname = " + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //print("disconnected from server" + cause.ToString());
        Debug.Log("Failed to connect" + cause.ToString(), this);
    }
}
