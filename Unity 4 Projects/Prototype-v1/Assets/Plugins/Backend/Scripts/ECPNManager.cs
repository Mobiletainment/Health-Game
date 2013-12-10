using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;

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

[System.Serializable]
public class ECPNManager: MonoBehaviour
{
    public UserManager UserManager
    {
        get
        {
            return UserManager.Instance;
        }
    }

    public string GetUsername()
    {
        return UserManager.GetUsername();
    }

    public void RegisterUser(string username, bool isChild)
    {
        //callback ("RegisterUser");
        UserManager.IsChild = isChild; //child/parent handlingSSL: unable to obtain common name from peer certificate
        UserManager.SetUsername(username);
        RequestDeviceToken();
    }

    void Start()
    {
        ServicePointManager.ServerCertificateValidationCallback = Validator;

    }

    public static void Instate()
    {
        ServicePointManager.ServerCertificateValidationCallback = Validator;
    }

    public static bool Validator
    (
        object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors policyErrors)
    {
        
        //*** Just accept and move on...
        Debug.Log("Validation successful!");
        return true;
    }


#if UNITY_ANDROID
    private AndroidJavaObject playerActivityContext;
#endif
    // PUBLIC METHODS //
    
    /* Only works in android and iOS devices
     * Android: It calls a static method in our GCMRegistration class which polls the device Token from Google Services
     * iOS: Uses Unity NotificationServices class to poll deviceToken -which we have to poll until found
     */
    public void RequestDeviceToken()
    {

#if UNITY_ANDROID
        StartCoroutine(StoreDeviceID(SystemInfo.deviceUniqueIdentifier,"android"));
        /*
        // Obtain unity context
        //callback("RequestDeviceToken1");
        if(playerActivityContext == null) {
            //callback("RequestDeviceToken2");
            AndroidJavaClass actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            //callback("RequestDeviceToken3");
            playerActivityContext = actClass.GetStatic<AndroidJavaObject>("currentActivity");
            //callback("RequestDeviceToken4");
        }
        AndroidJavaClass jc = new AndroidJavaClass(UserManager.packageName + ".GCMRegistration");
        //callback("RequestDeviceToken5");
        jc.CallStatic("RegisterDevice", playerActivityContext, UserManager.GoogleCloudMessageProjectID);
        //callback("RequestDeviceToken6");
        */
#elif UNITY_IPHONE
        if(NotificationServices.deviceToken == null) {
            pollIOSDeviceToken = true;
            NotificationServices.RegisterForRemoteNotificationTypes(RemoteNotificationType.Alert | 
                                                                    RemoteNotificationType.Badge | 
                                                                    RemoteNotificationType.Sound);
        } else {
            RegisterIOSDevice();
        }
#else
        Debug.Log("You should only register iOS and android devices, not the editor!");
        StartCoroutine(StoreDeviceID(SystemInfo.deviceUniqueIdentifier,"editor"));
        #endif
    }
    
    public void RequestUnregisterDevice()
    {
        #if UNITY_EDITOR
        Debug.Log("You can only unregister iOS and android devices, not the editor!");
        #endif
        #if UNITY_IPHONE
        NotificationServices.UnregisterForRemoteNotifications();    
        StartCoroutine(DeleteDeviceFromServer(UserManager.GetDevToken()));
        #endif
        #if UNITY_ANDROID && !UNITY_EDITOR
        // Obtain unity context
        if(playerActivityContext == null) {
            AndroidJavaClass actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            playerActivityContext = actClass.GetStatic<AndroidJavaObject>("currentActivity");
        }
        AndroidJavaClass jc = new AndroidJavaClass(UserManager.packageName + ".GCMRegistration");
        jc.CallStatic("UnregisterDevice",playerActivityContext);
        #endif
    }

    /*
     * Sends a notification to all server-registered devices
     */
    public void SendPushMessage(string message)
    {
        StartCoroutine(SendECPNmessage(message));
    }
    
    
        
    
    #if UNITY_IPHONE
    private bool pollIOSDeviceToken = false;
    
    
    void Update() {
        // Unity does not tell us when the deviceToken is ready, so we have to keep polling after requesting it
        if(pollIOSDeviceToken) RegisterIOSDevice();
    }
    #endif
    
