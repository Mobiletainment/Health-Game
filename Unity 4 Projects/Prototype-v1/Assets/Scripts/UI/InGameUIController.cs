using UnityEngine;
using System.Collections;

public class InGameUIController : MonoBehaviour 
{
//	public UISprite _scoreFillSprite;
//	public UILabel _scoreDescription; // TODO: Remove this and replace it by a sweet image!
	public UISprite _scoreFillBronze;
	public UISprite _scoreFillSilver;
	public UISprite _scoreFillGold;

	public UIPanel _lifeDisplayPanel;
	public UIPanel _finalPointsPanel;
	public UIPanel _movementPanel;
	public UIPanel _noLifesPanel;
	public UIPanel _awardDisplayPanel;
	public UIPanel _boostDisplayPanel;
	public UIPanel _menuDisplayPanel;
	public UIPanel _menuPausePanel;
	public UIPanel _tutorialPanel;

	[HideInInspector]
	public int Score { get; protected set; }
	
	private void Awake() 
	{
		// Score (Points):
		Score = 0;

		// Optical Score:
		_scoreFillBronze.fillAmount = 0.0f;
		_scoreFillSilver.fillAmount = 0.0f;
		_scoreFillGold.fillAmount = 0.0f;

//		_scoreDescription.text = "LOS GEHT'S!"; // DEBUG ONLY
	}

	void Start() 
	{
	
	}

	public void UpdateScore(LevelInfo levelInfo, int maxPoints, int i = 1)
	{
		Score = Score + i;
		
		if (Score < 0) // avoid negative score
			Score = 0;

		LevelInfo.Rating rating = levelInfo.GetRating(Score, maxPoints);
//		float ratingPercent = levelInfo.GetRatingInPercent(Score);

		// DONE: Show Medals for current rank as image! (Currently german hardcoded text!)
//		if(ratingPercent < 1.0f)
//		{
//	        switch (rating)
//	        {
//	            case LevelInfo.Rating.NEGATIVE:
//	                _scoreDescription.text = "KEINE MEDAILLE";
//	                break;
//	            case LevelInfo.Rating.SILVER:
//	                _scoreDescription.text = "SILBER";
//	                break;
//	            default:
//	                _scoreDescription.text = rating.ToString(); // DEBUG ONLY
//	                break;
//	        }
//		}
//		else
//		{
//			_scoreDescription.text = "PERFEKT";
//		}

		
		float lowerBorder = 0, upperBorder = 0;
		float fillPercentage = 1.0f; // GOLD
		float totalPercentage = levelInfo.GetRatingInPercent(Score);

		if(rating == LevelInfo.Rating.NEGATIVE) // NEGATIVE
		{
			lowerBorder = 0;
			upperBorder = levelInfo.GetNecessaryPositiveItemPercent(0);

			fillPercentage = totalPercentage / upperBorder;
			Debug.Log ("InGameUI: rating currently negative!");
		}
		else if(rating < LevelInfo.Rating.GOLD) // BRONZE, SILVER
		{
			lowerBorder = levelInfo.GetNecessaryPositiveItemPercent((int)rating);
			upperBorder = levelInfo.GetNecessaryPositiveItemPercent(((int)rating) + 1);

			fillPercentage = (totalPercentage - lowerBorder) / (upperBorder - lowerBorder);
		}
		else if(rating >= LevelInfo.Rating.GOLD) // GOLD
		{
			if(rating == LevelInfo.Rating.PERFECT)
			{
				fillPercentage = 1.0f;
			}
			else
			{
				lowerBorder = levelInfo.GetNecessaryPositiveItemPercent((int)rating);
				upperBorder = 1.0f;
			
				fillPercentage = (totalPercentage - lowerBorder) / (upperBorder - lowerBorder);
			}
		}

		Debug.Log ("Total Percentage: " + totalPercentage + ", Fillup Percentage: " + fillPercentage);
		FillupScore(rating, fillPercentage);
	}

	// float percentage must be between 0.0f and 1.0f!
	public void FillupScore(LevelInfo.Rating rating, float percentage)
	{
		float fillTime = 0.2f;

//		if(percentage < _scoreFillSprite.fillAmount)
//		{
//			StartCoroutine(FillupScoreByTime(1.0f, fillTime));
//		}

		UISprite changeSprite = null;
		UISprite lastSprite = null;

		switch(rating)
		{
		case LevelInfo.Rating.NEGATIVE:
			changeSprite = _scoreFillBronze;
			break;
		case LevelInfo.Rating.BRONZE:
			if(_scoreFillBronze.fillAmount < 1.0f)
			{
				lastSprite = _scoreFillBronze;
			}
			changeSprite = _scoreFillSilver;
			break;
		case LevelInfo.Rating.SILVER:
			if(_scoreFillSilver.fillAmount < 1.0f)
			{
				lastSprite = _scoreFillSilver;
			}
			changeSprite = _scoreFillGold;
			break;
		case LevelInfo.Rating.GOLD:
			lastSprite = _scoreFillGold;
			break;
		case LevelInfo.Rating.PERFECT: // Perfect isn't shown extra...
			lastSprite = _scoreFillGold;
			break;
		}

		if(lastSprite != null)
		{
			StartCoroutine(FillupScoreByTime(lastSprite, 1.0f, fillTime));
		}
		if(changeSprite != null)
		{
			StartCoroutine(FillupScoreByTime(changeSprite, percentage, fillTime));
		}
	}

	private IEnumerator FillupScoreByTime(UISprite scoreSprite, float percentage, float duration)
	{
		float curTime = 0.0f;
		AnimationCurve fillCurve = AnimationCurve.Linear(0.0f, scoreSprite.fillAmount, duration, percentage);

		while(curTime < duration)
		{
			curTime += Time.deltaTime;
			scoreSprite.fillAmount = fillCurve.Evaluate(curTime);

			yield return new WaitForSeconds(Time.deltaTime);
		}

		scoreSprite.fillAmount = percentage;
	}

	public void ActivateNoLifesMenu(bool enable)
	{
		// TODO: Fade in and out (change alpha) slowly...
		if(enable)
		{
			foreach(Transform trans in _noLifesPanel.transform)
			{
				AvailableNote note = trans.GetComponent<AvailableNote>();
				if(note != null)
				{
					note.UpdateText();
				}
			}

			DisplayHUD(false);
			_noLifesPanel.alpha = 1.0f;
		}
		else
		{
			_noLifesPanel.alpha = 0.0f;
			DisplayHUD(true);
		}
	}

	// Display or hide the HUD Elements (like Menu, Coin Award, etc.)
	public void DisplayHUD(bool active)
	{
		float alpha = (active ? 1.0f : 0.0f);

		_lifeDisplayPanel.alpha = alpha;
		_awardDisplayPanel.alpha = alpha;
		_boostDisplayPanel.alpha = alpha;
		_menuDisplayPanel.alpha = alpha;
	}
}
