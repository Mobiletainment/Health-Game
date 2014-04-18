using UnityEngine;
using System.Collections;

public class InGameUIController : MonoBehaviour 
{
	public UISprite _scoreFillSprite;
	public UILabel _scoreDescription; // TODO: Remove this and replace it by a sweet image!

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

	public void UpdateScore(LevelInfo levelInfo, int i = 1)
	{
		Score = Score + i;
		
		if (Score < 0) // avoid negative score
			Score = 0;

		LevelInfo.Rating rating = levelInfo.GetRating(Score);

		// TODO: Show Medals for current rank as image!


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
		
		int lowerBorder = 0, upperBorder = 0;
		float fillPercentage = 1.0f;

		if(rating == LevelInfo.Rating.NEGATIVE)
		{
			lowerBorder = 0;
			upperBorder = levelInfo.NecessaryPositiveItemCount[0];

			fillPercentage = (float)Score / (float)upperBorder;
			Debug.Log ("InGameUI: rating currently negative!");
		}
		else if(rating < LevelInfo.Rating.GOLD)
		{
			lowerBorder = levelInfo.NecessaryPositiveItemCount[(int)rating];
			upperBorder = levelInfo.NecessaryPositiveItemCount[((int)rating) + 1];

			fillPercentage = (float)(Score - lowerBorder) / (float)(upperBorder - lowerBorder);
		}

		Debug.Log ("Percentage: " + fillPercentage);
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
}
