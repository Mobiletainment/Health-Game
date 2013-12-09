using UnityEngine;
using System.Collections;

public class NavigationHelper : MonoBehaviour {
    
    public UserManager userManager;
    public GameObject ParentMenu;
    
    void OnEnable()
    {
        userManager = UserManager.Instance;
        
        //userManager.ResetData(); //uncomment this to start from the beginning and not load the game directly on startup
        
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
    
    public static bool IsDummyUser(string user)
    {
        return GetDummyUsername().CompareTo(user) == 0;
    }
}
