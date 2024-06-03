using UnityEngine;
using UnityEngine.UI;

public class GameTurnUI : MonoBehaviour
{

    [SerializeField]
    private Text turnDisplayText;
    private int _currentTurn = 1;

    public void SetDisplayTurn(int turn)
    {
        _currentTurn= turn;
        int round = _currentTurn / GameSettingsSingleton.Settings.gameSettings.MaxPlayer;
        turnDisplayText.text = turn.ToString();
    }

    public void OnAdvanceTurn ()
    {
        _currentTurn++;
        turnDisplayText.text = _currentTurn.ToString();
    }

    
}
