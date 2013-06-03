using UnityEngine;
using System.Collections;

public class OnPauseScene : MonoBehaviour {

void OnClick ()
    {
		Debug.Log("Pause");
    	Application.LoadLevel("GameOver");
    }
}
