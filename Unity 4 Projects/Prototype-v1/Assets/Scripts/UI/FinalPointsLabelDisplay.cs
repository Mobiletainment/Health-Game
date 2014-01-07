using UnityEngine;
using System.Collections;

public class FinalPointsLabelDisplay : MonoBehaviour 
{
	public UILabel _medal;
	public UILabel _points;

	private RulesSwitcher _rulesSwitcher;

	public void ShowFinalPoints(LevelInfo levelInfo)
	{
		_rulesSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();

		if(_rulesSwitcher == null)
		{
			Debug.LogError("Error: No RulesSwitcher could be found!");
		}

		int points = _rulesSwitcher.Score;
		_points.text = "Points: " + points;
		_medal.text = "Medal: " + levelInfo.GetRating(points).ToString(); // TODO: Visualize as Graphic!

		UIPanel panel = gameObject.GetComponent<UIPanel>();
		panel.alpha = 1.0f;
	}
}
