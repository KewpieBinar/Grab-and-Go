using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Settings/UISettings")]
public class ScriptableUiSettings : ScriptableObject
{
    [Header("Notification")]

    [SerializeField]
    private float _notificationSpeed;
    public float notificationSpeed => _notificationSpeed;
    [SerializeField]
    private float _notificationDuration;
    public float notificationDuration => _notificationDuration;

    [Header("TurnMeter UI")]
    [SerializeField]
    private float _turnMeter_moveSpeed;
    public float turnMeter_speed => _turnMeter_moveSpeed;

}