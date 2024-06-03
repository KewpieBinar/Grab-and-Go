using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


public class GameManager : MonoBehaviourPun
{
    public Transform GetTransform { get { return transform; } }

    public PlayerSpawner playerSpawner;

    public int MaxPlayer;
    public List<int> PlayerViewIDs = new List<int>();
    public List<PhotonView> PlayerViews = new List<PhotonView>();
    public PhotonView MyPhotonView;

    [SerializeField]
    private GameTurnUI _turnUI;
    private int _turns = 0;
    private int _playerTurn = 0;

    public int MaxNumberOfTurns;


    private void Start()
    {
        if (GameSettingsSingleton.Settings == null) return;

        var settings = GameSettingsSingleton.Settings.gameSettings;
        MaxPlayer = settings.MaxPlayer;
        MaxNumberOfTurns = settings.NumberOfTurns;

        if (!PhotonNetwork.IsMasterClient) return;
            StartCoroutine(WaitForPlayersToLoad());
    }

    IEnumerator WaitForPlayersToLoad()
    {

        while (transform.childCount != MaxPlayer)
        {
            yield return new WaitForSeconds(.5f);
        }

        StartCoroutine(SetUpTurns());
    }

    IEnumerator SetUpTurns ()
    {
        if (transform.childCount != MaxPlayer) yield return new WaitForSeconds(.2f);

        for (int i = 0; i < transform.childCount; i++)
        {
            PhotonView view = transform.GetChild(i).GetComponent<PhotonView>();
            PlayerViews.Add(view);
            PlayerViewIDs.Add(view.ViewID);

            
            if (view.IsMine) MyPhotonView = view;
            yield return null;
        }
        StartTurn();
    }


    public void StartTurn()
    {
        Debug.Log("gameStart");
        var nextPlayerView = GetPhotonView(PlayerViewIDs[_playerTurn]);
        nextPlayerView.RPC("RPC_StartTurn", RpcTarget.AllBufferedViaServer,nextPlayerView.ViewID);
        
    }

    private PhotonView GetPhotonView(int viewID)
    {
        foreach(PhotonView view in PlayerViews)
        {
            if (view.ViewID == viewID) return view;
        }
        return null;
    }

    public void EndTurn()
    {
        _turns++;
        _turnUI.SetDisplayTurn(_turns);
        _playerTurn++;

        if (_playerTurn == MaxPlayer) _playerTurn = 0;
        
        if (!PhotonNetwork.IsMasterClient) return;

        if (_turns >= MaxNumberOfTurns)
        {
            GameEnd();
        }
        else
        {
            StartTurn();
        }
        
    }

    
    private List<int> TurnRandomizer(List<int> idList) // not Used probably
    {
        System.Random rng = new System.Random();
        for (int i = idList.Count; i > 1;)
        {
            i--;
            int k = rng.Next(i + 1);
            var temp = idList[k];
            idList[k] = idList[i];
            idList[i] = temp;

        }

        return idList;
    }

    public void OnGameEnd()
    {
        GameEndUI gameEnd = GameMechanicReference.Instance.GetGameEndUI;
        InfoBoxManager infoManager = GameMechanicReference.Instance.GetInfoBoxManager;
        List<PlayerInfoBox> infoBoxes = infoManager.GetInfoboxList;
        List<int> winnerList = GetScoreBoard(infoBoxes);
        gameEnd.OpenGameEndUI(infoBoxes,winnerList, GameMechanicReference.Instance.GetPlayer.playerID);
    }



    private void GameEnd()
    {
        var nextPlayerView = GetPhotonView(PlayerViewIDs[_playerTurn]);
        nextPlayerView.RPC("RPC_GameEnd", RpcTarget.AllBufferedViaServer);
    }


    private List<int> GetScoreBoard(List<PlayerInfoBox> infoBoxes)
    {
        int maxMoney = -1;
        int currentPlayerWinner = 0;
        List<int> playerPosition = new List<int>();
        //Score Calc
        for(int i = 0; i < infoBoxes.Count;i++)
        {
            foreach (PlayerInfoBox iB in infoBoxes)
            {
                if (iB.player_money > maxMoney)
                {
                    currentPlayerWinner = iB.ID;
                    maxMoney = iB.player_money;
                }
                playerPosition.Add(currentPlayerWinner);
                maxMoney = -1;
            }

        }

        return playerPosition;
        
    }

    
}