using UnityEngine;
using System.Collections;

public class ItemHit : MonoBehaviour
{
	public RulesSwitcher RuleSwitcher;
	
	public enum ActiveHit
	{
		None,
		Good,
		Bad
	}
	
	private float lastItemHit = 0.0f;
	
	public Behaviour goodItemHit;
	public Behaviour badItemHit;
	private ActiveHit activeHit;
	
	protected UILabel scoreLabel;
	protected int score = 0;
	
	protected Vector3 lastHitPosition;

	public void Awake()
	{
		activeHit = ActiveHit.None;
		
		this.scoreLabel = GameObject.Find("ScoreLabel").GetComponent<UILabel>();
    	UpdateScore(0);	
	}
	

	public void OnTriggerEnter(Collider hit)
	{
		Debug.Log("Hit");
		lastHitPosition = hit.gameObject.transform.position;
		if (RuleSwitcher.IsItemHitGood(hit.gameObject))
		{
			SetHit(ItemHit.ActiveHit.Good);
		}
		else
		{
			SetHit(ItemHit.ActiveHit.Bad);
		}
		
		Debug.Log(hit.tag);
		if (hit.tag != "UI")
		{
			//deactivate the collided object
			hit.collider.enabled = false;
			//hit.gameObject.renderer.material.color = Color.black;
			hit.gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		}
		//hit.gameObject.renderer.enabled = false;
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
			goodItemHit.transform.position = lastHitPosition;
			goodItemHit.enabled = true;
			badItemHit.enabled = false;
			
			UpdateScore(1);
			lastItemHit = Time.time;
			break;
		case ActiveHit.Bad:
			badItemHit.transform.position = lastHitPosition;
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
