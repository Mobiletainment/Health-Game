using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {
	
	private ECPNManager ecpnManager;
	
	void Start () {
		ecpnManager = FindObjectOfType(typeof(ECPNManager)) as ECPNManager;
	}
	
	void OnGUI () {
		GUI.Box(new Rect(10,10,140,250), "ECPN options");

		if(GUI.Button(new Rect(20,40,120,40), "Register device")) {
			ecpnManager.RequestDeviceToken();
		}

		if(GUI.Button(new Rect(20,90,120,40), "Send Message")) {
			ecpnManager.SendMessageToAll();
		}
		if(GUI.Button(new Rect(20,140,120,40), "Unregister device")) {
			ecpnManager.RequestUnregisterDevice();
		}
		if(GUI.Button(new Rect(20,190,120,40), "Exit")) {
			Application.Quit();
		}
		string regID = ecpnManager.GetDevToken();
		GUI.Label(new Rect(10,260,Screen.width,60),"Registration ID: " + ((string.IsNullOrEmpty(regID)) ? "(Click on register device)" : regID));
		GUI.Label(new Rect(10,340,Screen.width,60),"Unity Identifier: " + SystemInfo.deviceUniqueIdentifier.ToString ()); // This device ID is set by UNITY and has nothing to do with the registration ID that both iOS and GoogleCloudMessaging systems use
	}
}
