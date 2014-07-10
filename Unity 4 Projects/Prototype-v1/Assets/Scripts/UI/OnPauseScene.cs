using UnityEngine;
using System.Collections;

// This script manages the behaviour of the pause (and while-pause-menu) buttons in the InGame UI:
public class OnPauseScene : MonoBehaviour
{
	public enum Mode
	{
		PAUSE,
		PLAY,
		RESTART,
		MAINMENU,
	};

	public Mode _mode;
	public MoveOnTrack _gameInstance = null;
	public UIPanel _otherPanel = null;
	public InGameUIController _uiController = null;
	public bool _restartCosts = true;

	private void Start()
	{
		// Restart is only possible, if user has enough life points:
		if(_mode == Mode.RESTART)
		{
			if(AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) <= 0)
			{
				UIImageButton target = gameObject.GetComponent<UIImageButton>();
				if(target != null)
				{
					target.isEnabled = false;
				}
				else
				{
					Debug.LogError("OnPauseScene Mode::RESTART is not attached to an UIIMageButton!");
				}
			}
		}
	}

	private void OnClick()
    {
		if(_mode == Mode.RESTART)
		{
			if(_restartCosts == false)
			{
				AvatarState.IncreaseStateValue(AvatarState.State.CURRENT_ENERGY);
			}

			Application.LoadLevel("TrackFlight");
			return;
		}
		else if(_mode == Mode.MAINMENU)
		{
			Debug.Log("End round -> MainMenu");
			Application.LoadLevel("GameOver");
			return;
		}

		if(_gameInstance == null)
		{
			Debug.LogWarning("No GameInstance is set in the GameUI Button Elements on Script OnPauseScene!");
		}
		if(_otherPanel == null)
		{
			Debug.LogWarning("No otherPanel is set, that can be faded in on the button press (GameUI Button Elements)!");
		}

		UIPanel ownPanel = transform.parent.gameObject.GetComponent<UIPanel>();
		// TODO: At least some fade...
		ownPanel.alpha = 0.0f;
		_otherPanel.alpha = 1.0f;

		// Check selected modes and decide what to do next:
		if(_mode == Mode.PAUSE)
		{
			_gameInstance.TriggerPause(true);
			_uiController.DisplayHUD(false);
			Debug.Log("ACTIVATED PAUSE!");
		}
		else if(_mode == Mode.PLAY)
		{
			_gameInstance.TriggerPause(false);
			_uiController.DisplayHUD(true);
			Debug.Log("LET'S GO ON PLAYING!");
		}
    }
}
