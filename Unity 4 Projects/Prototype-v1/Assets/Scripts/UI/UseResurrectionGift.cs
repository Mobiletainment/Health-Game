using UnityEngine;
using System.Collections;

public class UseResurrectionGift : MonoBehaviour 
{
	public InGameUIController _uiController;
	public ItemHit _leftArm; // HACK: No specific side, just need a working (SkillManager initialized) ItemHit instance...
	public ItemHit _rightArm; // Same here
	public MoveOnTrack _moveOnTrack;

	private void OnClick()
	{
		// TODO: Check for Resurrection Gift (AvatarState)
		Debug.Log("Currently available Resurrection Gifts: " + AvatarState.GetStateValue(AvatarState.State.GIFT_RESURRECTION));

		// TODO if > 0 ...
		_leftArm.InitLifes();
		_rightArm.InitLifes();

		// Deactivate Menu:
		_uiController.ActivateNoLifesMenu(false);

		// Enable Play (stop Pause):
		_moveOnTrack.TriggerPause(false);
	}
}
