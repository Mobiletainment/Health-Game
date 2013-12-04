using UnityEngine;
using System;
using System.Collections;


[Serializable]
public class UserManager : ScriptableObject
{
	[SerializeField]
	public string GoogleCloudMessageProjectID = "368000005971"; // Insert your Google Project ID

	[SerializeField]
	private string phpFilesLocation = "http://tnix.eu/~aspace/"; // remote location of the PHP files

	public string GetServerPath()
	{
		return phpFilesLocation;
	}

	[SerializeField]
	public string packageName = "at.technikum.mgs.healthgame"; // name of your app bundle identifier

	public void OnEnable()
	{
		Debug.Log("Getting UserData");
		hideFlags = HideFlags.None;

		username = PlayerPrefs.GetString("username");
		isChild = Convert.ToBoolean(PlayerPrefs.GetInt("isChild"));
		devToken = PlayerPrefs.GetString("devToken");
	}

	[SerializeField]
	private string devToken;
	
	[SerializeField]
	private string username;

	[SerializeField]
	private bool isChild = true;
	
	public bool IsChild
	{
		get
		{
			return isChild;
		}
		set
		{
			isChild = value;
			PlayerPrefs.SetInt("isChild", Convert.ToInt32(isChild));
		}
	}

	/*
	 * Get the current device Token, if known (does not request it)
	 */
	public string GetDevToken ()
	{
		return devToken;
	}
	
	public string GetUsername ()
	{
		return username;
	}
	
	public void SetUsername (string username)
	{
		this.username = username;
		PlayerPrefs.SetString("username", username);
	}

	public void SetDevToken (string devToken)
	{
		this.devToken = devToken;
		PlayerPrefs.SetString("devToken", devToken);
	}
	
}
