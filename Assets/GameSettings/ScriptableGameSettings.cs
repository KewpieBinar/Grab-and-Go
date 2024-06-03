using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable/Settings/GameSettings")]
public class ScriptableGameSettings : ScriptableObject
{
    [Header("GeneralSettings")]

    [SerializeField] 
    private int _maxPlayer;
    public int MaxPlayer => _maxPlayer;

    [SerializeField]
    private int _numberOfTurns;
    public int NumberOfTurns => _numberOfTurns;

    [Header("Gameplay: Main")]
    [SerializeField]
    private int _maxDiceRoll;
    public int maxDiceRoll => _maxDiceRoll;

    [SerializeField]
    private int _fuelUsageLimit;
    public int fuelUsageLimit => _fuelUsageLimit;

    [Header("Gameplay: Upgrade")]

    [SerializeField]
    private List<int> _maxStepModifier;
    public List<int> maxStepModifier => _maxStepModifier;

    [SerializeField]
    private List<int> _maxStepPrice;
    public List<int> maxStepPrice => _maxStepPrice;

    [SerializeField]
    private List<int> _minStepModifier;
    public List<int> minStepModifier => _minStepModifier;

    [SerializeField]
    private List<int> _minStepPrice;
    public List<int> minStepPrice => _minStepPrice;


    [SerializeField]
    private List<int> _fuelModifier;
    public List<int> fuelModifier => _fuelModifier;

    [SerializeField]
    private List<int> _fuelPrice;
    public List<int> fuelPrice => _fuelPrice;

    [Header("Gameplay: FuelPrice")]
    [SerializeField]
    private int _fuelBuyPrice;
    public int fuelBuyPrice => _fuelBuyPrice;

    [Header("Network Settings")]
    [SerializeField]
    private string _nickname;
    public string Nickname => _nickname;
    [SerializeField]
    private string _gameVersion;
    public string GameVersion => _gameVersion;


}