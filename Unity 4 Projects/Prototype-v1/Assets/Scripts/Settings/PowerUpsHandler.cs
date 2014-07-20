using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;



public class PowerUpsHandler : MonoBehaviour, INetworkTransfer {
	protected ECPNManager backend;
	// Use this for initialization
	void Start () {

		backend = GameObject.Find("ComponentManager").GetComponent<ECPNManager>();

		//Enable testing with dummy user
		//UserManager.Instance.SetUsername("david");

		InvokeRepeating("GetPowerUpsAsync", 0.0f, 60.0f); // fetches power ups every 60 seconds
		//GetPowerUpsAsync();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetPowerUpsAsync()
	{
		//Debug.Log("Fetching Power Ups");
		backend.FetchPowerUps(this);
	}

	public void ReceivedResponse(string response)
	{
		Debug.Log(response);
		try
		{
			var dict = Json.Deserialize(response) as Dictionary<string,object>;
			SetAvatarStateValue(AvatarState.State.GIFT_ENERGY_BOOST, dict);
			SetAvatarStateValue(AvatarState.State.GIFT_FREE_SIGHT, dict);
			SetAvatarStateValue(AvatarState.State.GIFT_RESURRECTION, dict);
			SetAvatarStateValue(AvatarState.State.GIFT_SLOW_MOTION, dict);
			
			AvatarState.Save();

			//At this point all power ups have been successfully set
			//Delete them from server
			backend.FetchPowerUps(this, true); //Sets the available Power-Ups on Server to 0

		}
		catch (Exception ex)
		{
			Debug.LogError("Power Ups could not be retrieved! " + ex.Message);	
		}
	}

	protected void SetAvatarStateValue(AvatarState.State state, Dictionary<string, object> dict)
	{
		int powerUps = Convert.ToInt32((dict[state.ToString()]));
		AvatarState.IncreaseStateValue(state, powerUps);
		Debug.Log(String.Format("Saved Power-Up. Name: {0}, Amount: {1}", state.ToString(), powerUps));
	}
}
