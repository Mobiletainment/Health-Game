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

	private void OnClick() 
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
