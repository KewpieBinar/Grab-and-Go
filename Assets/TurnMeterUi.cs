using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMeterUi : MonoBehaviour
{
    // TurnMeterMoveAnimation
    private Coroutine _corIsRunning  = null;
    private Vector3 _originalPosition;
    [SerializeField] private float _moveSpeed = 1;
    public Vector3 CenterScreen = Vector3.zero;

    [SerializeField]
    private DiceRoller diceRoller;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
        _moveSpeed = GameSettingsSingleton.Settings.UiSettings.turnMeter_speed;
    }

    public void MoveTurnMeter(bool toCenter)
    {
        if (_corIsRunning != null) StopCoroutine(_corIsRunning);
        _corIsRunning =  StartCoroutine(TurnMeterMove(toCenter));
        
    }

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) MoveTurnMeter(true);
        if (Input.GetKeyDown(KeyCode.N)) MoveTurnMeter(false);
    }*/

    private IEnumerator TurnMeterMove(bool toCenter)
    {
        Vector3 target = Vector3.zero;

        if (toCenter)
            target = CenterScreen;
        else
            target = _originalPosition;
        
        while(transform.localPosition != target)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,target,_moveSpeed*Time.deltaTime);
            //yield return new WaitForSeconds(0.01f);
            yield return null;
        }

        if (toCenter) diceRoller.OnCenter();
        else diceRoller.OnOriginal();
        
    }
}
