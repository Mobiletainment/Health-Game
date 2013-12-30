using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupManager : MonoBehaviour 
{
	// PickupLev is used to manage the pickup levitation:
	public class PickupLev
	{
		public PickupLev(Transform pickup)
		{
			Pickup = pickup;
			StartPos = pickup.position;
		}

		private float _curTime;

		public Transform Pickup { get; private set;	}
		public Vector3 StartPos { get; private set; }
		public float CurTime 
		{ 
			get
			{
				return _curTime;
			}
			set 
			{
				_curTime = value;
				while(_curTime > 1.0f)
				{
					_curTime -= 1.0f;
				}
			}
		}
	}

	public CleanTrackData _track = null;
	public AnimationCurve _levitationCurve;
	public float _levitationHight = 0.015f;
	public float _levitationTime = 2.0f;

	public RuleConfig _ruleConfig;

	[HideInInspector]
	public RulesSwitcher _rulesSwitcher; // DEPRECATED

	private PickupContainer<PickupLev> _pickups = new PickupContainer<PickupLev>();

	public void Awake()
	{
		//Reuse RulesSwitcher between Levels for information transfer
		GameObject rulesSwitcherGameObject = GameObject.Find("Rule Switcher");
		
		if (rulesSwitcherGameObject == null)
		{
			Debug.Log ("RuleSwitcher was null.");
			rulesSwitcherGameObject = Instantiate(Resources.Load("Prefabs/Rule Switcher", typeof(GameObject))) as GameObject;
			rulesSwitcherGameObject.name = "Rule Switcher";
		}
		
		_rulesSwitcher = rulesSwitcherGameObject.GetComponent<RulesSwitcher>(); // DEPRECATED

		GameObject itemContainer = new GameObject();
		itemContainer.name = "ItemContainer";
		
		// Initialize good and bad pickups:
		foreach(KeyValuePair<PickupLine, List<PickupElementVec3>> pickupLine in _track.pickupContainer.GetLineDict())
		{
			foreach(PickupElementVec3 pickup in pickupLine.Value)
			{
				/*
				GameObject item;
				float goodOrEvil = Random.value;
				
				if(goodOrEvil <= 0.5f)
				{
					GameObject randItem = _rulesSwitcher.GetRandomGoodItem();
					item = Instantiate(randItem, pickup.position, pickup.rotation) as GameObject;
					item.transform.rotation *= randItem.transform.localRotation;
				}
				else
				{
					GameObject randItem = _rulesSwitcher.GetRandomBadItem();
					item = Instantiate(randItem, pickup.position, pickup.rotation) as GameObject;
					item.transform.rotation *= randItem.transform.localRotation;
				}
				*/

				// Create random item:
				PickupInfo.Shape shape = (PickupInfo.Shape)Random.Range(0, 2); // 0-1 (min inclusive, max exclusive)
				PickupInfo.Color color = (PickupInfo.Color)Random.Range(0, 2); // 0-1 (min inclusive, max exclusive)

				GameObject item = Instantiate(_ruleConfig.GetPickupShape(shape).gameObject, pickup.position, pickup.rotation) as GameObject;
				PickupInfo pickupItem = item.AddComponent<PickupInfo>();
				pickupItem.Initialize(shape, color);
				item.transform.rotation *= _ruleConfig.GetPickupShape(shape).localRotation;
				item.transform.parent = itemContainer.transform;
				item.renderer.material.color = _ruleConfig.GetPickupColor(color);
				
				// Add items to the pickup-list:
				PickupLev pickupLevitation = new PickupLev(item.transform);
				pickupLevitation.CurTime = Random.Range(0.0f, 1.0f);
				_pickups.GetLine(pickupLine.Key).Add(pickupLevitation);
			}
		}
	}

	public void Start() 
	{
		// MoveOnTrack and other classes need instances, that are saved here in PickupManager, so
		// use the Awake() method to init everything that is needed outside!
	}

	public void Update() 
	{
		// Let the pickups levitate:
		foreach(KeyValuePair<PickupLine, List<PickupLev>> pickupLines in _pickups.GetLineDict())
		{
			foreach(PickupLev pickup in pickupLines.Value)
			{
				pickup.CurTime += Time.deltaTime / _levitationTime;

				Vector3 nextPos = pickup.StartPos;
				nextPos.y += _levitationCurve.Evaluate(pickup.CurTime) * _levitationHight;

				pickup.Pickup.position = nextPos;
			}
		}
	}

	public PickupContainer<PickupLev> GetPickups()
	{
		return _pickups;
	}
}
