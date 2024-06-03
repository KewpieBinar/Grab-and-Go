using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsSingleton : MonoBehaviour
{
    public static GameSettingsSingleton Settings;

    public ScriptableGameSettings gameSettings;

    public ScriptableUiSettings UiSettings;

    private void Awake()
    {
        Settings = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
