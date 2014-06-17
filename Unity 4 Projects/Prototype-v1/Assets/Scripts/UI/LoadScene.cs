using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour 
{
	public string scene;

	void OnClick()
	{
		if(scene == null)
			Debug.LogError("Error: No Scene has been set!");

		Application.LoadLevel(scene);
	}
}
