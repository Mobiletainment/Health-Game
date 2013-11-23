using UnityEngine;
using System.Collections;

public class SwitchK2K3 : MonoBehaviour {

	public GameObject currentPanelObject;
    public GameObject nextPanelObject;
		
	public UIInput input;
	public UILabel label;
	public UIInput inputPW;
	public UILabel errorMessage;

	private BackendManager backendManager;

    void OnClick()
	{
		//Child has entered a username -> Register with server
		backendManager.SetUserIsChild(true); //child/parent handling
		backendManager.SetUsername(NGUIText.StripSymbols(input.value));
		backendManager.RequestDeviceToken();
		
		StartCoroutine("RegisterUser");
    }

	private IEnumerator RegisterUser()
	{
		while(string.IsNullOrEmpty(backendManager.GetResponse()))
		{
			//response not arrived yet, wait for it
			yield return new WaitForSeconds(0.2f);
		}

			//got the response
			if (backendManager.GetResponse().StartsWith("Success!"))
			{
				//everything is fine, move to next screen
				NGUITools.SetActive(nextPanelObject, true);
				NGUITools.SetActive(currentPanelObject, false);
				label.text="Hallo, " + backendManager.GetUsername() + "!\n"+ "Dein Benutzername " + backendManager.GetUsername() + " ist zugleich das Passwort für deine Eltern.";
			}
			else
			{
				Debug.Log("Error");
				//Display Error
				errorMessage.text = backendManager.GetResponse();
			}

	}
	
	void Start()
	{
		backendManager = FindObjectOfType(typeof(BackendManager)) as BackendManager; //get reference to Server-Communication GameObject
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
