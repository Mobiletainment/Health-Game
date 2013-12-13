using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class UserManager : MonoBehaviour
{
    private static UserManager instance;
    public static float Version = 1.13f;

    public static UserManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("ComponentManager").GetComponent<UserManager>();
                
                if (instance == null)
                {
                    Debug.LogError("No UserManager Component attached to ComponentManager! Error creating UserManager Singleton");
                }
                else
                {
                    Instance.username = PlayerPrefs.GetString("username");
                    Instance.isChild = Convert.ToBoolean(PlayerPrefs.GetInt("isChild"));
                    Instance.devToken = PlayerPrefs.GetString("devToken");
                    
                    Debug.Log(String.Format("Getting UserData OnEnable: User={0}, isChild={1}, devToken={2}", Instance.username, Instance.isChild, Instance.devToken));
                }
                
            }
            
            return instance;
        }
    }

    void Awake()
    {
        instance = UserManager.Instance;
    }
        
    [SerializeField]
    public string
        GoogleCloudMessageProjectID = "368000005971"; // Insert your Google Project ID

    [SerializeField]
    private string
        phpFilesLocation = "http://tnix.eu/~aspace/"; // remote location of the PHP files

    public string GetServerPath()
    {
        return phpFilesLocation;
    }

    [SerializeField]
    public string
        packageName = "at.technikum.mgs.healthgame"; // name of your app bundle identifier

    [SerializeField]
    private string
        devToken;
    [SerializeField]
    private string
        username;
    [SerializeField]
    private bool
        isChild = true;
    
    public bool IsChild
    {
        get
        {
            return Instance.isChild;
        }
        set
        {
            Instance.isChild = value;
            PlayerPrefs.SetInt("isChild", Convert.ToInt32(value));
        }
    }

    /*
     * Get the current device Token, if known (does not request it)
     */
    public string GetDevToken()
    {
        return Instance.devToken;
    }
    
    public string GetUsername()
    {
        return Instance.username;
    }
    
    public void SetUsername(string username)
    {
        Instance.username = username;
        PlayerPrefs.SetString("username", username);
    }

    public void SetDevToken(string devToken)
    {
        Instance.devToken = devToken;
        PlayerPrefs.SetString("devToken", devToken);
    }

    public bool IsLoggedIn()
    {
        return !string.IsNullOrEmpty(GetUsername()) && !string.IsNullOrEmpty(GetDevToken());
    }

    public void ResetData()
    {
        Debug.Log("Caution: Deleting User Data");
        SetDevToken("");
        SetUsername("");
        IsChild = false;
    }

    public void ResetDataOnNewVersionInstalled()
    {
        float oldVersion = PlayerPrefs.GetFloat("version", 0.0f);

        if (oldVersion < Version)
        {
            Debug.Log("New Version installed, deleting old User Data");
            ResetData();
            PlayerPrefs.SetFloat("version", Version);
        }
    }
    
}
