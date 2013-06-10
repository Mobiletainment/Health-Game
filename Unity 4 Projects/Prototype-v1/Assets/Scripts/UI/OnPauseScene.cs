using UnityEngine;
using System.Collections;

public class OnPauseScene : MonoBehaviour
{
	void Awake()
	{
		Debug.Log("Pause Button awake");
	}
	
	void OnClick ()
    {
		Debug.Log("Pause");
    	Application.LoadLevel("GameOver");
    }
}
