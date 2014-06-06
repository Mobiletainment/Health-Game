using UnityEngine;
using System.Collections;
using System;
using System.IO;

// Note: Currently, the AvatarState is only able to store integers. 
// If it is neccessary to store strings or floats, this class has to be extended!

public class AvatarState
{
	private static string _prefix = "as_";

	public enum State
	{
		CURRENT_ENERGY,		// Energy -> How many runs can you do before you have to sleep.
		// TODO: Save something like wake-up-time here?! (In seconds -> int)
		GIFT_ENERGY_BOOST,	// Don't sleep, just go on playing...
		GIFT_RESURRECTION,	// You died in a level, but can just ride on...
		GIFT_SLOW_MOTION,	// Too much stress? Slow down...
		GIFT_FREE_SIGHT,	// See all items on the track clearly...
	}

	public static int GetStateValue(State state)
	{
		string key = _prefix + state.ToString();

		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetInt(key);
		}

		return 0; // Currently, there isn't an entry for this state.
	}

	public static void SetStateValue(State state, int value)
	{
		PlayerPrefs.SetInt(_prefix + state.ToString(), value);
	}

	public static void IncreaseStateValue(State state)
	{
		IncreaseStateValue(state, 1);
	}

	public static void IncreaseStateValue(State state, int amount)
	{
		int giftAmount = GetStateValue(state);
		giftAmount += amount;
		SetStateValue(state, giftAmount);
	}

	public static void DecreaseStateValue(State state)
	{
		int giftAmount = GetStateValue(state);
		giftAmount--;
		SetStateValue(state, giftAmount);
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}

	public static void Reset()
	{
		string[] stateNames = Enum.GetNames(typeof(State));

		foreach(string name in stateNames)
		{
			PlayerPrefs.DeleteKey(_prefix + name);
		}

		Save();
	}
}
