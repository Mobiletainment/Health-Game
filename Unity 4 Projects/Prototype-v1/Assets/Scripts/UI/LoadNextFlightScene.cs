using UnityEngine;
using System.Collections;

public class LoadNextFlightScene : MonoBehaviour {

    void OnClick ()
    {
		RulesSwitcher ruleSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();
		ruleSwitcher.LevelInfo.Level += 1;
    	Application.LoadLevel("PathFlight");
    }
}
