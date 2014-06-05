using UnityEngine;
using System.Collections;

public class InGameUIController : MonoBehaviour 
{
	public UISprite _scoreFillSprite;
	public UILabel _scoreDescription; // TODO: Remove this and replace it by a sweet image!
	public UIPanel _noLifesPanel;

	[HideInInspector]
	public int Score { get; protected set; }
	
	void Awake() 
	{
		// Score (Points):
		Score = 0;

		// Optical Score:
		_scoreFillSprite.fillAmount = 0.0f;


		_scoreDescription.text = "LOS GEHT'S!"; // DEBUG ONLY
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
		float ratingPercent = levelInfo.GetRatingInPercent(Score);

		// TODO: Show Medals for current rank as image! (Currently german hardcoded text!)

		if(ratingPercent < 1.0f)
		{
	        switch (rating)
	        {
	            case LevelInfo.Rating.NEGATIVE:
	                _scoreDescription.text = "KEINE MEDAILLE";
	                break;
	            case LevelInfo.Rating.SILVER:
	                _scoreDescription.text = "SILBER";
	                break;
	            default:
	                _scoreDescription.text = rating.ToString(); // DEBUG ONLY
	                break;
	        }
		}
		else
		{
			_scoreDescription.text = "PERFEKT";
		}

		
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
		else if(rating == LevelInfo.Rating.GOLD) // GOLD
		{
			lowerBorder = levelInfo.GetNecessaryPositiveItemPercent((int)rating);
			upperBorder = 1.0f;
			
			fillPercentage = (totalPercentage - lowerBorder) / (upperBorder - lowerBorder);
		}

		Debug.Log ("Total Percentage: " + totalPercentage + ", Fillup Percentage: " + fillPercentage);
		FillupScore(fillPercentage);
	}

	// float percentage must be between 0.0f and 1.0f!
	public void FillupScore(float percentage)
	{
		float fillTime = 0.2f;

		if(percentage < _scoreFillSprite.fillAmount)
		{
			StartCoroutine(FillupScoreByTime(1.0f, fillTime));
		}

		StartCoroutine(FillupScoreByTime(percentage, fillTime));
	}

	private IEnumerator FillupScoreByTime(float percentage, float duration)
	{
		float curTime = 0.0f;
		AnimationCurve fillCurve = AnimationCurve.Linear(0.0f, _scoreFillSprite.fillAmount, duration, percentage);

		while(curTime < duration)
		{
			curTime += Time.deltaTime;
			_scoreFillSprite.fillAmount = fillCurve.Evaluate(curTime);

			yield return new WaitForSeconds(Time.deltaTime);
		}

		_scoreFillSprite.fillAmount = percentage;
	}

	public void ActivateNoLifesMenu(bool enable)
	{
		// TODO: Fade in and out (change alpha) slowly...
		if(enable)
		{
			_noLifesPanel.alpha = 1.0f;
		}
		else
		{
			_noLifesPanel.alpha = 0.0f;
		}
	}
}
