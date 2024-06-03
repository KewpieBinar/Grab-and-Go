using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    //carUpgrade
    [SerializeField]
    private GameObject carUpgradeUI;
    [SerializeField]
    private Button carUpgradeBtn;
    private bool carUpgradeIsOpen;

    //fuelShop
    [SerializeField]
    private GameObject fuelShopUI;
    [SerializeField]
    private Button fuelShopBtn;
    private bool fuelShopIsOpen;

    private void Start()
    {
        carUpgradeBtn.onClick.AddListener(OnClick_CarUpgrade);
        fuelShopBtn.onClick.AddListener(OnClick_fuelShop);
    }
    private void OnClick_CarUpgrade()
    {
        if(carUpgradeIsOpen)
        {
            carUpgradeUI.SetActive(false);
            carUpgradeIsOpen = false;
        }
        else
        {
            carUpgradeUI.SetActive(true);
            carUpgradeIsOpen = true;

            if (!fuelShopIsOpen) return;
            fuelShopUI.SetActive(false);
            fuelShopIsOpen = false;
        }
    }

    private void OnClick_fuelShop()
    {
        if (fuelShopIsOpen)
        {
            fuelShopUI.SetActive(false);
            fuelShopIsOpen = false;
        }
        else
        {
            fuelShopUI.SetActive(true);
            fuelShopIsOpen = true;

            if (!carUpgradeIsOpen) return;
            carUpgradeUI.SetActive(false);
            carUpgradeIsOpen = false;
        }
        
    }
}
