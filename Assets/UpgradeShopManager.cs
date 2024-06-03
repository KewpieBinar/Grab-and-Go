using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShopManager : MonoBehaviour
{
    private Player _player = null;

    [SerializeField]
    private List<UpgradeCounterUI> upgradeCounterUIList;

    /*[SerializeField]
    private List<int> upgradeLevel;

    private List<int> _fuelModifier; 
    private List<int> _maxStepModifier; 
    private List<int> _minStepModifier;*/
    private List<CarUpgrade> _carUpgrade;

    [SerializeField]
    private List<Button> _buyButton;

    private void Start()
    {
        //GetPlayerIfNull();
        _player = GameMechanicReference.Instance.GetPlayer;
        SetupStore(GameSettingsSingleton.Settings.gameSettings);
        
    }
    private void SetupStore (ScriptableGameSettings settings)
    {
        /*_fuelModifier = settings.fuelModifier;
        _maxStepModifier = settings.maxStepModifier;
        _minStepModifier = settings.minStepModifier;*/

        CarUpgrade fuel = new CarUpgrade("fuel", settings.fuelModifier, settings.fuelPrice);
        CarUpgrade maxStep = new CarUpgrade("maxStep", settings.maxStepModifier, settings.maxStepPrice);
        CarUpgrade minStep = new CarUpgrade("minStep", settings.minStepModifier, settings.minStepPrice);
        _carUpgrade = new List<CarUpgrade> {fuel, maxStep, minStep};

        _buyButton[0].onClick.AddListener(delegate { Upgrade(0); });
        _buyButton[1].onClick.AddListener(delegate { Upgrade(1); });
        _buyButton[2].onClick.AddListener(delegate { Upgrade(2); });
    }
    /*public void OnClick_UpgradeFuel()
    {
        Debug.Log("fueled upgrade");
        GetPlayerIfNull();
        Upgrade(0);
    }

    public void OnClick_UpgradeMaxStep()
    {
        Debug.Log("max upgrade");
        GetPlayerIfNull();
        Upgrade(1);
    }

    public void OnClick_UpgradeMinStep()
    {
        Debug.Log("min upgrade");
        GetPlayerIfNull();
        Upgrade(2);
    }*/

    private void Upgrade(int i)
    {
        GetPlayerIfNull();
        int currentUpgradeLevel = _carUpgrade[i].CurrentLevel;
        //upgradeLevel[i]++;
        //upgradeCounterUIList[i].UpdateUpgradeCounter(upgradeLevel[i]);
        //if (_player.playerMoney < _carUpgrade[i].ModifierPrice[_carUpgrade[i].CurrentLevel]) return;
        if (currentUpgradeLevel == _carUpgrade[i].maxUpgrade) return;

        
        _player.DecreaseMoney(_carUpgrade[i].ModifierPrice[currentUpgradeLevel]);
        UpgradeModifier(i, _carUpgrade[i].ModifierLevel[currentUpgradeLevel]);
        _carUpgrade[i].CurrentLevel++;

        upgradeCounterUIList[i].UpdateUpgradeCounter(_carUpgrade[i].CurrentLevel);
    }

    private void UpgradeModifier(int i,int modifier)
    {
        if(i == 0)
        {
            _player.playerFuelModifier = modifier;
        }
        else if (i == 1)
        {
            _player.playerMaxStepsModifier = modifier;
        }
        else if (i == 2)
        {
            _player.playerMinStepsModifier = modifier;
        }
    }

    private void GetPlayerIfNull()
    {
        if (_player != null) return;
        _player = GameMechanicReference.Instance.GetPlayer;
    }

}

public class CarUpgrade
{
    public string upgradeName;
    public int CurrentLevel;
    public List<int> ModifierLevel;
    public List<int> ModifierPrice;
    public int maxUpgrade => ModifierLevel.Count; 
    public CarUpgrade(string name,List<int> modifierLevel, List<int> modifierPrice)
    {
        upgradeName = name;
        CurrentLevel = 0;
        ModifierLevel = modifierLevel;
        ModifierPrice = modifierPrice;
    }

    
}


