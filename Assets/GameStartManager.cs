using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviourPun
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    public void StartGameSetup(int numberOfPlayers)
    {
        StartCoroutine(WaitForPlayersToLoad(numberOfPlayers));
    }

    IEnumerator WaitForPlayersToLoad(int MaxPlayer)
    {

        while (transform.childCount != MaxPlayer)
        {
            //Debug.Log("waiting For Players");
            yield return new WaitForSeconds(.5f);
        }

        StartCoroutine(SetUpPlayerTurn());
    }

    IEnumerator SetUpPlayerTurn()
    {
        List<int> idList = new List<int>();
        for (int i = 0; i < transform.childCount; i++)
        {
            PhotonView view = transform.GetChild(i).GetComponent<PhotonView>();
            idList.Add(view.ViewID);

            if(!view.IsMine) yield return null;
            _gameManager.MyPhotonView = view;
            yield return null;
        }

        _gameManager.PlayerViewIDs = TurnRandomizer(idList);

    }

    private List<int> TurnRandomizer(List<int> idList)
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
}
