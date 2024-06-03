
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{
    [SerializeField]
    private Text _notifText;

    private bool _crIsRunning = false;

    //private List<string> _messageQueue = new List<string>();
    private Queue<string> _messageQueue = new Queue<string>();

    [SerializeField]
    private float _notifWriteSpeed = 0.05f;

    [SerializeField]
    private float _notificationDuration = 3f;

    private void Awake()
    {
        ScriptableUiSettings settings = GameSettingsSingleton.Settings.UiSettings;

        _notifWriteSpeed = settings.notificationSpeed;
        _notificationDuration = settings.notificationDuration;

        _notifText = transform.GetChild(0).GetComponent<Text>();
        _notifText.text = ""; 
    }

    public void DisplayNotification(string message)
    {
        if(!_crIsRunning)
        {
            _crIsRunning = true;
            //_messageQueue.Add(message);
            _messageQueue.Enqueue(message);
            StartCoroutine(UpdateNotificationText());
            //Debug.Log("cr running");
        }
        else
        {
            //_messageQueue.Add(message);
            _messageQueue.Enqueue(message);
        }
        
    }

    private IEnumerator UpdateNotificationText()
    {
        while(_messageQueue.Count>0)
        {
            //var messageText = _messageQueue[0];
            var messageText = _messageQueue.Dequeue();

            for(int i = 0; i < messageText.Length; i++)
            {
                //Debug.Log("text :" + _notifText.text);
                _notifText.text = _notifText.text + messageText[i];

                yield return new WaitForSeconds(_notifWriteSpeed);
            }

            yield return new WaitForSeconds(_notificationDuration);
            //_messageQueue.RemoveAt(0);
            _notifText.text = "";
        }

        _crIsRunning = false;
        
        yield return null;
    }
}