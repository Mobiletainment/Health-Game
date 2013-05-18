#if UNITY_IPHONE || UNITY_ANDROID
#	define MOBILE
#endif

#define nussi_move_idea
using UnityEngine;
using System.Collections;


public class ArrowControl : MonoBehaviour {
	
	private bool _mouseDown = false;
	private Vector3 _mouseDownPosition;
	
	public Aircraft _airCraft;
	
	private float _drawArrorPosX;
	private float _drawArrorPosY;
	
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
		touchUp = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
#else
		touchDown = Input.GetMouseButtonDown(0);
		touchUp = Input.GetMouseButtonUp(0);
#endif
		
		// This is only called once per click / tap:
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
			
			if (_mouseDownPosition.x <= 0)
				_drawArrorPosX = _mouseDownPosition.x = 0;
			else
				_drawArrorPosX = _mouseDownPosition.x / Screen.width;
			
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
			
			// Use current y position for Arrow:
			if (curMousePos.y <= 0)
				_drawArrorPosY = curMousePos.y = 0;
			else
				_drawArrorPosY = (curMousePos.y - guiTexture.pixelInset.height * 0.5f + 22.0f) / Screen.height;
			
			// Set the arrow graphic on the current finger position (with static x pos from first tap)
			// So that it slides up and down with the finger, but not left and right...
			transform.position = new Vector3(_drawArrorPosX, _drawArrorPosY, 0);
			
			
			// Figure out, how far away the current mouse position is from the first touch down:
			float diff = curMousePos.x - _mouseDownPosition.x;
			

			float diffRelative = diff / Screen.width;
			Debug.Log(diffRelative);
			//Debug.Log("DPI: " + Screen.dpi + ", Screen Width: " + Screen.width);
			
			// 4 because: 50px is about one thumb-size -> *4 is 200 -> currently maximum rotation multiplicator.
			
			// Note: use 0.128 & *8 for Tablet.
			// Note: use 0.25 & *4 for MobilePhone.
			// 25% movement of the screen width equal full 200 rotation 
			diffRelative = Mathf.Clamp (diffRelative, -0.25f, 0.25f); 
			
			float diffRotation = (diffRelative*4) * 200;
			
			
			_airCraft.SetHUDRotation(diffRotation);
			
#if nussi_move_idea
			//add fration of the differnce to reduce roation over time
			_mouseDownPosition.x+=diff/30.0f;
			//copied here to recalulate the positon (is the wrone place but did not want to change to much code
			if (_mouseDownPosition.x <= 0)
				_drawArrorPosX = _mouseDownPosition.x = 0;
			else
				_drawArrorPosX = _mouseDownPosition.x / Screen.width;
#endif
		}
	}
}
