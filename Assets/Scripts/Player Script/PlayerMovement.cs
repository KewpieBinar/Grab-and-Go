using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviourPun
{
    public Transform PlayerCar;

    public float PlayerSpeed;

    private float _speed => PlayerSpeed;
    private Player _player;
    private Transform _playerCar => PlayerCar;
    private PlayerNodeManager _nodeManager;
    [SerializeField]
    private DiceRoller _diceRoll;
    private RollDisplayer _rollDisplay;

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
        _nodeManager = gameObject.GetComponent<PlayerNodeManager>();
    }

    private void Start()
    {
        _diceRoll = GameMechanicReference.Instance.GetDiceRoller;
        _rollDisplay = _diceRoll.display;
    }

    public void RollDice()
    {
        if (_diceRoll.IsRolling) return;
        _diceRoll.OpenDiceRoller(_player);

    }

    public bool OnMove()
    {
        if (!photonView.IsMine) return false;

        var destTransform = _nodeManager.destinationTransform;

        if (destTransform == null) return false;
        
        Vector3 des = new Vector3(destTransform.position.x, _playerCar.position.y, destTransform.position.z);
        _playerCar.position = Vector3.MoveTowards(_playerCar.position, des, _speed * Time.deltaTime);

        if (des != _playerCar.position) return true; // trigger

        OnDestinationReached();

        return false;
            
    }

    private void OnDestinationReached()
    {
        _player.playerFuelManager.DecreaseFuel();
        _player.steps -= 1;
        _rollDisplay.SetDisplay(_player.steps);
        _player.playerFuelManager.DecreaseFuel();
        _nodeManager.OnReachedDestination();
    }
}