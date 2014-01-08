using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemHit : MonoBehaviour
{
	[HideInInspector]
	public RulesSwitcher RuleSwitcher;

//	protected AudioSource _audioSource;
//	protected AudioReverbZone _audioReverb;

	private SkillManager _skillManager;
	private static int _skillLifes = -1; // Needs to be static, because there are 2 ItemHit Objects (left & right arm)

	public Transform _lifePos;
	public float _lifePosUp = 25.0f;
	public float _lifePosRight = 30.0f;
	public UITexture _iconLife;
	public UITexture _iconDead;
	private static List<UITexture> _iconLifeList;
	
	public enum ActiveHit
	{
		None,
		Good,
		Bad
	}

	public enum Side
	{
		LEFT = 0,
		RIGHT
	}
	
	private float lastItemHit = 0.0f;
	
	public Behaviour goodItemHit;
	public Behaviour badItemHit;
	private ActiveHit _activeHit;
//	private bool other = false;
	protected Vector3 lastHitPosition;

	public Side _side;

	public void Awake()
	{
		_activeHit = ActiveHit.None;

		_skillLifes = -1; // SkillLifes will be initialized in Start, but needs to be set to -1 first!
		
//		_audioSource = GameObject.Find("ItemHitSound").GetComponent<AudioSource>();
//		_audioReverb = GameObject.Find("ItemHitSound").GetComponent<AudioReverbZone>();
	}

	public void Start()
	{
		RuleSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();

		// Only the first time! (not for both arms...)
		if(_skillLifes == -1)
		{
			_skillManager = new SkillManager();
			_skillManager.Init();
			
			_skillLifes = _skillManager.GetSkillByName("Life").CurrentValue;
			RuleSwitcher.UpdateLife(_skillLifes);

			// Initialize little life icons:
			_iconLifeList = new List<UITexture>();
			Vector3 lifePos = _lifePos.position;
			lifePos.y += _lifePosUp;
			lifePos.x -= _lifePosRight * (_skillLifes - 1) * 0.5f;

			for(int i = 0; i < _skillLifes; ++i)
			{
				GameObject iconGO = Instantiate(_iconLife.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
				iconGO.transform.parent = _lifePos;
				iconGO.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				iconGO.transform.localPosition = lifePos;

				Debug.Log (iconGO.transform.position);
	            lifePos.x += _lifePosRight;
				UITexture icon = iconGO.GetComponent<UITexture>();
				_iconLifeList.Add(icon);
			}
		}
	}

	public void OnTriggerEnter(Collider hit)
	{
		GameObject hitObject = hit.gameObject;

		// Check, if the thing, that was hit, is a pickupItem:
		PickupInfo puInfo = hitObject.GetComponent<PickupInfo>();
		if(puInfo != null)
		{
			lastHitPosition = hitObject.transform.position;
			if (RuleSwitcher.IsItemHitGood(hitObject, _side))
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
		
			// Deactivate the collided object
			hit.collider.enabled = false;

			// Shrink the cought pickup item:
			Vector3 minusSize = new Vector3(0.1f, 0.1f, 0.1f);
			StartCoroutine(DownSizeItem(hit.transform, minusSize));
		}
	}

	public IEnumerator DownSizeItem(Transform item, Vector3 minusSize)
	{
		for(int i = 0; i < 4; ++i)
		{
			item.localScale -= minusSize;
			yield return new WaitForSeconds(0.1f);
		}

	}
	
	public void SetHit(ActiveHit hit)
	{
//		if (other){
//			if(hit==ActiveHit.Good){
//				hit=ActiveHit.Bad;
//			}else if(hit==ActiveHit.Bad){
//				hit=ActiveHit.Good;
//			}
//		}

		_activeHit = hit;

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
			if(RuleSwitcher.LifesLeft >= 1)
			{
				_iconLifeList[RuleSwitcher.LifesLeft - 1].mainTexture = _iconDead.mainTexture;
			}
//			RuleSwitcher.UpdateScore(-1);
			RuleSwitcher.UpdateLife(-1);
			if(RuleSwitcher.LifesLeft <= 0)
			{
				Debug.Log ("NO LIFES LEFT - GAME OVER!");
				Application.LoadLevel("GameOver");
			}

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
		if (Time.time > lastItemHit + 0.3f && _activeHit != ActiveHit.None)
		{
			SetHit(ActiveHit.None);
		}
	}
}
