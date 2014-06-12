using UnityEngine;
using System.Collections;

public class LoadFlightScene : MonoBehaviour 
{
	// TODO: LevelPack in near future.
	public int _level = 0;

	public UISprite _coinSprite;

	private UIImageButton _button;

	private void Awake()
	{
		_button = gameObject.GetComponent<UIImageButton>();
	}

    private void OnClick()
	{
		LevelManager.CurrentLevel = _level;

		Screen.orientation = ScreenOrientation.LandscapeLeft;
    	Application.LoadLevel("TrackFlight");
    }

	public void SetButtonState(bool active)
	{
		_button.isEnabled = active;
	}

	// TODO: Wenn es als was schlechteres gesetzt werden soll, als es atm ist, geschieht nichts... nur Aufbesserungs ist möglich!
	public void UpdateLevelSuccess(LevelInfo.Rating rating)
	{
		switch(rating)
		{
		case LevelInfo.Rating.BRONZE:
			_coinSprite.spriteName = "Coin_Bronze";
			break;
		case LevelInfo.Rating.SILVER:
			_coinSprite.spriteName = "Coin_Silver";
			break;
		case LevelInfo.Rating.GOLD:
			_coinSprite.spriteName = "Coin_Gold";
			break;
		case LevelInfo.Rating.PERFECT:
			_coinSprite.spriteName = "Coin_Perfect";
			break;
		}

		// Show the Award (Medal) if the level has been finished with a positive result:
		if(rating != LevelInfo.Rating.NEGATIVE)
		{
			if(_coinSprite.gameObject.activeSelf == false)
			{
				_coinSprite.gameObject.SetActive(true);
			}
		}
	}
}
