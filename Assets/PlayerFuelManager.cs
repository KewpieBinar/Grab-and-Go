using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelManager : MonoBehaviour
{
    private Player _player;
    private FuelCounterUI _fuelCounterUI;

    private int _fuelBar = 5;
    public int GetFuel => _fuelBar;
    public bool EmptyFuel => _fuelBar <= 0;

    [SerializeField]
    private int _stepsPerBar = 10;
    public int usageModifier = 0;
    public int StepsPerBar => _stepsPerBar + usageModifier;

    private int _fuelUsage = 0;

    private void Awake()
    {
        _stepsPerBar = GameSettingsSingleton.Settings.gameSettings.fuelUsageLimit;
        _player = GetComponent<Player>();
        _fuelCounterUI = GameMechanicReference.Instance.GetFuelCounterUI;
    }

    public void DecreaseFuel()
    {
        _fuelUsage++;

        if (_fuelUsage < StepsPerBar) return;
        _fuelUsage = 0;

        if (EmptyFuel) return;
        _fuelBar -= 1;
        _fuelCounterUI.UpdateFuelBar(_fuelBar);
    }

    public void AddFuel()
    {
        _fuelBar = 5;
        _fuelUsage = 0;
        _fuelCounterUI.UpdateFuelBar(_fuelBar);
    }
}
