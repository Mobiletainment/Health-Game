using UnityEngine;
using System.Collections;

public class LoadLevelSelectionScene : MonoBehaviour 
{
	void OnClick()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel("LevelSelection");
	}
}
