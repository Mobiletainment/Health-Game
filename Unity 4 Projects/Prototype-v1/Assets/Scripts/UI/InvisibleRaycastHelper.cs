using UnityEngine;
using System.Collections;

public class InvisibleRaycastHelper : MonoBehaviour 
{
	private UIPanel _target = null;
	private int _layer = 0;

	// Use this for initialization
	private void Start() 
	{
		_target = gameObject.GetComponent<UIPanel>();
		_layer = gameObject.layer;

		if(_target == null)
		{
			Debug.LogError("The InvisibleRaycastHelper Script must be added to an UIPanel Object.");
		}
	}
	
	// Update is called once per frame
	private void Update() 
	{
		if(_target.alpha == 0 && gameObject.layer != 2)
		{
			gameObject.layer = 2; // Ignore Raycast
		}
		else if(_target.alpha > 0 && gameObject.layer == 2)
		{
			gameObject.layer = _layer; // The original layer... (UI)
		}
	}
}
