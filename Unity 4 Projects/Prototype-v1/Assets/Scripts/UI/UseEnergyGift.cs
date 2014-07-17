using UnityEngine;
using System.Collections;

public class UseEnergyGift : MonoBehaviour 
{
	private UIImageButton _target;

	public UILabel _giftAmount;
	public UIImageButton _sleepButton;
	public UILabel _sleepLabel;
	public DrawEnergyState _energyDisplay;
	public AvailableNote _availableLabel;

	private void Start()
	{
		// For debugging only:
//		EnergyManager.ResetWaitingTime();
//		AvatarState.SetStateValue(AvatarState.State.CURRENT_ENERGY, 0);
//		AvatarState.SetStateValue(AvatarState.State.GIFT_ENERGY_BOOST, 3);
		
		EnergyManager.UpdateState();

		_target = gameObject.GetComponent<UIImageButton>();
		if(_target == null)
		{
			Debug.LogError("No UIImageButton has been attached to the UseResurrectionGift Button!");
			return;
		}

		// If there is no gift available or the player has at least one energy point, disable the button.
		if(AvatarState.GetStateValue(AvatarState.State.GIFT_ENERGY_BOOST) <= 0 || AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) > 0)
		{
			_target.isEnabled = false;
		}
	}
	
	private void OnClick()
	{
		EnergyManager.UpdateState();

		if(AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) > 0)
		{
			// Do not use the gift, if there is some energy available:
			_target.isEnabled = false;
			return;
		}

		// Fill up the energy:
		AvatarState.SetStateValue(AvatarState.State.CURRENT_ENERGY, EnergyManager.MaxEnergyPoints);

		// Update the Energy Display & (disable) Sleep Label & Sleep Button:
		_energyDisplay.UpdateEnergySprites();
		_sleepButton.isEnabled = false;
		_sleepLabel.gameObject.SetActive(false);

		// TODO: Show the amount of current energy directly in the description panel?!

		// Decrease Gift Amount:
		AvatarState.DecreaseStateValue(AvatarState.State.GIFT_ENERGY_BOOST);
		AvatarState.Save();
		
		// Update the "Available" Label in the Description Panel:
		_availableLabel.UpdateText();

		// Update the Energy Amount of the GiftDescription Icon:
		_giftAmount.text = AvatarState.GetStateValue(AvatarState.State.GIFT_ENERGY_BOOST).ToString();

		// Disable the button after the click (becuase energy is full):
		_target.isEnabled = false;
	}
}
