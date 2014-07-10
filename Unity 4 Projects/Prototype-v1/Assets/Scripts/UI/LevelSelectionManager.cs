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
		EnergyManager.UpdateState();
		int currentEnergy = AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY);

		float[] necessaryPositiveItemPercent = new float[3] { 0.5f, 0.75f, 0.9f }; // TODO: Hardcoded PFUSCH (Same in LevelInfo.cs)

		if(currentEnergy <= 0)
		{
			// Deactivate first button, if avatar has no energy. (All other buttons will be deactivated via shallActivateNextButton in the loop.)
			_levelButtons[0].GetComponent<LoadFlightScene>().SetButtonState(false);
		}

		for(int i = 0; i < _levelButtons.Count; ++i)
		{
			float userScore = _levelManager.GetUserScore(i);
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

			bool shallActivateNextButton = false;
			if(currentEnergy > 0)
			{
				shallActivateNextButton = (userScore >= necessaryPositiveItemPercent[(int)LevelInfo.Rating.BRONZE]);
			}

			if(i < _levelButtons.Count - 1)
			{
				_levelButtons[i+1].GetComponent<LoadFlightScene>().SetButtonState(shallActivateNextButton);
			}
		}
	}
}
