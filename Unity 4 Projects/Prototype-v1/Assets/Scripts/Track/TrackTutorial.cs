using UnityEngine;
using System.Collections;

public class TrackTutorial : MonoBehaviour 
{
	public TutorialTextManager _tutTextManager;
	public int  _tutTextID;

	private bool _tutTriggered = false;

	public void OnTriggerEnter(Collider other)
	{
		// Only if the User want's to see the tutorial:
		if(PlayerPrefs.GetInt(EnableTutorialSetting.PrefKey) == 1)
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

					// Fade out and end of pause will be triggered by a button.
				}
			}
		}
	}
}
