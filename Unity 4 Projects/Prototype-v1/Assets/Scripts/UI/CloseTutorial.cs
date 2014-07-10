using UnityEngine;
using System.Collections;

public class CloseTutorial : MonoBehaviour 
{
	public UIPanel _parentPanel;
	public MoveOnTrack _moveOnTrack;

	private void OnClick()
	{
		_parentPanel.alpha = 0.0f;

		TutorialPanelScript tutorialPanel = _parentPanel.GetComponent<TutorialPanelScript>();
		if(tutorialPanel != null)
		{
			tutorialPanel._uiController.DisplayHUD(true);
		}
		else
		{
			Debug.LogError("UiController could not be found!");
		}

		_moveOnTrack.TriggerPause(false);
	}
}
