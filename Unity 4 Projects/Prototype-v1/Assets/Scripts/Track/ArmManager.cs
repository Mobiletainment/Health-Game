using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmManager : MonoBehaviour 
{
	// Public config member:
	public InGameUIController _uiController;

	public Camera _mainCamera;
	public Camera _uiCamera;
	public TrailRenderer _trail;
	public Transform _trailAimPos;

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

	// TODO: BUT HOW? :/
	public void StartTrail(Vector3 startPos)
	{
//		Vector3 screenPointStart = _mainCamera.WorldToScreenPoint(startPos);
//		screenPointStart -= _mainCamera.transform.position;
//		Vector3 screenPointStart = startPos - _mainCamera.transform.position;
//		startPos.z = _uiCamera.nearClipPlane;
//		screenPointStart.z = _uiCamera.nearClipPlane;
//		Vector3 screenPointEnd = _camera.WorldToScreenPoint(_trailAimPos.position);
//		screenPointEnd.z = _camera.nearClipPlane;
//		Vector3 worldPoint = _trailAimPos.position;
//		worldPoint.z = _camera.nearClipPlane;
//		worldPoint = _camera.ScreenToWorldPoint(_trailAimPos.position);
//		StartCoroutine(MoveTrail(screenPointStart, _trailAimPos.position, 1.0f));
//		StartCoroutine(MoveTrail(startPos, _trailAimPos, 1.0f));
//		Debug.Log(screenPointStart + " : " + screenPointEnd);
	}

	public IEnumerator MoveTrail(Vector3 from, Vector3 to, float duration)
	{
		GameObject trail = Instantiate(_trail.gameObject, from, Quaternion.identity) as GameObject;
		float curTime = 0.0f;
//		Vector3 worldPoint;

		while(curTime < duration)
		{
			curTime += Time.deltaTime;

//			worldPoint = _trailAimPos.position;
//			worldPoint.z = _camera.nearClipPlane;
//			worldPoint = _camera.ScreenToWorldPoint(_trailAimPos.position);

			trail.transform.position = Vector3.Lerp(from, to, curTime / duration);

			yield return new WaitForSeconds(Time.deltaTime);
		}

//		worldPoint = _trailAimPos.position;
//		worldPoint.z = _camera.nearClipPlane;
//		worldPoint = _camera.ScreenToWorldPoint(_trailAimPos.position);
		
		trail.transform.position = to;
	}
}
