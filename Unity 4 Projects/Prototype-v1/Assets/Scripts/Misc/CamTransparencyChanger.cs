using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CamTransparencyChanger : MonoBehaviour 
{
	TransparencySortMode _transparencySort = TransparencySortMode.Orthographic;

	public void Awake() 
	{
		Camera.main.transparencySortMode = _transparencySort;
		Debug.Log("Changed Main Camera Transpacency Sort to " + TransparencySortMode.Orthographic + ".", Camera.main);
	}
}
