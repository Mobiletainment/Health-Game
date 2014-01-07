using UnityEngine;
using System.Collections;

public class LoadTutorialScene : MonoBehaviour 
{
	void OnClick()
	{
		Screen.orientation = ScreenOrientation.Landscape;
		Application.LoadLevel("Tutorial");
	}
}
