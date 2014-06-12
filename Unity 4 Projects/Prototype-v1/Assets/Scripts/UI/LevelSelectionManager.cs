using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectionManager : MonoBehaviour 
{
	public LevelManager _levelManager;
	public List<UIImageButton> _levelButtons;

	// Use this for initialization
	private void Start() 
	{
		float[] necessaryPositiveItemPercent = new float[3] { 0.5f, 0.75f, 0.9f }; // TODO: Hardcoded PFUSCH (Same in LevelInfo.cs)

		for(int i = 0; i < _levelButtons.Count; ++i)
		{
			float userScore = _levelManager._userScore[i];
			LevelInfo.Rating userRating;

			if(userScore < necessaryPositiveItemPercent[(int)LevelInfo.Rating.BRONZE])
			{
				userRating = LevelInfo.Rating.NEGATIVE;
			}
			else if(userScore < necessaryPositiveItemPercent[(int)LevelInfo.Rating.SILVER])
			{
				userRating = LevelInfo.Rating.BRONZE;
			}
			else if(userScore < necessaryPositiveItemPercent[(int)LevelInfo.Rating.GOLD])
			{
				userRating = LevelInfo.Rating.SILVER;
			}
			else
			{
				if(userScore < 1.0f)
				{
					userRating = LevelInfo.Rating.GOLD;
				}
				else
				{
					userRating = LevelInfo.Rating.PERFECT;
				}
			}

			_levelButtons[i].GetComponent<LoadFlightScene>().UpdateLevelSuccess(userRating);

			bool shallActivateNextButton = (userScore >= necessaryPositiveItemPercent[(int)LevelInfo.Rating.BRONZE]);
			if(i < _levelButtons.Count - 1)
			{
				_levelButtons[i+1].GetComponent<LoadFlightScene>().SetButtonState(shallActivateNextButton);
			}
		}
	}
}
