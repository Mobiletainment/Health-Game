using UnityEngine;
using System.Collections;

public class CloseTutorial : MonoBehaviour 
{
	public UIPanel _parentPanel;
	public MoveOnTrack _moveOnTrack;

	private void OnClick()
	{
		_parentPanel.alpha = 0.0f;
		_moveOnTrack.TriggerPause(false);
	}
}
