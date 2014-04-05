using UnityEngine;
using System.Collections;

public class LoadMenuScene : MonoBehaviour
{
    void OnClick ()
    {
        Debug.Log("Level Completed! Sending Push Notification");
        ECPNManager ecpnManager = GameObject.Find("ComponentManager").GetComponent<ECPNManager>();
        ecpnManager.SendPushMessageToParent(ECPNManager.PushNotificationAction.LevelCompleted);
    	Application.LoadLevel("GameOver");
    }
}
