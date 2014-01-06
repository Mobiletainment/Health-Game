using UnityEngine;
using System.Collections;

public class LoadNextFlightScene : MonoBehaviour 
{
	// TODO: Clean up later... This is just to prevent the "level n + 1" error...
	public LevelManager _levelManager;

    void OnClick ()
    {
//		RulesSwitcher ruleSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();
//		ruleSwitcher.LevelInfo.Level += 1;
		LevelManager.CurrentLevel = (LevelManager.CurrentLevel + 1) % _levelManager.Levels.Length;
		
    	Application.LoadLevel("TrackFlight");
    }
}
