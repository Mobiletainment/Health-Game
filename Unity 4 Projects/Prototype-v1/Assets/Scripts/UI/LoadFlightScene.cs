using UnityEngine;
using System.Collections;

public class LoadFlightScene : MonoBehaviour {

    void OnClick ()
    {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
    	Application.LoadLevel("TrackFlight");
    }
}
