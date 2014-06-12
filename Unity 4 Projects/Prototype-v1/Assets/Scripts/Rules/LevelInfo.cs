using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// BUG REPORT:
// Man kann ein Item zwei Mal einsammeln, wenn für beide Flossen die gleiche Regel gilt.
// z.B. Beide Flossen sollen Kreis sammeln -> Avatar sammelt mit linker Flosse, switched schnell nach links, und bekommt es mit rechter Flosse auch noch.
// Lösung: Beim Collecten sofort (nicht erst nach ausfaden des Items!) den Collider entfernen!

// BUG:
// Irgendwas pfuscht mir in die Werte rein.
// Das Array _necessaryPositiveItemPercent ist immer leer, und _maxScore ist immer 0.
// WARUM??
// Dieser Bug wurde mit einem riesen pfusch gefixt! Überall, wo es ging, wurden die Werte direkt mitgegeben...
// TODO: Korrekte Lösung finden.

[System.Serializable]
public class LevelInfo : MonoBehaviour
{
	public enum Rating
	{
		BRONZE = 0,
		SILVER,
		GOLD,
		PERFECT,
		NEGATIVE
	}

	// Member:
	[SerializeField]
	private CleanTrackData _track; // Reference to the track

	private float[] _necessaryPositiveItemPercent; // The borders (in percent) to get a better rating.
	private int _maxScore; // Maximum available positive pickups on the track.

//	public void Awake()
//	{
//		// TODO: Are these values fine? (HARDCODED)
//		_necessaryPositiveItemPercent = new float[3] { 0.5f, 0.75f, 0.9f };
//		Debug.Log ("ZZZ " +_necessaryPositiveItemPercent.Length);
//	}

	// Getter & Setter:
	public CleanTrackData Track
	{
		get { return _track; }
		private set { _track = value; }
	}

	public float GetNecessaryPositiveItemPercent(int index)
	{
		return _necessaryPositiveItemPercent[index];
	}

//	public void SetMaxScore(int maxScore)
//	{
//		Debug.Log ("SetMaxScore!!");
//		_maxScore = maxScore;
//	}

	// Other Methods:

	// The rating should be between 0.0f and 1.0f
	public Rating GetRating(int score, int maxScore)
	{
		_maxScore = maxScore; // PFUSCH
		// TODO: Are these values fine? (HARDCODED)
		_necessaryPositiveItemPercent = new float[3] { 0.5f, 0.75f, 0.9f }; // PFUSCH
//		Debug.Log ("Score: " + score + " MaxScore: " + _maxScore + " Log: " + (int)Rating.BRONZE + "/" + _necessaryPositiveItemPercent.Length);
		float rating = (float)score / (float)_maxScore;

		if(rating < _necessaryPositiveItemPercent[(int)Rating.BRONZE])
		{
			return Rating.NEGATIVE;
		}
		else if(rating < _necessaryPositiveItemPercent[(int)Rating.SILVER])
		{
			return Rating.BRONZE;
		}
		else if(rating < _necessaryPositiveItemPercent[(int)Rating.GOLD])
		{
			return Rating.SILVER;
		}
		else
		{
			return Rating.GOLD;
		}
	}

	public float GetRatingInPercent(int score)
	{
		return (float)score / (float)_maxScore;
	}

	public void SetUserScore(int score, int maxScore, LevelManager levelManager)
	{
		float rating = (float)score / (float)maxScore;

		if(rating > levelManager._userScore[LevelManager.CurrentLevel])
		{
			// Only update score, if it is more then the last try...
			levelManager._userScore[LevelManager.CurrentLevel] = rating;
			levelManager.Save();
		}
	}
}
