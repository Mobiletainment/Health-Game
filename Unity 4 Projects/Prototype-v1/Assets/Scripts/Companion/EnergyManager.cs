using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour 
{
	// Configuration:
	private static string _prefix = "em_";
	private static uint _waitingTimeInSec = 15 * 60; // 15 Minutes
	private static uint _sleepingTimePerPoint = 5 * 60; // 5 Minutes per Energy-Point regeneration.

	private static uint _timeStampLastAction;
//	private bool _hasToWait;
	private static bool _isSleeping;

	public static void UpdateState()
	{
		// TODO: Check for all timers and add energy-points. (Do not forget to update the timers, but do not reset them.)
	}

	public static void ResetWaitingTime()
	{
		// TODO: Player did an action, waiting time has to start from beginning on.
		_isSleeping = false;
	}

	public static void SetToSleep()
	{
		// TODO...
		_isSleeping = true;


	}

	public static uint GetTimeInSeconds()
	{
		// TODO: This system may be tricked, if the player sets the watch forward... (Getting a Server Time seems to be the easiest way to fix this.)
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		uint timeStamp = System.Convert.ToUInt32((System.DateTime.UtcNow - epochStart).TotalSeconds);

		return timeStamp;
	}
}
