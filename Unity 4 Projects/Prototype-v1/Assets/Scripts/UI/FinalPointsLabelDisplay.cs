using UnityEngine;
using System.Collections;

public class FinalPointsLabelDisplay : MonoBehaviour 
{
	public UILabel _headline;
	public UISprite _medal;
	public UILabel _noMedalText;
	public UILabel _points;
	public UILabel _unusedSkillPoints;
	public UILabel _retryCostLabel;
	public OnPauseScene _retryButton;

	public UIImageButton _nextTrackButton;

	public InGameUIController _uiController;

	public void ShowFinalPoints(LevelInfo levelInfo, SkillManager sm, LevelManager levelManager, int maxPoints)
	{
		// Fade out other HUD Elements:
		_uiController.DisplayHUD(false);

		int points = _uiController.Score;
		LevelInfo.Rating rating = levelInfo.GetRating(points, maxPoints);

		// Set User-Score:
		levelInfo.SetUserScore(points, maxPoints, levelManager);

		_points.text = points + " / " + maxPoints;
//		_medal.text = "Medal: " + rating.ToString(); // DONE: Visualize as Graphic!

		// Deactivate "Next Track" Button, if result is negative / GetUserScore is negative OR player is out of energy:
		float bestUserScore = levelManager.GetUserScore(LevelManager.CurrentLevel);
		LevelInfo.Rating bestRating = levelInfo.GetRating(bestUserScore);
		if(bestRating == LevelInfo.Rating.NEGATIVE || AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) <= 0)
		{
			// _nextTrackButton.gameObject.SetActive(false);
			_nextTrackButton.isEnabled = false;
		}

		// QUICK HACK - TODO: Find a good solution on a good place for adding medal points -> See also SkillManager...
		int curUnusedSkillPoints = sm.GetUnspentSkillPoints();
		int retryCosts = 0;
		_retryButton._restartCosts = false;
		if(rating == LevelInfo.Rating.NEGATIVE)
		{
			// Result was negative, do not show medal, show text instead:
			_noMedalText.gameObject.SetActive(true);
			_medal.gameObject.SetActive(false);

			retryCosts = 1; // Retry does only cost, if result was negative...
			_retryButton._restartCosts = true;

			// TODO: Translation?!
			_headline.text = "Schade, du hast nicht genug Punkte gesammelt...";
		}
		else if(rating == LevelInfo.Rating.BRONZE)
		{
			_medal.spriteName = "Coin_Bronze";
			curUnusedSkillPoints = sm.AddMedalPoints(1);
		}
		else if(rating == LevelInfo.Rating.SILVER)
		{
			_medal.spriteName = "Coin_Silver";
			curUnusedSkillPoints = sm.AddMedalPoints(2);
		}
		else if(rating == LevelInfo.Rating.GOLD)
		{
			_medal.spriteName = "Coin_Gold";
			curUnusedSkillPoints = sm.AddMedalPoints(3);
		}
		else if(rating == LevelInfo.Rating.PERFECT)
		{
			_medal.spriteName = "Coin_Perfect";
		}

		_unusedSkillPoints.text = curUnusedSkillPoints.ToString();
		_retryCostLabel.text = "Energie kosten: " + retryCosts; // TODO: Translation?!

		UIPanel panel = gameObject.GetComponent<UIPanel>();
		panel.alpha = 1.0f;

		EnergyManager.ResetWaitingTime();
	}
}
