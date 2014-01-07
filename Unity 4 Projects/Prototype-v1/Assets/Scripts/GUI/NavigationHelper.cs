﻿using UnityEngine;
using System.Collections;
using TestFlightUnity;

public class NavigationHelper : MonoBehaviour
{
    
    private UserManager userManager;
    public GameObject ParentMenu;
    private string flightTestTokenIOS = "6e59b120-3e9b-4c2c-aeed-ee41db24996a";
    private string flightTestTokenAndroid = "730dce34-dd87-40b3-bf4f-d6358b23d174";

    void OnEnable()
    {
        string flightTestToken;
        #if UNITY_ANDROID
        flightTestToken = flightTestTokenAndroid;
        #elif UNITY_IPHONE
        flightTestTokenIOS = flightTestTokenIOS;
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
        userManager.ResetDataOnNewVersionInstalled();

        if (userManager.IsLoggedIn())
        {
            Debug.Log("User is logged in");
            
            if (userManager.IsChild == true)
            {
                LoadGameScene();
            }
            else
                LoadParentMenu();
        }
    }
    
    void Start()
    {
        //LoadParentMenu();
    }
    
    public static void LoadGameScene()
    {
        Debug.Log("Loading Game Scene");
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Application.LoadLevel("TrackFlight");
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
