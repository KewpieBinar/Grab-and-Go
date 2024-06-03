using System;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPun
{

    [SerializeField]
    private GameManager _manager;

    [SerializeField]
    private GameObject[] playerPrefabs;

    [SerializeField]
    private Transform[] SpawnPoints;

    private void Awake()
    {
        if (!PhotonNetwork.IsConnected) return;
        SpawnPlayers();
    }


    private void SpawnPlayers()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        if (playerPrefabs[i] == null) {
            Debug.LogError("failed to spawn Player");
            return; 
        }

        var obj = (GameObject)PhotonNetwork.Instantiate(playerPrefabs[i].name, SpawnPoints[i].position, Quaternion.identity);

    }

}