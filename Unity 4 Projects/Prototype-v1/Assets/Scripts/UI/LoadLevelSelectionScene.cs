﻿using UnityEngine;
using System.Collections;

public class LoadLevelSelectionScene : MonoBehaviour 
{
	void OnClick()
	{
		Screen.orientation = ScreenOrientation.Landscape;
		Application.LoadLevel("LevelSelection");
	}
}
