using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour {
	
	private bool _mouseDown = false;
	private Vector3 _mouseDownPosition;
	
	public Aircraft _airCraft;
	
	void Awake()
	{
		if(_airCraft == null)
		{
			Debug.LogError("Error: No Aircraft has been set!");	
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			_mouseDown = true;
			guiTexture.enabled = true;
			_mouseDownPosition = Input.mousePosition;
			
			float newPosX;
			
			if (_mouseDownPosition.x <= 0)
				newPosX = _mouseDownPosition.x = 0;
			else
				newPosX = _mouseDownPosition.x / Screen.width;
			
			float newPosY;
			
			if (_mouseDownPosition.y <= 0)
				newPosY = _mouseDownPosition.y = 0;
			else
				newPosY = (_mouseDownPosition.y - guiTexture.pixelInset.height * 0.5f) / Screen.height;
			
			
			transform.position = new Vector3(newPosX, newPosY, 0);
			
			_airCraft.EnableHUDControl(true);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			_mouseDown = false;
			guiTexture.enabled = false;
			
			_airCraft.EnableHUDControl(false);
		}
		
		// Mouse is currently hold down:
		if(_mouseDown == true)
		{
			// Figure out, how far away the current mouse position is from the first touch down:
			float diff = Input.mousePosition.x - _mouseDownPosition.x;
			Debug.Log(diff);
			
			diff *= 4;
			
			_airCraft.SetHUDRotation(diff);
		}
	}
}
