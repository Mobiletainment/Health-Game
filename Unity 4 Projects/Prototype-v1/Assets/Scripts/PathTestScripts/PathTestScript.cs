using UnityEngine;
using System.Collections;

public class PathTestScript : MonoBehaviour {
	
	float count = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		//iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("TestPath"), "easetype", iTween.EaseType.linear, "speed", 5));
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(count > 1.0f)
			count = 0.0f;
		
		Vector3 pos = iTween.PointOnPath(iTweenPath.GetPath("TestPath"), count);
		count += 0.01f;
		
		transform.position = pos;
	}
}
