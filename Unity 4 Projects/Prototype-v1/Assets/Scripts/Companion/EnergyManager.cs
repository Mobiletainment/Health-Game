using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour 
{
	// Configuration:
	private static string _prefix = "em_";
	private static int _waitingTimeInSec = 15 * 60; // 15 Minutes
	private static int _sleepingTimePerPoint = 5 * 60; // 5 Minutes per Energy-Point regeneration.
	private static int _maxEnergyPoints = 6;

	public static int TimeStampLastAction
	{
		get 
		{
			string key = _prefix + "TimeStampLastAction";
			
			if(PlayerPrefs.HasKey(key))
			{
				return PlayerPrefs.GetInt(key);
			}
			
			return 0; // Currently, there isn't an entry for this state.
		}

		private set 
		{
			PlayerPrefs.SetInt(_prefix + "TimeStampLastAction", value);
			PlayerPrefs.Save();
		}
	}

	public static bool IsSleeping
	{
		get 
		{
			string key = _prefix + "IsSleeping";
			
			if(PlayerPrefs.HasKey(key))
			{
				int isSleeping = PlayerPrefs.GetInt(key);
				return (isSleeping != 0 ? true : false);
			}
			
			return false; // Currently, there isn't an entry for this state.
		}
		
		private set 
		{
			int isSleeping = (value == true ? 1 : 0);
			PlayerPrefs.SetInt(_prefix + "IsSleeping", isSleeping);
			PlayerPrefs.Save();
		}
	}

	public static int MaxEnergyPoints
	{
		get { return _maxEnergyPoints; }
		private set { _maxEnergyPoints = value; }
	}

	public static int SleepingTimePerPoint
	{
		get { return _sleepingTimePerPoint; }
		private set { _sleepingTimePerPoint = value; }
	}

	public static void UpdateState()
	{
		int currentEnergyPoints = AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY);
		int neededDiff = _maxEnergyPoints - currentEnergyPoints;
		if(neededDiff > 0)
		{
			int now = GetTimeInSeconds();
			int diff = now - TimeStampLastAction;
			
			if(!IsSleeping)
			{
				if(diff > _waitingTimeInSec)
				{
					diff -= _waitingTimeInSec;
				}
				else
				{
					// The avatar is not sleeping and the waiting time for the last-action-time-distance is not yet over...
					return;
				}
			}

			int regenerationPoints = (int)(diff / _sleepingTimePerPoint);
			if(neededDiff <= regenerationPoints)
			{
				AvatarState.SetStateValue(AvatarState.State.CURRENT_ENERGY, _maxEnergyPoints);
				IsSleeping = false;
			}
			else
			{
				AvatarState.SetStateValue(AvatarState.State.CURRENT_ENERGY, currentEnergyPoints + regenerationPoints);
				IsSleeping = true;

				TimeStampLastAction = GetTimeInSeconds() - (diff % _sleepingTimePerPoint);
			}
		}
	}

	public static void ResetWaitingTime()
	{
		// Player did an action, waiting time has to start from beginning on:
		IsSleeping = false;
		TimeStampLastAction = GetTimeInSeconds();
	}

	public static void SetToSleep()
	{
		IsSleeping = true;

		TimeStampLastAction = GetTimeInSeconds();
	}

	public static int GetTimeInSeconds()
	{
		// TODO: This system may be tricked, if the player sets the watch forward... (Getting a Server Time seems to be the easiest way to fix this.)
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int timeStamp = System.Convert.ToInt32((System.DateTime.UtcNow - epochStart).TotalSeconds);

		return timeStamp;
	}
}
