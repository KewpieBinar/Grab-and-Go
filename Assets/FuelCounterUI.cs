using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCounterUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> fuelBars;
    [SerializeField]
    private GameObject fuelBarEmpty;
    private int _fuelBarLength => fuelBars.Count;

    public void UpdateFuelBar(int fuelState)
    {
        
        for(int i = 0; i < _fuelBarLength; i++)
        {
            if (i < fuelState)
                fuelBars[i].SetActive(true);
            else
                fuelBars[i].SetActive(false);
        }

        if (fuelState == 0)
            fuelBarEmpty.SetActive(true);
        else
            fuelBarEmpty.SetActive(false);
    }

    
}
