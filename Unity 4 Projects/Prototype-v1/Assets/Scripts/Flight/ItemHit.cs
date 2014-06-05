using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemHit : MonoBehaviour
{
	[HideInInspector]
	public RulesSwitcher RuleSwitcher;

	public ArmManager _armManager;

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

	public float _armAlertDuration = 1.0f;
	private float _curAlertTime = 0.0f;
	public AnimatedMaterial _armAlert;
	public Material _greenAlert;
	public Material _redAlert;

	public ParticleSystem _badItemHitEffect;
	private ParticleSystem[] _badItemHitEffects;

	public float _itemShrinkTime = 0.2f;

	private ActiveHit _activeHit;
//	private bool other = false;
	protected Vector3 lastHitPosition;

	public Side _side;

	public void Awake()
	{
		_activeHit = ActiveHit.None;

		_skillLifes = -1; // SkillLifes will be initialized in Start, but needs to be set to -1 first!
		_iconLifeList = null;

//		_audioSource = GameObject.Find("ItemHitSound").GetComponent<AudioSource>();
//		_audioReverb = GameObject.Find("ItemHitSound").GetComponent<AudioReverbZone>();

		// Initialize bad-item-hit-effect instance array:
		_badItemHitEffects = new ParticleSystem[5];
		for(int i = 0; i < _badItemHitEffects.Length; ++i)
		{
			GameObject psObj = Instantiate(_badItemHitEffect.gameObject) as GameObject;
			ParticleSystem ps = psObj.GetComponent<ParticleSystem>();
			_badItemHitEffects[i] = ps;
		}

		// Init Arm-Alert as invisible:
		_armAlert.gameObject.SetActive(false);
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

//				Debug.Log (iconGO.transform.position);
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
				SetHit(ItemHit.ActiveHit.Good, hitObject);
	//			_audioReverb.enabled = false;
			}
			else
			{
				SetHit(ItemHit.ActiveHit.Bad, hitObject);
	//			_audioReverb.enabled = true;
			}
		
//		_audioSource.gameObject.transform.position = hitObject.transform.position;
//		_audioSource.Play();
		
			// Deactivate the collided object
			hit.collider.enabled = false;

			// Shrink and deactivate the cought pickup item:
			StartCoroutine(DownSizeItem(hit.transform));
		}

		// Else it might be the finish line: TODO: Hardcoded Tag-Name
		else if(hit.tag.Equals("FinishLine"))
		{
			Debug.Log ("Finish Line was hit!");
			MoveOnTrack motInstance = _armManager.gameObject.GetComponent<MoveOnTrack>();
			StartCoroutine(motInstance.SpeedChange(0.0f, 2.0f, true));
		}
	}

	public IEnumerator DownSizeItem(Transform item)
	{
		Vector3 origScale = item.localScale;
		float curShrinkTime = 0.0f;
		AnimationCurve curve = AnimationCurve.EaseInOut(curShrinkTime, 0.0f, _itemShrinkTime, 1.0f);

		while(curShrinkTime <= _itemShrinkTime)
		{
			curShrinkTime += Time.deltaTime;
			Vector3 minusSize = origScale * curve.Evaluate(curShrinkTime);
			item.localScale = origScale - minusSize;

			yield return new WaitForSeconds(Time.deltaTime);
		}

		item.gameObject.SetActive(false);
	}

	private void StartArmAlert(Material alertMat)
	{
		_armAlert.gameObject.renderer.material = alertMat;

		if(_armAlert.gameObject.activeSelf)
		{
			_curAlertTime = 0.0f;
		}
		else
		{
			StartCoroutine(ArmAlert());
		}
	}

	private IEnumerator ArmAlert()
	{
		_curAlertTime = 0.0f;
		_armAlert.gameObject.SetActive(true);

		while(_curAlertTime < _armAlertDuration)
		{
			_curAlertTime += Time.deltaTime;

			yield return new WaitForSeconds(Time.deltaTime);
		}

		_armAlert.gameObject.SetActive(false);
	}
	
	public void SetHit(ActiveHit hit, GameObject hitObject)
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

			StartArmAlert(_greenAlert);

			_armManager.StartTrail(lastHitPosition);
			_armManager.UpdateScore();
//			RuleSwitcher.UpdateScore(1);
			
			lastItemHit = Time.time;
			break;

		case ActiveHit.Bad:
			if(_armManager.IsInvulnerable == false)
			{
				if(RuleSwitcher.LifesLeft >= 0)
				{
					StartCoroutine(_armManager.BlinkInvulnerable(1.0f));
				}
				badItemHit.transform.position = lastHitPosition;
				goodItemHit.enabled = false;
				badItemHit.enabled = true;
				if(RuleSwitcher.LifesLeft >= 1)
				{
					_iconLifeList[RuleSwitcher.LifesLeft - 1].mainTexture = _iconDead.mainTexture;
				}

				PlaceBadItemEffect(hitObject.transform.position);
				StartArmAlert(_redAlert);

	//			RuleSwitcher.UpdateScore(-1);
				RuleSwitcher.UpdateLife(-1);
				if(RuleSwitcher.LifesLeft <= 0)
				{
					Debug.Log ("NO LIFES LEFT - GAME OVER!");
//					Application.LoadLevel("GameOver");
					MoveOnTrack moveOnTrack = _armManager.GetMoveOnTrackInstance();
					moveOnTrack.TriggerPause(true); // Stop Avatar movement.
				}

				lastItemHit = Time.time;
				#if UNITY_IPHONE || UNITY_ANDROID
					Handheld.Vibrate(); //vibration as feedback for wrong items
				#endif
			}
			break;

		default:
			break;
		}
	}

	private void PlaceBadItemEffect(Vector3 position)
	{
		bool debugCheck = false;

		foreach(ParticleSystem ps in _badItemHitEffects)
		{
			if(!ps.isPlaying)
			{
				ps.transform.position = position;
				ps.Play();

				debugCheck = true;
				break;
			}
		}

		if(debugCheck == false)
		{
			Debug.LogError("No ParticleSystems currently available. If this happens, think about increasing the array size for the particles, " +
			               "that is currently set to 5.");
		}
	}

	// Update is called once per frame
	public void Update ()
	{
		if (Time.time > lastItemHit + 0.3f && _activeHit != ActiveHit.None)
		{
			SetHit(ActiveHit.None, null);
		}
	}
}
