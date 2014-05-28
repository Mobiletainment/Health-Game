using UnityEngine;
using System.Collections;

public class FinalPointsLabelDisplay : MonoBehaviour 
{
	public UILabel _medal;
	public UILabel _points;
	public UILabel _unusedSkillPoints;

//	private RulesSwitcher _rulesSwitcher;
	public InGameUIController _uiController;

	public void ShowFinalPoints(LevelInfo levelInfo, SkillManager sm, int maxPoints)
	{
//		_rulesSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();
//
//		if(_rulesSwitcher == null)
//		{
//			Debug.LogError("Error: No RulesSwitcher could be found!");
//		}

		int points = _uiController.Score;
		LevelInfo.Rating rating = levelInfo.GetRating(points, maxPoints);

		_points.text = "Points: " + points;
		_medal.text = "Medal: " + rating.ToString(); // TODO: Visualize as Graphic!

		// QUICK HACK - TODO: Find a good solution on a good place -> See also SkillManager...
		int curUnusedSkillPoints = 0;
		if(rating == LevelInfo.Rating.BRONZE)
		{
			curUnusedSkillPoints = sm.AddMedalPoints(1);
		}
		else if(rating == LevelInfo.Rating.SILVER)
		{
			curUnusedSkillPoints = sm.AddMedalPoints(2);
		}
		else if(rating == LevelInfo.Rating.GOLD)
		{
			curUnusedSkillPoints = sm.AddMedalPoints(3);
		}

		_unusedSkillPoints.text = "Unused Skillpoints: " + curUnusedSkillPoints;

		UIPanel panel = gameObject.GetComponent<UIPanel>();
		panel.alpha = 1.0f;
	}
}
