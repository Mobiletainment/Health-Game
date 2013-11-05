using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {
	
	private ECPNManager ecpnManager;
	private string username = "";
	private string info = "";
	
	void Start () {
		ecpnManager = FindObjectOfType(typeof(ECPNManager)) as ECPNManager;
	}
	
	void OnGUI () {
		GUI.Box(new Rect(10,10,140,290), "Server Registration");
		
		GUI.Label(new Rect(20,40, 120, 20),"Username:");
		
		username = GUI.TextField (new Rect (20, 60, 120, 20), username, 25);
		ecpnManager.SetUsername(username); //quick and dirty setter
		
		if(GUI.Button(new Rect(20,100,120,40), "Register device")) {
			if (string.IsNullOrEmpty(ecpnManager.GetUsername()))
				info = "Enter a Username first and then register again";
			else
			{
				info = "";
				ecpnManager.RequestDeviceToken();
			}
		}

		if(GUI.Button(new Rect(20,140,120,40), "Send Message")) {
			ecpnManager.SendMessageToAll();
		}
		if(GUI.Button(new Rect(20,190,120,40), "Unregister device")) {
			ecpnManager.RequestUnregisterDevice();
		}
		if(GUI.Button(new Rect(20,230,120,40), "Exit")) {
			Application.Quit();
		}
		string regID = ecpnManager.GetDevToken();
		GUI.Label(new Rect(10,320,Screen.width,60),"Registration ID: " + ((string.IsNullOrEmpty(regID)) ? "(Click on register device)" : regID));
		GUI.Label(new Rect(10,360,Screen.width,60),"Unity Identifier: " + SystemInfo.deviceUniqueIdentifier.ToString ()); // This device ID is set by UNITY and has nothing to do with the registration ID that both iOS and GoogleCloudMessaging systems use
		GUI.Label(new Rect(10,400,Screen.width,60),"Username: " + username); // This device ID is set by UNITY and has nothing to do with the registration ID that both iOS and GoogleCloudMessaging systems use
		
		GUI.Label(new Rect(10,440,Screen.width,60),"Info: " + info);	
	}
}
