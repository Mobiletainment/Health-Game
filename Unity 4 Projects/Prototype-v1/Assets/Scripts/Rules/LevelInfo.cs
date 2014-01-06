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

	// DEPRECATED:
	public int Level;
}
