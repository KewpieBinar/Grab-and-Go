using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanicReference : MonoBehaviour
{
    public static GameMechanicReference Instance;
    private void Awake() => Instance = this;

    [SerializeField]
    private PathSelector _pSelector;
    public PathSelector GetPathSelector => _pSelector;

    [SerializeField]
    private QuestSelector _qSelector;
    public QuestSelector GetQuestSelector => _qSelector;

    [SerializeField]
    private CardDrawer _cardDrawer;
    public CardDrawer GetCardDrawer => _cardDrawer;

    [SerializeField]
    private EffectManager _effectManager;
    public EffectManager GetEffectManager => _effectManager;

    [SerializeField]
    private DiceRoller _diceRoller;
    public DiceRoller GetDiceRoller => _diceRoller;

    [SerializeField]
    private Node _startNode;
    public Node GetStartNode => _startNode;

    [SerializeField]
    private Node _firstDestinationNode;
    public Node GetDestinationNode => _firstDestinationNode;

    [SerializeField]
    private GameManager _gameManager;
    public GameManager GetGameManager => _gameManager;

    [SerializeField]
    private PlayerSpawner _playerSpawner;
    public PlayerSpawner GetPlayerSpawner => _playerSpawner;

    [SerializeField]
    private NotificationManager _notificationManager;
    public NotificationManager GetNotificationManager => _notificationManager;

    [SerializeField]
    private InfoBoxManager _infoBoxManager;
    public InfoBoxManager GetInfoBoxManager => _infoBoxManager;

    [SerializeField]
    private MoneyUI _moneyUI;
    public MoneyUI GetMoneyUI => _moneyUI;

    [SerializeField]
    private FuelCounterUI _fuelCounterUI;
    public FuelCounterUI GetFuelCounterUI => _fuelCounterUI;

    private Player _player;
    public Player GetPlayer => _player;

    [SerializeField]
    private GameEndUI _gameEndUI;
    public GameEndUI GetGameEndUI => _gameEndUI;
    
    public void SetGameManager(GameManager manager)
    {
        _gameManager = manager;
    }

    public void ThisUsersPlayerComponent(Player player)
    {
        _player = player;
    }

}
