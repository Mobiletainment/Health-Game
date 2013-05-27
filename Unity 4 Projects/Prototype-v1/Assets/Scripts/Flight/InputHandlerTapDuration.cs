#if UNITY_IPHONE || UNITY_ANDROID
#	define MOBILE
#endif

using UnityEngine;
using System.Collections;

public class InputHandlerTapDuration : MonoBehaviour {
	
	public float _sensitivity = 200.0f;
	protected Aircraft _airCraft;
	protected bool _mouseDown = false;
	
	// Use this for initialization
	void Start ()
	{
		_airCraft = GetComponent<Aircraft>();
		_airCraft.EnableHUDControl(true); //<-- needs refactoring, code which should be encapsulated in class ArrowControl 
		Debug.Log(_airCraft);
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool touchDown = false;
		bool touchUp = true;
		
#if MOBILE
		if (Input.touchCount > 0)
		{
			Touch lastTouch = Input.GetTouch(Input.touchCount - 1); //we're only interested in the last touch
			touchDown = lastTouch.phase == TouchPhase.Began;
			touchUp = lastTouch.phase == TouchPhase.Ended || lastTouch.phase == TouchPhase.Canceled;
		}
#else
		touchDown = Input.GetMouseButtonDown(0);
		touchUp = Input.GetMouseButtonUp(0);
#endif
		
		if(touchUp)
		{
			_mouseDown = false;
			_airCraft.SetHUDRotation(0.0f);
		}
		
		if(touchDown) // no else-if-branch, because it could be that the player released a finger while the other one is still tapping or so
		{
			_mouseDown = true;
			float touchPos;
			
#if MOBILE
			Touch touch = Input.GetTouch(Input.touchCount - 1);
			touchPos = touch.position.x;
#else
			touchPos = Input.mousePosition.x;
#endif
			
			
			float rotationDirection = touchPos < Screen.width * 0.5f ? -1 : 1;
			Debug.Log("Touch at: " + touchPos + "; Rotation: " + _sensitivity*rotationDirection);
			_airCraft.SetHUDRotation(_sensitivity * rotationDirection);
		
		}
	}
}
