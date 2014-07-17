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

		// Get the original User-Score:
		float originalUserScore = levelManager.GetUserScore(LevelManager.CurrentLevel);
		LevelInfo.Rating originalRating = levelInfo.GetRating(originalUserScore);

		// Set the new User-Score: (Internally, this will only be done, if it is better than the original)
		levelInfo.SetUserScore(points, maxPoints, levelManager);

		_points.text = points + " / " + maxPoints;
//		Debug.Log("Medal: " + rating.ToString()); // DONE: Visualize as Graphic!

		// Deactivate "Next Track" Button, if result is negative / GetUserScore is negative OR player is out of energy:
		float bestUserScore = levelManager.GetUserScore(LevelManager.CurrentLevel);
		LevelInfo.Rating bestRating = levelInfo.GetRating(bestUserScore);
		if(bestRating == LevelInfo.Rating.NEGATIVE || AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) <= 0)
		{
			// _nextTrackButton.gameObject.SetActive(false);
			_nextTrackButton.isEnabled = false;
		}

		// Adding new Medal Points (to acquire Skill Points)
		// Compare original with best score (if not equal and best not negative)
		if(originalRating != bestRating && bestRating != LevelInfo.Rating.NEGATIVE)
		{
			int originalPoints = (originalRating == LevelInfo.Rating.NEGATIVE ? 0 : ((int)originalRating)+1);
			int bestPoints = ((int)bestRating)+1;

			int diff = bestPoints - originalPoints;

			sm.AddMedalPoints(diff);
		}

		// Set some UI Texts, images, and button states, that depend on the track result:
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
		}
		else if(rating == LevelInfo.Rating.SILVER)
		{
			_medal.spriteName = "Coin_Silver";
		}
		else if(rating == LevelInfo.Rating.GOLD)
		{
			_medal.spriteName = "Coin_Gold";
		}
		else if(rating == LevelInfo.Rating.PERFECT)
		{
			_medal.spriteName = "Coin_Perfect";
		}

		int curUnusedSkillPoints = sm.GetUnspentSkillPoints();
		_unusedSkillPoints.text = curUnusedSkillPoints.ToString();
		_retryCostLabel.text = "Energie kosten: " + retryCosts; // TODO: Translation?!

		UIPanel panel = gameObject.GetComponent<UIPanel>();
		panel.alpha = 1.0f;

		EnergyManager.ResetWaitingTime();
	}
}