    // Called from Java class once the deviceToken is ready -should not be called manually
    public  void RegisterAndroidDevice(string rID)
    {
        //callback("Register Android Device");
        Debug.Log("DeviceToken: " + rID);
        StartCoroutine(StoreDeviceID(rID, "android"));
                
    }
    // Called from Java class in response to Unregister event
    public void UnregisterDevice(string rID)
    {
        Debug.Log("Unregister DeviceToken: " + rID);
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
    private IEnumerator StoreDeviceID(string rID, string os)
    {
        UserManager.SetDevToken(rID);
        WWWForm form = CreateDefaultForm();
        AddFormField(form, "OS", os);

        WWW w = CreateWebRequest("RegisterDeviceIDtoDB.php", form);
        yield return w;

        HandleResponse(w);
    }
    
    
    /*
     * Sends notification message to all devices registered in the server
     * It displays the number of messages sent (via Debug.Log)
     */ 
    private IEnumerator SendECPNmessage(string message)
    {
        // Send message to server with accName - devToken pair
        WWWForm form = CreateDefaultForm();
        AddFormField(form, "message", message);

        string targetAddress = "SendECPNmessageTargeted.php";
        
        WWW w = CreateWebRequest(targetAddress, form);
        yield return w;
        
        HandleResponse(w);
    }

    private IEnumerator SendECPNmessageBroadcast(string message)
    {
        // Send message to server with accName - devToken pair
        WWWForm form = CreateDefaultForm();
        
        string targetAddress = "SendECPNmessageAll.php";
        
        WWW w = CreateWebRequest(targetAddress, form);
        yield return w;
        
        HandleResponse(w);
    }

    public void CheckIfParentAndChildAreRegistered()
    {
        StartCoroutine(CheckIfParentAndChildAreRegisteredServer());
    }

    /*
     * Checks if both Parent and Child have registered
     */ 
    private IEnumerator CheckIfParentAndChildAreRegisteredServer()
    {
        Debug.Log("Checking Registration Completion");
        // Send message to server with accName - devToken pair
        WWWForm form = CreateDefaultForm();
        
        string targetAddress = "CheckIfParentAndChildAreRegistered.php";
        
        WWW w = CreateWebRequest(targetAddress, form);
        yield return w;
        
        HandleResponse(w);
    }

    /*
     * Sends delete device Token request to server
     */ 
    private IEnumerator DeleteDeviceFromServer(string rID)
    {
        WWWForm form = CreateDefaultForm();
        AddFormField(form, "regID", rID);
        WWW w = CreateWebRequest("UnregisterDeviceIDfromDB.php", form);
        yield return w;

        if (w.error == null)
        {
            UserManager.SetDevToken("");

        }

        HandleResponse(w);
    }

    public void SendCheckboxFeedbackToServer(string screenName, IList<bool> checkboxFeedback, string customFeedback)
    {
        StartCoroutine(SendCheckboxFeedback(screenName, checkboxFeedback, customFeedback));
    }

    public delegate void Delegate(string response);
    
    private Delegate callback;

    public Delegate Callback
    {
        get { return callback;}
        set { callback = value; }
    }
    
    public IEnumerator SendCheckboxFeedback(string screenName, IList<bool> checkboxFeedback, string customFeedback)
    {
        Debug.Log("Sending Feedback");
        string response = "";
        
        // Send message to server
        WWWForm form = CreateDefaultForm();

        Debug.Log(screenName);
        Debug.Log(EncodeField(screenName));
        AddFormField(form, "screenName", screenName);
        StringBuilder checkboxValues = new StringBuilder();
        
        foreach (bool check in checkboxFeedback)
        {
            checkboxValues.Append(check.ToString());
            checkboxValues.Append(',');
        }
        
        checkboxValues.Length--; // remove last ","
        
        AddFormField(form, "checkboxFeedback", checkboxValues.ToString());
        AddFormField(form, "customFeedback", customFeedback);
        AddFormField(form, "totalCheckboxes", checkboxFeedback.Count.ToString());
        
        string targetAddress = "CheckboxFeedback.php";
        
        WWW w = CreateWebRequest(targetAddress, form);
        yield return w;
        
        HandleResponse(w);
    }

    WWWForm CreateDefaultForm()
    {
        WWWForm form = new WWWForm();

        AddFormField(form, "user", SystemInfo.deviceUniqueIdentifier);
        AddFormField(form, "regID", UserManager.GetDevToken());
        AddFormField(form, "username", UserManager.GetUsername());
        AddFormField(form, "isChild", UserManager.IsChild.ToString());

        return form;
    }

    public void AddFormField(WWWForm form, string name, string field)
    {
        form.AddField(name, EncodeField((field)));
    }

    protected string EncodeField(string field)
    {
        byte[] bytesToEncode = Encoding.UTF8.GetBytes(field);
        string encodedText = Convert.ToBase64String(bytesToEncode);
        return encodedText;
    }
    
    WWW CreateWebRequest(string targetAddress, WWWForm form)
    {
        string location = UserManager.GetServerPath() + targetAddress;
        WWW w = new WWW(location, form);

        Debug.Log("Web request to location: " + location);
        return w;
    }

    void HandleResponse(WWW w)
    {
        if (w.error != null)
        {
            string errorMessage = w.error;
            w.Dispose();
            callback("Error: " + errorMessage);
        }
        else
        {
            string response = w.text;
            w.Dispose();
            callback(response);
        }


    }
}