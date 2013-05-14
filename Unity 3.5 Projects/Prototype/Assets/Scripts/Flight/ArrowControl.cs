#if UNITY_IPHONE || UNITY_ANDROID
#	define MOBILE
#endif

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
		
		Color guiColor = guiTexture.color;
		guiColor.a = 0.25f;
		guiTexture.color = guiColor;
	}
	
	// Use this for initialization
	void Start () 
	{	
		
		guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool touchDown;
		bool touchUp;
		
#if MOBILE
		touchDown = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
		touchUp = Input.GetTouch(0).phase == TouchPhase.Ended;
#else
		touchDown = Input.GetMouseButtonDown(0);
		touchUp = Input.GetMouseButtonUp(0);
#endif
		
		if(touchDown) // Input.GetMouseButtonDown(0)
		{
			_mouseDown = true;
			guiTexture.enabled = true;
			
#if MOBILE
			Touch touch = Input.GetTouch(0);
			_mouseDownPosition = new Vector3(touch.position.x, touch.position.y, 0);
#else
			_mouseDownPosition = Input.mousePosition;
#endif
			
			float newPosX;
			
			if (_mouseDownPosition.x <= 0)
				newPosX = _mouseDownPosition.x = 0;
			else
				newPosX = _mouseDownPosition.x / Screen.width;
			
			float newPosY;
			
			if (_mouseDownPosition.y <= 0)
				newPosY = _mouseDownPosition.y = 0;
			else
				newPosY = (_mouseDownPosition.y - guiTexture.pixelInset.height * 0.5f + 22.0f) / Screen.height;
			
			
			transform.position = new Vector3(newPosX, newPosY, 0);
			
			_airCraft.EnableHUDControl(true);
		}
		else if(touchUp) // Input.GetMouseButtonUp(0)
		{
			_mouseDown = false;
			guiTexture.enabled = false;
			
			_airCraft.EnableHUDControl(false);
		}
		
		// Mouse is currently hold down:
		if(_mouseDown == true)
		{
			Vector3 curMousePos;
			
#if MOBILE
			Touch touch = Input.GetTouch(0);
			curMousePos = new Vector3(touch.position.x, touch.position.y, 0);
#else
			curMousePos = Input.mousePosition;
#endif
			
			// Figure out, how far away the current mouse position is from the first touch down:
			float diff = curMousePos.x - _mouseDownPosition.x;
			
			// 4 because: 50px is about one thumb-size -> *4 is 200 -> currently maximum rotation multiplicator.
			diff *= 4;
			
			_airCraft.SetHUDRotation(diff);
		}
	}
}
