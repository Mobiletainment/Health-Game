// Disable "Unused Variable" Warning for this Script. (Because one of them is always unused, Android- or iOS-Token.)
#pragma warning disable 0414
using UnityEngine;
using System.Collections;
using TestFlightUnity;

public class NavigationHelper : MonoBehaviour
{
    
    private UserManager userManager;
    public GameObject ParentMenu;
    public GameObject ChildFinishRegistration;
    private string flightTestTokenIOS = "6e59b120-3e9b-4c2c-aeed-ee41db24996a";
    private string flightTestTokenAndroid = "730dce34-dd87-40b3-bf4f-d6358b23d174";

    void OnEnable()
    {
        string flightTestToken;
        #if UNITY_ANDROID
        flightTestToken = flightTestTokenAndroid;
        #else
        flightTestToken = flightTestTokenIOS;
        #endif

        if (string.IsNullOrEmpty(flightTestToken))
        {
            Debug.LogError("Please set your TestFlight SDK token in the editor.");
        }
        if (Debug.isDebugBuild)
        {
            // Must be called before TakeOff.
            TestFlight.SetDeviceID();
        }
        
        // Set some information for the session
        TestFlight.AddCustomEnvironmentInformation("Unity Version", Application.unityVersion);
        TestFlight.AddCustomEnvironmentInformation("System Language", Application.systemLanguage.ToString());
        
        // Start the session
        TestFlight.TakeOff(flightTestToken);

#if UNITY_ANDROID
        TestFlight.Log( "Starting AquaSpace Android" );
#elif UNITY_IPHONE
        TestFlight.Log( "Starting AquaSpace iOS" );
#endif
        userManager = UserManager.Instance;
        
        //userManager.ResetData(); //uncomment this to start from the beginning and not load the game directly on startup
        float currentVersion = float.Parse(new TrackedBundleVersion().current.version);
        Debug.Log("Current Version: " + currentVersion + ", Previously installed: " + userManager.GetVersion());

        userManager.SetVersion(currentVersion, true); //true = Resest UserData when new version is installed

    }
    
    void Start()
    {
        //LoadParentMenu();

		if (userManager.LoginState == UserManager.Authentication.LoggedIn)
		{
            Debug.Log("User is logged in");
            TestFlight.PassCheckpoint("Known User");
            ShowMainMenu();
        }
        else if (userManager.LoginState == UserManager.Authentication.Registered)
        {
			NGUITools.SetActive(MenuStack.Instance._panels.Peek(), true);
			LoadChildFinishRegistration();
		}
		else // UserManager.Authentication.NotLoggedIn
		{
			Debug.Log(MenuStack.Instance._panels.Peek());
			NGUITools.SetActive(MenuStack.Instance._panels.Peek(), true);
		}
    }
    
    public static void ShowMainMenu()
    {
		// Quick Test for sending push notification to parent when game is opened
		//UserManager.Instance.SetUsername("Dav3");
		//var ecpnManager = GameObject.Find("ComponentManager").GetComponent<ECPNManager>();
		//ecpnManager.SendPushMessageToParent(ECPNManager.PushNotificationAction.LevelCompleted);
        Debug.Log("Showing Main Menu");
//        Screen.orientation = ScreenOrientation.LandscapeLeft;
//        Application.LoadLevel("TrackFlight");
		GameObject[] tagArray = GameObject.FindGameObjectsWithTag("MainMenu");
		if(tagArray.Length > 0)
		{
			UIPanel mainMenu = tagArray[0].GetComponent<UIPanel>();
			if(mainMenu != null)
			{
				mainMenu.alpha = 1.0f;
			}
			else
			{
				Debug.LogError("Error: The as \"MainMenu\" tagged GameObject is not a UIPanel!");
			}
		}
		else
		{
			Debug.LogError("Error: No MainMenu tagged UIPanel could be found!");
		}

    }
  
    public void LoadChildFinishRegistration()
    {
        //in case the child registered but its parent didn't complete the registration, bring the child back to the registration screen
        MenuStack menuStack = MenuStack.Instance;
        UIInput action = ChildFinishRegistration.transform.FindChild("InputName").GetComponent<UIInput>();
        action.value = userManager.GetUsername();
        menuStack._start = ChildFinishRegistration;
    }
    
    public void LoadParentMenu()
    {
        MenuStack menuStack = MenuStack.Instance;
        Debug.Log("MenuStack: " + menuStack);
        menuStack._start = ParentMenu;
    }
    
    public static string GetDummyUsername()
    {
        return "test";
    }

    public static string GetDummyUsername2()
    {
        return "Test";
    }
    
    public static bool IsDummyUser(string user)
    {
        return GetDummyUsername().CompareTo(user) == 0 || GetDummyUsername2().CompareTo(user) == 0;
    }
}
