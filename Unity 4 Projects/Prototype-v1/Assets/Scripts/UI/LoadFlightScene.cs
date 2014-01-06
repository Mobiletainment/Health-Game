using UnityEngine;
using System.Collections;

public class LoadFlightScene : MonoBehaviour 
{
	// TODO: LevelPack in near future.
	public int _level = 0;

    void OnClick()
	{
		LevelManager.CurrentLevel = _level;

		Screen.orientation = ScreenOrientation.LandscapeLeft;
    	Application.LoadLevel("TrackFlight");
    }
}
