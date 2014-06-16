using UnityEngine;
using System.Collections;

public class TrackTutorial : MonoBehaviour 
{
	public TutorialTextManager _tutTextManager;
	public int  _tutTextID;

	private bool _tutTriggered = false;

	public void OnTriggerEnter(Collider other)
	{
		if(_tutTriggered == false)
		{
			_tutTriggered = true;

			// Is the HitObject the Avatar (or better asked, one of its arms)?
			ItemHit hitObject = other.gameObject.GetComponent<ItemHit>();
			if(hitObject != null)
			{
				MoveOnTrack mot = hitObject._armManager.GetMoveOnTrackInstance();
				RulesSwitcher ruleSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();

				TutorialPanelScript tutPanelRef = ruleSwitcher._tutPanel;
				UIPanel tutPanel = tutPanelRef.GetComponent<UIPanel>();
				UILabel tutLabel = tutPanelRef.tutText;
				tutLabel.pivot = UIWidget.Pivot.Left;

				tutLabel.text = _tutTextManager.TutTexts[_tutTextID];
				tutLabel.multiLine = true;

				// Stop movement:
				mot.TriggerPause(true);
				// Show Tutorial:
				tutPanel.alpha = 1.0f;

				// TODO: Fade out after time or only via button?!
			}
		}
	}
}
