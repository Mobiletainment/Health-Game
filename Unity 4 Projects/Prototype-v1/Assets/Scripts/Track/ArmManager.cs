using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmManager : MonoBehaviour 
{
	// Public config member:
	public InGameUIController _uiController;

	// Member:
	private MoveOnTrack _moveOnTrackInstance;
	private bool _invulnerable;

	// Getter & Setter:
	public bool IsInvulnerable
	{
		get { return _invulnerable; }
		private set { _invulnerable = value; }
	}

	// Methods:

	// Use this for initialization
	void Awake() 
	{
		// Get Access to the MoveOnTrack Instance:
		_moveOnTrackInstance = gameObject.GetComponent<MoveOnTrack>();
		if(!_moveOnTrackInstance)
			Debug.LogError("Error: No MoveOnTrackInstance available!\nPlease add a MoveOnTrack Script to the ArmManager-Object.");
	}

	public IEnumerator BlinkInvulnerable(float blinkTime)
	{
		IsInvulnerable = true;
		float endTime = Time.time + blinkTime;

		// Get a list of all ACTIVE renderer components in the child objects of the avatar:
		List<Renderer> childrenRenderer = new List<Renderer>();
		Renderer[] allChildrenRenderer = GetComponentsInChildren<Renderer>();
		foreach(Renderer ren in allChildrenRenderer)
		{
			if(ren.enabled)
			{
				childrenRenderer.Add(ren);
			}
		}

		while(Time.time < endTime)
		{
			// Disable all renderer:
			foreach(Renderer ren in childrenRenderer)
			{
				ren.enabled = false;
			}
			yield return new WaitForSeconds(0.15f);
			// Enable all renderer:
			foreach(Renderer ren in childrenRenderer)
			{
				ren.enabled = true;
			}
			yield return new WaitForSeconds(0.15f);
		}

		IsInvulnerable = false;
	}

	public void UpdateScore()
	{
		Debug.Log ("ArmManager: Update Score!");
		_uiController.UpdateScore(_moveOnTrackInstance._levelManager.GetCurrentLevel(), 1);
	}
}
