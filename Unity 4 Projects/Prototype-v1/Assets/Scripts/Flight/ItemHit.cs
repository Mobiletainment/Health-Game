using UnityEngine;
using System.Collections;

public class ItemHit
{
	public enum ActiveHit
	{
		None,
		Good,
		Bad
	}
	
	private float lastItemHit = 0.0f;
	
	private Behaviour goodItemHit;
	private Behaviour badItemHit;
	private ActiveHit activeHit;
	
	protected UILabel scoreLabel;
	protected int score = 0;
	
	public ItemHit(GameObject collisionEffectPositive, GameObject collisionEffectNegative)
	{
		goodItemHit = (collisionEffectPositive.GetComponent("Halo") as Behaviour);
		badItemHit = (collisionEffectNegative.GetComponent("Halo") as Behaviour);
		activeHit = ActiveHit.None;
		
		this.scoreLabel = GameObject.Find("ScoreLabel").GetComponent<UILabel>();
    	UpdateScore(0);
		
	}
	
	public void UpdateScore(int i = 1)
	{
		score = score + i;
		
		if (score < 0) //avoid negative score
			score = 0;
		
		scoreLabel.text = "Score: " + score.ToString();		
	}
	
	public void SetHit(ActiveHit hit)
	{
		activeHit = hit;
		
		switch (hit)
		{
		case ActiveHit.None:
			goodItemHit.enabled = false;
			badItemHit.enabled = false;
			break;
		case ActiveHit.Good:
			goodItemHit.enabled = true;
			badItemHit.enabled = false;
			UpdateScore(1);
			lastItemHit = Time.time;
			break;
		case ActiveHit.Bad:
			goodItemHit.enabled = false;
			badItemHit.enabled = true;
			UpdateScore(-1);
			lastItemHit = Time.time;
			#if UNITY_IPHONE || UNITY_ANDROID
				Handheld.Vibrate(); //vibration as feedback for wrong items
			#endif
			break;
		default:
			break;
		}
	}

	// Update is called once per frame
	public void Update ()
	{
		if (Time.time > lastItemHit + 0.3f && activeHit != ActiveHit.None)
		{
			SetHit(ActiveHit.None);
		}
	}
}
