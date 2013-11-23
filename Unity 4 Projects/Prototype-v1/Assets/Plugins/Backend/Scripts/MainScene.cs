using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour
{
	
	private BackendManager backendManager;
	private string username = "";
	private string info = "";
	private bool isParent = false;
	private string usernameTextForChild = "Choose a Username:";
	private string usernameTextForParent = "Your child's Username:";
	
	void Start()
	{
		backendManager = FindObjectOfType(typeof(BackendManager)) as BackendManager;
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 140, 290), "Registration");
		
		isParent = GUI.Toggle(new Rect(200, 60, 200, 80), isParent, "I'm the parent");
		backendManager.SetUserIsChild(!isParent); //quick and dirty child/parent handling


		GUI.Label(new Rect(20, 40, 160, 20), isParent ? usernameTextForParent : usernameTextForChild);
		
		username = GUI.TextField(new Rect(20, 60, 120, 20), username, 25);
		backendManager.SetUsername(username); //quick and dirty setter
		
		if(GUI.Button(new Rect(20, 100, 120, 40), "Register device"))
		{
			if(string.IsNullOrEmpty(backendManager.GetUsername()))
				info = "Enter a Username first and then register again";
			else
			{
				info = "";
				backendManager.RequestDeviceToken();
			}
		}

		if(GUI.Button(new Rect(20, 140, 120, 40), "Send Broadcast"))
		{
			backendManager.SendMessage(false);
		}
		
		if(GUI.Button(new Rect(180, 140, 240, 40), "New: Send to Connected-Player only"))
		{
			backendManager.SendMessage(true);
		}
		
		if(GUI.Button(new Rect(20, 190, 120, 40), "Unregister device"))
		{
			backendManager.RequestUnregisterDevice();
		}
		if(GUI.Button(new Rect(20, 230, 120, 40), "Exit"))
		{
			Application.Quit();
		}
		string regID = backendManager.GetDevToken();
		GUI.Label(new Rect(10, 320, Screen.width, 60), "Registration ID: " + ((string.IsNullOrEmpty(regID)) ? "(Click on register device)" : regID));
		GUI.Label(new Rect(10, 360, Screen.width, 60), "Unity Identifier: " + SystemInfo.deviceUniqueIdentifier.ToString()); // This device ID is set by UNITY and has nothing to do with the registration ID that both iOS and GoogleCloudMessaging systems use
		GUI.Label(new Rect(10, 400, Screen.width, 60), "Username: " + username); // This device ID is set by UNITY and has nothing to do with the registration ID that both iOS and GoogleCloudMessaging systems use
		
		GUI.Label(new Rect(10, 440, Screen.width, 60), "Info: " + info);
		GUI.Label(new Rect(10, 460, Screen.width, 250), "Response: " + backendManager.GetResponse());
	}
}
