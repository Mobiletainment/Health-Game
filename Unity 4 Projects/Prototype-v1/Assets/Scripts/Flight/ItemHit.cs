using UnityEngine;
using System.Collections;

public class ItemHit : MonoBehaviour
{
	[HideInInspector]
	public RulesSwitcher RuleSwitcher;

//	protected AudioSource _audioSource;
//	protected AudioReverbZone _audioReverb;
	
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
	private bool other=false;
	protected Vector3 lastHitPosition;

	public void Awake()
	{
		activeHit = ActiveHit.None;
		
//		_audioSource = GameObject.Find("ItemHitSound").GetComponent<AudioSource>();
//		_audioReverb = GameObject.Find("ItemHitSound").GetComponent<AudioReverbZone>();
	}
	public void Start(){
		 RuleSwitcher= GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();
		 if (tag=="0"){
			other=true;
		 }else {
			other=false;	
		}
	}

	public void OnTriggerEnter(Collider hit)
	{
		GameObject hitObject = hit.gameObject;
		
		
		

		
		lastHitPosition = hitObject.transform.position;
		if (RuleSwitcher.IsItemHitGood(hitObject))
		{
			SetHit(ItemHit.ActiveHit.Good);
//			_audioReverb.enabled = false;
		}
		else
		{
			SetHit(ItemHit.ActiveHit.Bad);
//			_audioReverb.enabled = true;
		}
		
//		_audioSource.gameObject.transform.position = hitObject.transform.position;
//		_audioSource.Play();
		
		if (hit.tag != "UI")
		{
			//deactivate the collided object
			hit.collider.enabled = false;
			//hit.gameObject.renderer.material.color = Color.black;
			hitObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		}
		//hit.gameObject.renderer.enabled = false;
	}
	
	
	
	public void SetHit(ActiveHit hit)
	{
		
		
		if (other){
			if(hit==ActiveHit.Good){
				hit=ActiveHit.Bad;
			}else if(hit==ActiveHit.Bad){
				hit=ActiveHit.Good;
			}
		}
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
			
			RuleSwitcher.UpdateScore(1);
			lastItemHit = Time.time;
			break;
		case ActiveHit.Bad:
			badItemHit.transform.position = lastHitPosition;
			goodItemHit.enabled = false;
			badItemHit.enabled = true;
			RuleSwitcher.UpdateScore(-1);
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
