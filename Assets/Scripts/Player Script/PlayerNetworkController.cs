using Photon.Pun;
using UnityEngine;

public class PlayerNetworkController : MonoBehaviourPun
{
    private Player _player;
    private GameManager _gameManager;
    private PhotonView _myPhotonView;
    private void Awake()
    {
        _player = this.GetComponent<Player>();
        _gameManager = GameMechanicReference.Instance.GetGameManager;      
        _myPhotonView = this.photonView;
    }

    private void Start()
    {
        transform.parent = _gameManager.GetTransform;
        if (!photonView.IsMine) return;
        GameMechanicReference.Instance.ThisUsersPlayerComponent(_player);
    }

    [PunRPC]
    public void RPC_StartTurn(int playerTurnId)
    {
        if (_myPhotonView.ViewID != playerTurnId) return;
        _player.StartTurn();
    }

    [PunRPC]
    public void RPC_GameEnd()
    {
        //if (!PhotonNetwork.IsMasterClient) return;
        _gameManager.OnGameEnd();
    }

    [PunRPC]
    public void RPC_EndTurn()
    {
        //if (!PhotonNetwork.IsMasterClient) return;
        _gameManager.EndTurn();
    }

    public void EndTurn()
    {
        //this.photonView.RPC("RPC_EndTurn", RpcTarget.MasterClient);
        this.photonView.RPC("RPC_EndTurn", RpcTarget.AllBufferedViaServer);
        
    }


}

