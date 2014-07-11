using UnityEngine;
using System.Collections;

public class SleepInfo : MonoBehaviour 
{
	public DrawEnergyState _energySymbols;

	private UILabel _target;

	private void Awake()
	{
		_target = gameObject.GetComponent<UILabel>();

		if(_target == null)
		{
			Debug.LogError("Error: The SleepInfo Script has not been added to an UILabel.");
		}
		else
		{
			_target.pivot = UIWidget.Pivot.Left;
		}
	}

	// Use this for initialization
	void Start () 
	{
		EnergyManager.UpdateState();

		int curEnergy = AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY);

		if(curEnergy <= 0 && EnergyManager.IsSleeping == false)
		{
			// TODO: Translation?!
			_target.text = "Flins ist müde...";
		}
		else if(curEnergy >= EnergyManager.MaxEnergyPoints || EnergyManager.IsSleeping == false)
		{
			gameObject.SetActive(false);
		}
	}

	void Update()
	{
		EnergyManager.UpdateState();

		// Display sleeping time till fully loaded when sleeping:
		if(EnergyManager.IsSleeping)
		{
			if(_target.gameObject.activeSelf == false)
			{
				_target.gameObject.SetActive(true);
			}

			int diffInSek = EnergyManager.GetTimeInSeconds() - EnergyManager.TimeStampLastAction;
			int currentEnergyPoints = AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY);
			int neededPoints = EnergyManager.MaxEnergyPoints - currentEnergyPoints;
			int neededTime = neededPoints * EnergyManager.SleepingTimePerPoint;
			neededTime -= diffInSek;

			int neededMinutes = neededTime / 60; // int devision.
			int neededSeconds = neededTime % 60;

			string neededSekStr = neededSeconds.ToString("00");

			_target.text = "Benötigte Schlafenszeit ist " + neededMinutes + ":" + neededSekStr;

			if((diffInSek % EnergyManager.SleepingTimePerPoint) == 0)
			{
				_energySymbols.UpdateEnergySprites();
			}
		}
		else
		{
			if(_target.gameObject.activeSelf == true)
			{
				_target.text = "Flins ist vollkommen ausgeruht!";
				_energySymbols.UpdateEnergySprites();
			}
		}
	}
}
