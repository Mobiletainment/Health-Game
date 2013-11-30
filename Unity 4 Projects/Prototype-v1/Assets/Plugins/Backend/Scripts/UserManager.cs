using UnityEngine;
using System;
using System.Collections;


[Serializable]
public class UserManager : ScriptableObject
{
	[SerializeField]
	public string GoogleCloudMessageProjectID = "368000005971"; // Insert your Google Project ID

	[SerializeField]
	public string phpFilesLocation = "http://www.pertiller.net/aqua/"; // remote location of the PHP files

	[SerializeField]
	public string packageName = "at.technikum.mgs.healthgame"; // name of your app bundle identifier

	public void OnEnable()
	{
		hideFlags = HideFlags.None;
	}

	[SerializeField]
	public string devToken;
	
	[SerializeField]
	public string username;

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
	}
	
	public void SetUserIsChild (bool isChild)
	{
		this.isChild = isChild;
	}
}
