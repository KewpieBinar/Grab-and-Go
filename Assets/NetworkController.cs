using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public GameObject StartGameButton;
    public Button Btn_StartGame;
    //public PlayerSpawner playerSpawn; 

    private void Awake()
    {
        Btn_StartGame = StartGameButton.GetComponent<Button>();
        Btn_StartGame.onClick.AddListener(OnClick_StartGame);
    }

    

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        StartGameButton.SetActive(false);

    }

    public override void OnConnected()
    {
        //base.OnConnected();
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("conected to " + PhotonNetwork.ServerAddress);
        StartGameButton.SetActive(true);
    }

    private void OnClick_StartGame()
    {
        string roomName = "Room1";
        Photon.Realtime.RoomOptions opts = new Photon.Realtime.RoomOptions();
        opts.IsOpen = true;
        opts.IsVisible = true;
        opts.MaxPlayers = 4;
        Debug.Log("joining room...");
        PhotonNetwork.JoinOrCreateRoom(roomName, opts, Photon.Realtime.TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        SceneManager.LoadScene("MainScene");
        
    }

}
