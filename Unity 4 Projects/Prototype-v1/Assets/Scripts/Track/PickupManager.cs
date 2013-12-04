using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupManager : MonoBehaviour 
{
	public CleanTrackData _track = null;

	[HideInInspector]
	public RulesSwitcher _rulesSwitcher;

	public void Awake()
	{
		//Reuse RulesSwitcher between Levels for information transfer
		GameObject rulesSwitcherGameObject = GameObject.Find("Rule Switcher");
		
		if (rulesSwitcherGameObject == null)
		{
			rulesSwitcherGameObject = Instantiate(Resources.Load("Prefabs/Rule Switcher", typeof(GameObject))) as GameObject;
			rulesSwitcherGameObject.name = "Rule Switcher";
		}
		
		_rulesSwitcher = rulesSwitcherGameObject.GetComponent<RulesSwitcher>();
	}

	void Start () 
	{
//		_rulesSwitcher.countdownLabel = GameObject.Find("CountdownLabel").GetComponent<UILabel>();
//		_rulesSwitcher.scoreLabel = GameObject.Find("ScoreLabel").GetComponent<UILabel>();

		GameObject itemContainer = new GameObject();
		itemContainer.name = "ItemContainer";

		// Initialize good and bad pickups:
		foreach(KeyValuePair<PickupLine, List<PickupElementVec3>> pickupLine in _track.pickupContainer.GetLineDict())
		{
			foreach(PickupElementVec3 pickup in pickupLine.Value)
			{
				GameObject item;
				float goodOrEvil = Random.value;

				if(goodOrEvil <= 0.5f)
				{
					GameObject randItem = _rulesSwitcher.GetRandomGoodItem();
					item = Instantiate(randItem, pickup.position, Quaternion.identity) as GameObject;
//					Quaternion rot = item.transform.rotation * pickup.rotation;
//					item.transform.rotation = rot;

					// PFUSCH:
					item.transform.rotation = randItem.transform.localRotation;
				}
				else
				{
					GameObject randItem = _rulesSwitcher.GetRandomBadItem();
					item = Instantiate(randItem, pickup.position, Quaternion.identity) as GameObject;
//					Quaternion rot = item.transform.rotation * pickup.rotation;
//					item.transform.rotation = rot;

					// PFUSCH:
					item.transform.rotation = randItem.transform.localRotation;
				}

//				item.transform.localScale *= 0.02f;
				item.transform.parent = itemContainer.transform;		
			}
		}
	}

	void Update () 
	{
	
	}
}
