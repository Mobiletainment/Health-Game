using UnityEngine;
using System.Collections;

public class MoveAvatarTouch : MonoBehaviour 
{
	public enum Side
	{
		LEFT,
		RIGHT
	}

	public Side _side;
	public MoveOnTrack _moveOnTrack;
	public Camera _uiCam;

	private bool _switchSide = false;
	private bool _mouseUp = true;

	private void OnGUI()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = _uiCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100.0f))
			{
				if(hit.collider == collider)
				{
					_switchSide = true;
					_mouseUp = false;
				}
			}
		}
		else if(Input.GetMouseButtonUp(0))
		{
			_mouseUp = true;
		}
	}

	private void Update()
	{
		if(_switchSide)
		{
			SwitchSide();
		}

		if(_mouseUp == true && _switchSide == true)
		{
			_switchSide = false;
		}
	}

	private void SwitchSide() 
	{
		if(_side == Side.LEFT)
		{
			_moveOnTrack.GiveLeftInput();
		}
		else
		{
			_moveOnTrack.GiveRightInput();
		}
	}
}
