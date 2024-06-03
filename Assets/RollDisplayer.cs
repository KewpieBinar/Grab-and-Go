using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDisplayer : MonoBehaviour
{
   
    public Text displayText;
    public IEnumerator UpdateDisplayValue (int scaleTo ,float delay)
    {
        
        for(int i = 0; i < scaleTo + 1; i++)
        {
            var val = i.ToString();
            displayText.text = val;
            yield return new WaitForSeconds(delay);
        }
        
    }

    public IEnumerator DecreaseDisplayValue(int scaleform,int scaleTo, float delay)
    {
        
        for (int i = scaleform; i >= scaleTo; i--)
        {
            var val = i.ToString();
            displayText.text = val;
            yield return new WaitForSeconds(delay);
        }

    }

    public void UpdateDisplay(int scaleTo, float delay)
    {
        StartCoroutine(UpdateDisplayValue(scaleTo, delay));
    }

    public void DecreaseStepValue(int scalefrom,int scaleTo, float delay)
    {
        DecreaseDisplayValue(scalefrom, scaleTo, delay);
    }

    public void SetDisplay(int setTo)
    {
        var val = setTo.ToString();
        displayText.text = val;
    }
}
