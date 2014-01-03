using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelInfo : MonoBehaviour
{
	public enum Rating
	{
		BRONZE = 0,
		SILVER,
		GOLD,
		NEGATIVE
	}

	// Member:
	[SerializeField]
	private CleanTrackData _track; // Reference to the track
	[SerializeField]
	private int[] _necessaryPositiveItemCount; // The borders for getting a better rating...

	// Getter & Setter:
	public CleanTrackData Track
	{
		get { return _track; }
		private set { _track = value; }
	}

	public int[] NecessaryPositiveItemCount
	{
		get { return _necessaryPositiveItemCount; }
		private set { _necessaryPositiveItemCount = value; }
	}

	// Other Methods:
	public Rating GetRating(int rating)
	{
		if(rating < _necessaryPositiveItemCount[(int)Rating.BRONZE])
		{
			return Rating.NEGATIVE;
		}
		else if(rating < _necessaryPositiveItemCount[(int)Rating.SILVER])
		{
			return Rating.BRONZE;
		}
		else if(rating < _necessaryPositiveItemCount[(int)Rating.GOLD])
		{
			return Rating.SILVER;
		}
		else
		{
			return Rating.GOLD;
		}
	}

	// FIND OTHER SOLUTION:
	private static int[] PositiveItemCountConfig = new int[] { 20, 20, 20, 28, 40 }; //Level 1 = 8 good Items in total, etc.
	private static int[] TotalPositiveItemCountConfig = new int[] { 35, 45, 55, 60, 70, 90, 120 };
	
	public int Level;
	public int NecessaryPositiveItems { get { return PositiveItemCountConfig[Level]; } }
	public int TotalPositiveItemCount { get { return TotalPositiveItemCountConfig[Level]; } }
}
