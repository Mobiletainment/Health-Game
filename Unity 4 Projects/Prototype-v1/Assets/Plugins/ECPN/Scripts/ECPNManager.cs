using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class is responsible for polling device Token from either APSN (Apple) or Google Cloud Messaging Server and once it is received it is sent to the PHP server
 * and stored in the MySQL database
 * Users can later send messages to all registered devices
 * Only three methods should be called from outside the class:
 * 1) RequestDeviceToken() - Requests the current device Token from GCM or APSN and sends it to our server to be stored
 * 2) SendMessageToAll() - Sends a notification message to all server-registered devices
 * 3) RequestUnregisterDevice() - Request the current device Token to be removed from GCM or APSN and our own server
 * - (GetDevToken() is there for convenience of the sample scene)
 */
public class ECPNManager: MonoBehaviour {
	
	public string GoogleCloudMessageProjectID = "368000005971"; // Insert your Google Project ID
	public string phpFilesLocation = "http://your.ftp.server/ECPN"; // remote location of the PHP files
	public string packageName = "at.technikum.mgs.healthgame"; // name of your app bundle identifier
	private string devToken;
	private string username;
	
#if UNITY_ANDROID
	private AndroidJavaObject playerActivityContext;
#endif
	// PUBLIC METHODS //
	
	/* Only works in android and iOS devices
	 * Android: It calls a static method in our GCMRegistration class which polls the device Token from Google Services
	 * iOS: Uses Unity NotificationServices class to poll deviceToken -which we have to poll until found
	 */
	public void RequestDeviceToken() {
#if UNITY_EDITOR
	Debug.Log("You can only register iOS and android devices, not the editor!");
#endif
#if UNITY_ANDROID
		// Obtain unity context
        if(playerActivityContext == null) {
			AndroidJavaClass actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        	playerActivityContext = actClass.GetStatic<AndroidJavaObject>("currentActivity");
		}
		AndroidJavaClass jc = new AndroidJavaClass(packageName + ".GCMRegistration");
		jc.CallStatic("RegisterDevice", playerActivityContext, GoogleCloudMessageProjectID);
#endif
#if UNITY_IPHONE
		if(NotificationServices.deviceToken == null) {
			pollIOSDeviceToken = true;
			NotificationServices.RegisterForRemoteNotificationTypes(RemoteNotificationType.Alert | 
                                    RemoteNotificationType.Badge | 
                                    RemoteNotificationType.Sound);
		} else {
			RegisterIOSDevice();
		}
#endif
	}
	
	public void RequestUnregisterDevice() {
#if UNITY_EDITOR
	Debug.Log("You can only unregister iOS and android devices, not the editor!");
#endif
#if UNITY_IPHONE
		NotificationServices.UnregisterForRemoteNotifications();	
		StartCoroutine(DeleteDeviceFromServer(devToken));
#endif
#if UNITY_ANDROID
		// Obtain unity context
        if(playerActivityContext == null) {
			AndroidJavaClass actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        	playerActivityContext = actClass.GetStatic<AndroidJavaObject>("currentActivity");
		}
		AndroidJavaClass jc = new AndroidJavaClass(packageName + ".GCMRegistration");
		jc.CallStatic("UnregisterDevice",playerActivityContext);
#endif
	}
	
	/*
	 * Sends a notification to all server-registered devices
	 */
	public void SendMessageToAll() {
		StartCoroutine (SendECPNmessage());
	}
	
	/*
	 * Get the current device Token, if known (does not request it)
	 */
	public string GetDevToken() {
		return devToken;
	}
	
	public string GetUsername()
	{
		return username;
	}
	
	public void SetUsername(string username)
	{
		this.username = username;
	}
	
	// UNDER THE HOOD METHODS //
	
#if UNITY_IPHONE
	private bool pollIOSDeviceToken = false;

	
	void Update() {
		// Unity does not tell us when the deviceToken is ready, so we have to keep polling after requesting it
		if(pollIOSDeviceToken) RegisterIOSDevice();
	}
#endif
	
	// Called from Java class once the deviceToken is ready -should not be called manually
	public void RegisterAndroidDevice(string rID) {
		Debug.Log ("DeviceToken: " + rID);
		StartCoroutine(StoreDeviceID(rID,"android"));
	}
	// Called from Java class in response to Unregister event
	public void UnregisterDevice(string rID) {
		Debug.Log ("Unregister DeviceToken: " + rID);
		StartCoroutine(DeleteDeviceFromServer(rID));
	}
	
#if UNITY_IPHONE
	/*
	 * Poll NotificationServices for deviceToken for iOS device
	 * If found, send it to the server (StoreDeviceID)
	 */ 
	private void RegisterIOSDevice() {
		if(NotificationServices.registrationError != null) Debug.Log(NotificationServices.registrationError);
		if(NotificationServices.deviceToken == null) return;
		pollIOSDeviceToken = false;
		string hexToken = System.BitConverter.ToString(NotificationServices.deviceToken).Replace ("-",string.Empty);
		StartCoroutine(StoreDeviceID(hexToken,"ios"));
	}
#endif
	/*
	 * Sends store device Token request to server
	 */ 
	private IEnumerator StoreDeviceID(string rID, string os) {
		devToken = rID;
		int errorCode;
		WWWForm form = new WWWForm();
		form.AddField( "user", SystemInfo.deviceUniqueIdentifier );
		form.AddField( "OS", os);
		form.AddField("regID",devToken);
		form.AddField("username", username);
		WWW w = new WWW(phpFilesLocation + "/RegisterDeviceIDtoDB.php", form);
		yield return w;
		if (w.error != null) {
			errorCode = -1;
		} else {
			string formText = w.text; 
			w.Dispose();
			errorCode = int.Parse(formText);
		}
	}
	
	
	/*
	 * Sends notification message to all devices registered in the server
	 * It displays the number of messages sent (via Debug.Log)
	 */ 
	private IEnumerator SendECPNmessage() {
		// Send message to server with accName - devToken pair
		WWWForm form = new WWWForm();
		form.AddField("user", SystemInfo.deviceUniqueIdentifier );
		form.AddField("username", username);
		WWW w = new WWW(phpFilesLocation + "/SendECPNmessageAll.php", form);
		yield return w;
		if (w.error != null) {
			Debug.Log("Error while sending message to all: " + w.error);
		} else {
			string formText = w.text; 
			Debug.Log ( w.text);
			w.Dispose();
		}
	}
	/*
	 * Sends delete device Token request to server
	 */ 
	private IEnumerator DeleteDeviceFromServer(string rID) {
		int errorCode;
		WWWForm form = new WWWForm();
		form.AddField ("regID",rID);
		WWW w = new WWW(phpFilesLocation + "/UnregisterDeviceIDfromDB.php", form);
		yield return w;
		if (w.error != null) {
			errorCode = -1;
		} else {
			string formText = w.text; 
			w.Dispose();
			errorCode = int.Parse(formText);
			devToken = "";
		}
	}
	
}