using UnityEngine;
using System.Collections;

public class LevelManagerManipulator : MonoBehaviour 
{
	public int curLevel = 0;
	// THIS IS FOR DEMO ONLY! DELETE THIS!
	void Awake () {
		LevelManager.CurrentLevel = curLevel;
	}
}
