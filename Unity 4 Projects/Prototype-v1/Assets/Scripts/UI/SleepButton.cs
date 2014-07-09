using UnityEngine;
using System.Collections;

public class SleepButton : MonoBehaviour 
{
	UIImageButton _target = null;

	private void Awake()
	{
		_target = gameObject.GetComponent<UIImageButton>();
		
		if(_target == null)
		{
			Debug.LogError("Error: The SleepButton Script has not been added to an UIImageButton.");
		}
	}

	private void Start() 
	{
		EnergyManager.UpdateState();

		// If the energy is fully loaded or the avatar is already sleeping, disable the button:
		if(AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) >= EnergyManager.MaxEnergyPoints || EnergyManager.IsSleeping == true)
		{
			_target.isEnabled = false;
		}
	}

	private void OnClick()
	{
		EnergyManager.SetToSleep();
		_target.isEnabled = false;

//		_wasPressed = true;
	}
//	private bool _wasPressed = false;
//	private void Update()
//	{
//		if(_wasPressed)
//			_target.SendMessage("OnHover", true);
//	}
}
