#if UNITY_IPHONE || UNITY_ANDROID
#	define MOBILE
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnTrack : MonoBehaviour 
{
	// Config Members:
	public LevelManager _levelManager = null;
	public Transform _camMover = null;
	public float _speed = 1.0f; // Units per Second.
	public SplineLine _spline = SplineLine.CENTER;
	public SplineLine _leftMaxSpline = SplineLine.LEFT1;
	public SplineLine _rightMaxSpline = SplineLine.RIGHT1;

	public float _switchTime = 0.3f;

	public RoadIndicatorTextures _roadIndicatorTextures = null;

	// Skills - For now configureable:
	public float _visSwitchTime = 0.25f; // Config the time, that the items need from low to high opaqueness.
	public float _pickupDefaultAlpha = 0.2f;

	public FinalPointsLabelDisplay _finalPointsDisplay;

	private bool _leftInput = false;
	private bool _rightInput = false;

	private SkillManager _skillManager;
	private int _skillMovement;
	private int _skillVisibility;

	private CleanTrackData _track = null;
	private LevelInfo _levelInfo = null;
	private PickupManager _puManager = null;

	private List<Vector3> _points = new List<Vector3>();
	private Transform _moveObject;
	private Vector3 _lastPos;
	private Vector3 _nextPos;
	private Vector3 _lastSwitchPos;
	private Vector3 _nextSwitchPos;

//	private bool _switchInProgress = false;
//	private List<Vector3> _switchPoints = new List<Vector3>();
	
	private int _splineIndex = 0;
	private int _indexPart = 0;
	private bool _stopMovement = false;
	private bool _enablePause = false;

	private float _curSpeed = 0.0f;

	private float _slowMoBackupSpeed;
	private bool _slowMotionActive = false;

//	private float _splineLength = 0;

	private int _divisor = 20000;

	// The spline, the user wants to move on:
	private SplineLine _switchSpline;

	// Manage visibility of items:
	private int[] _visLineIndexNear = new int[System.Enum.GetNames(typeof(PickupLine)).Length];
	private int[] _visLineIndexFar = new int[System.Enum.GetNames(typeof(PickupLine)).Length];
	private float[] nextItemDistances = new float[System.Enum.GetNames(typeof(PickupLine)).Length];
	private float _visStepSize = 0.1f;
	// Updated implementation...
	private List<Transform> _allPickups;

	[HideInInspector]
	private RuleConfig _ruleConfig; // RuleConfig is set by PickupManager in Start.
	public RuleConfig RuleConfig
	{
		get { return _ruleConfig; }
		set { _ruleConfig = value; }
	}

	public CleanTrackData Track
	{
		get { return _track; }
		private set { _track = value; }
	}

	public PickupManager GetPickupManager()
	{
		return _puManager;
	}

//	public int curLevel = 0; // REMOVE THAT AFTER TESTING!

	private void Awake()
	{
//		LevelManager.CurrentLevel = curLevel;
		// Load Track:
		LevelInfo currentLevelPrefab = _levelManager.GetCurrentLevel();
		GameObject levelObject = Instantiate(currentLevelPrefab.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
		_levelInfo = levelObject.GetComponent<LevelInfo>();
		_track = _levelInfo.Track;
		if(_track == null)
		{
			Debug.LogError("Error: No track could have been loaded!");
		}

		// Load Skills:
		_skillManager = new SkillManager();
		_skillManager.Init();
		
		_skillMovement = _skillManager.GetSkillByName("Agility").CurrentValue;
		_skillVisibility = _skillManager.GetSkillByName("Sight").CurrentValue;
		
//		Debug.Log ("Movement: " + _skillMovement + ", Visibility: " + _skillVisibility);


//		AvatarState.SetStateValue(AvatarState.State.CURRENT_ENERGY, 6); // Test ONLY
	
		EnergyManager.ResetWaitingTime();
		AvatarState.DecreaseStateValue(AvatarState.State.CURRENT_ENERGY);
		AvatarState.Save();
	}

	// Use this for initialization
	private void Start() {
		// Init the moveable object (Avatar):
		_moveObject = transform;

		// Get Access to the PickupManager:
		_puManager = gameObject.GetComponent<PickupManager>() as PickupManager;
		if(!_puManager)
			Debug.LogError("Error: No PickupManager available!\nPlease add a PickupManager Script to the MoveOnTrack-Object.");

		// Init PickupManager:
		_puManager.InitPickups(_track);

		// Set the maximum score for the LevelInfo (Points & Rating)
//		_levelInfo.SetMaxScore(_puManager.GoodItemAmount);
//		Debug.Log ("Max Score was set to " + _puManager.GoodItemAmount);

		// Init Controlpoints for current spline:
		_points = _track.splineContainer.GetSpline(_spline);
		
		// Initilialize Avatar position:
		_moveObject.position = GetPosOnSpline(0, 0, _points);
		_lastPos = _moveObject.position;
		_nextPos = _lastPos;

		// Init SwitchSpline:
		_switchSpline = _spline;

		// Init TrackIndicator Plane Material:
		if(_roadIndicatorTextures == null)
		{
			Debug.LogError("Error: RoadIndicatorTextures has not been set!");
		}
		Texture indicatorTex = _roadIndicatorTextures.GetTextureLevel(_skillMovement);
		if(indicatorTex != null)
		{
			// Change material for all trackParts:
			foreach(Transform plane in _track.splinePlanes)
			{
				plane.renderer.material.mainTexture = indicatorTex;
			}
		}
		else
		{
			Debug.LogError("Error: Level of skillMovement ("+_skillMovement+") does not have a texture!");
		}

		// Init item visibility: (make all Items transparent...)
		Dictionary<PickupLine, List<PickupManager.PickupLev>> pickupContainer = _puManager.GetPickups().GetLineDict();
		foreach(KeyValuePair<PickupLine, List<PickupManager.PickupLev>> pickupLine in pickupContainer)
		{
			foreach(PickupManager.PickupLev levItem in pickupLine.Value)
			{
				Color tempCol = levItem.Pickup.renderer.material.color;
				tempCol.a = 0.0f;
				levItem.Pickup.renderer.material.color = tempCol;
			}
		}

		// Init distances to the next pickup with maximum-float:
		for(int i = 0; i < nextItemDistances.Length; ++i)
		{
			nextItemDistances[i] = float.MaxValue;
		}
		// Calculate the first -skill-distance- for normal visibility:
		float visStartDist = _visStepSize * _skillVisibility;
//		MoveVisLineForDist(visStartDist);
		UpdatePickupVisibility(visStartDist, visStartDist * 2.0f); // TODO: FarDist

		// Initialize pickup list:

	}
	
	// Update is called once per frame
	private void Update() 
	{
		// ---- INPUT START ----
		// No input during pause: (Else, it would move e.g. one right after pressing play again...)
		if(_enablePause == false)
		{
// Input for Editor or Win / Linux / Mac:
#			if UNITY_EDITOR || UNITY_STANDALONE
			if(Input.GetKey(KeyCode.A))
			{
				_leftInput = true;
			}
			else if(Input.GetKey(KeyCode.D))
			{
				_rightInput = true;
			}
// Input for mobile devices:
//#			elif MOBILE
//			if(Input.GetMouseButton(0))
//			{
//				float touchPos = Input.mousePosition.x;
//
//				if(touchPos < Screen.width * 0.5f)
//				{
//					leftInput = true;
//				}
//				else
//				{
//					rightInput = true;
//				}
//			}
#			endif
		}

		if (_switchSpline == _spline)
		{
			if(_leftInput == true)
			{
				if(_switchSpline > _leftMaxSpline)
				{
					if(SplineAccessGaranted(_switchSpline-1, _skillMovement-1))
					{
						_switchSpline--;
					}
				}
				_leftInput = false;
			}
			else if(_rightInput == true)
			{
				if(_switchSpline < _rightMaxSpline)
				{
					if(SplineAccessGaranted(_switchSpline+1, _skillMovement-1))
					{
						_switchSpline++;
					}
				}
				_rightInput = false;
			}
		}
		// ---- INPUT END ----

		if(_stopMovement == false && _enablePause == false) // Did not yet reach the end of spline and does not want a pause...
		{
			if(_curSpeed == 0.0f)
			{
				StartCoroutine(SpeedChange(_speed));
			}

			// Update Pickup Visibility:
//			MoveVisLineForDist(_curSpeed * Time.deltaTime);
			UpdatePickupVisibility(_visStepSize * _skillVisibility, _visStepSize * _skillVisibility * 2.0f);

			// Update Object Position:
			_lastPos = _nextPos;
			_lastSwitchPos = _nextSwitchPos;
			_nextPos = GetNextStepOnSpline(_spline, ref _splineIndex, ref _indexPart, _curSpeed * Time.deltaTime, true);

			// Update Camera Position:
			Vector3 camPos = GetPosOnSpline(_splineIndex, (float)_indexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.CENTER));
			_camMover.position = camPos;

			// Update Rotations:
			Vector3 curDir = _nextPos - _lastPos;
//			Debug.Log ("1"+_moveObject.rotation);
//			Debug.Log ("2"+Quaternion.LookRotation(curDir));
			if(curDir != Vector3.zero)
			{
				Quaternion nextObjRot = Quaternion.Slerp(_moveObject.rotation, Quaternion.LookRotation(curDir), 0.1f);
				_moveObject.rotation = nextObjRot;
			
				// Camera Rotation:
				Quaternion nextCamRot = Quaternion.Slerp(_camMover.rotation, Quaternion.LookRotation(curDir), 0.1f);
				_camMover.rotation = nextCamRot;
			}

			if(_switchSpline != _spline)
			{
				_switchTime+=Time.deltaTime*6;

				_nextSwitchPos = GetPosOnSpline(_splineIndex, (float)_indexPart / (float)_divisor, _track.splineContainer.GetSpline(_switchSpline));
				_lastSwitchPos = GetPosOnSpline(_splineIndex, (float)_indexPart / (float)_divisor, _track.splineContainer.GetSpline(_spline));

				if(_switchTime<1.0f)
				{
					Vector3 posProp = Vector3.Slerp(_lastSwitchPos, _nextSwitchPos, _switchTime);

					// Finally, move the object:
					_moveObject.position = posProp;
				}
				else
				{
					_switchTime=0;
					_spline = _switchSpline;
					_moveObject.position = _nextSwitchPos;
					_nextPos = _nextSwitchPos;
					_lastPos = _nextPos;
				}
			}
			else
			{
				_switchTime=0;
				_moveObject.position = _nextPos;
			}
		}
		else if(_enablePause == true)
		{
			// Currently nothing to do here...
			// TODO: Maybe I have to fade something out, etc. during the pause... And should not forget to fade it back in afterwards :P
		}
		else // End of spline was reached.
		{
			// Rotate Camera slowly in the Background...
			_camMover.Rotate(Vector3.up * 10 * Time.deltaTime);
		}
	}
	
	private Vector3 GetNextStepOnSpline(SplineLine spline, ref int splineIndex, ref int indexPart, float speed, bool avatarMovement = false)
	{
		List<Vector3> points = _track.splineContainer.GetSpline(spline);
		Vector3 nextPos = GetPosOnSpline(splineIndex, (float)_indexPart/(float)_divisor, points);
		float curDist = 0;
		
		while(true)
		{
			if(indexPart == _divisor)
			{
				splineIndex++;
				
				if(splineIndex < points.Count)
				{
					indexPart = 0;
				}
			}

			// TODO: Check StepSize again... 20 might be too high... Or _divisor is too high.
			indexPart += 20;

//			if(avatarMovement == true && splineIndex >= points.Count - 1)
//			{
//				ReachedEndOfSpline();
//				break;
//			}
			
			if(splineIndex < 0) splineIndex = 0;
			if(splineIndex > points.Count - 2) splineIndex = points.Count - 2;
			if(indexPart < 0) indexPart = 0;
			if(indexPart > _divisor) indexPart = _divisor;

			// Lower the Speed to zero, if the end of the track is reached...
//			if(splineIndex > points.Count - 4)
//			{
//				StartCoroutine(SpeedChange(0.0f, 1.0f, true));
//				// TODO: EndSequence of level can be started here!
//			}

			Vector3 pos = GetPosOnSpline(splineIndex, (float)indexPart/(float)_divisor, points);
			curDist += Vector3.Distance(nextPos, pos);
			nextPos = pos;
			//			Debug.Log ("curDist: " + curDist);
//			if(curDist >= speed * Time.deltaTime)
			if(curDist >= speed)
			{
//				Debug.Log ("Dist: " + Vector3.Distance(nextPos, pos));
				break;
			}
		}

		return nextPos;
	}

	/**
	 * GetPosOnSpline calculates a position between 2 neighbour controlPoints.
	 * @param controlPointIndex is the index of the current control point on the spline.
	 * @param section is the relative position (0 - 1) on the spline between the current nad the next control point.
	 * @return the Position on the spline.
	 **/
	Vector3 GetPosOnSpline(int controlPointIndex, float section, List<Vector3> points)
	{
		// float.Epsilon
		if(section < 0 || section > 1.0f)
		{
			Debug.LogError ("Section is out of range (0.0f - 1.0f) -> section: "+section);
		}
		
		int size = points.Count;
//		Vector3 last= points[0];
		
		
		float t = section;
		int p = controlPointIndex;
		
		float h0 = 2 * t * t * t - 3 * t * t + 1;
		float h1 = -2 * t * t * t + 3 * t * t;
		float h2 = t * t * t - 2 * t * t + t;
		float h3 = t * t * t - t * t;
		
		int p0 = p;
		int p_1 = (size - 1 + p) % size;
		int pp1 = (p + 1) % size;
		
		float firstvec=1;
		float secvec=1;
		
		if(controlPointIndex==0)
		{
			firstvec=0;
		}
		if(controlPointIndex==size-2)
		{
			secvec=0;
		}
		Vector3 Tp1 = ((points[p0]- points[p_1])
		               + (points[pp1] - points[p])) *firstvec* (1 - 0.65f); // TODO: Change hardcoded!
		int pp2 = (p + 2) % size;
		Vector3 Tp2 = ((points[pp1] - points[p0])
		               + (points[pp2] - points[pp1])) *secvec* (1 -0.65f); // TODO: Change hardcoded!
		
		Vector3 T1 = points[(p) % size];
		Vector3 T2 = points[(p + 1) % size];
		
		Vector3 P = T1 * h0 + T2 * h1 + Tp1 * h2 + Tp2 * h3;
		
//		Debug.DrawLine(last,P,Color.blue);
//		last=P;
		
		return P;
	}

	// Calculates the Length on a Spline between the Start-Control-Point and the next Control-Point:
	private float GetLengthBetweenCtrlPoints(SplineLine spline, int startCtrlPntInd)
	{
		float length = 0.0f;
		List<Vector3> points = _track.splineContainer.GetSpline(spline);

		// Is it the last point on the spline (or no point-index at all)?
		if(startCtrlPntInd >= points.Count - 1 || startCtrlPntInd < 0)
		{
			Debug.LogWarning("Warning: Wrong Parameters for GetLengthBetweenCtrlPoints...");
			return 0.0f;
		}

		// It is any point on the Spline:
		Vector3 curPos = GetPosOnSpline(startCtrlPntInd, 0.0f, points);
		const int divisor = 10;
		for(int i = 1; i <= divisor; ++i)
		{
			Vector3 nextPos = GetPosOnSpline(startCtrlPntInd, (float)i/(float)divisor, points);
			length += Vector3.Distance(curPos, nextPos);
			curPos = nextPos;
		}

		return length;
	}

	// TODO: Maybe this should be part of the Level/Skill Manager?!
	private bool SplineAccessGaranted(SplineLine line, int movementLevel)
	{
		int iLine = (int)line;
		int halfMovement = (int)(movementLevel / 2);

		// Even level:
		if(movementLevel % 2 == 0)
		{
			if(iLine >= ((int)SplineLine.CENTER - halfMovement) && iLine <= ((int)SplineLine.CENTER + halfMovement))
			{
				return true;
			}
		}
		// Odd level:
		else
		{
			// One Spline more at left side:
			if(iLine >= ((int)SplineLine.CENTER - halfMovement - 1) && iLine <= ((int)SplineLine.CENTER + halfMovement))
			{
				return true;
			}
		}

		return false;
	}

	// TODO: Optimize this algorithm. Currently, it is checking the distance between avatar and every other
	// pickup. It would be better to only check these, that are close -> Find optimization!
	private void UpdatePickupVisibility(float distNear, float distFar)
	{
		Vector3 leftPoint3 = GetPosOnSpline(_splineIndex, (float)_indexPart / (float)_divisor, _track.splineContainer.GetSpline(SplineLine.LEFT5));
		Vector3 rightPoint3 = GetPosOnSpline(_splineIndex, (float)_indexPart / (float)_divisor, _track.splineContainer.GetSpline(SplineLine.RIGHT5));
		Vector2 leftPoint = new Vector2(leftPoint3.x, leftPoint3.z);
		Vector2 rightPoint = new Vector2(rightPoint3.x, rightPoint3.z);

		PickupContainer<PickupManager.PickupLev> allPickups = _puManager.GetPickups();

		for(int line = (int)_leftMaxSpline; line <= (int)_rightMaxSpline; ++line)
		{
			List<PickupManager.PickupLev> linePickups = allPickups.GetLine((PickupLine)line);

//			_visLineIndex[line] = 0; // TODO: This should not be neccessary... (optimization reset.)

//			for(; _visLineIndex[line] < linePickups.Count; _visLineIndex[line]++)
//			{
//				if(_visLineIndexNear[line] >= linePickups.Count)
//				{
//					// No next pickup items available on this line.
////					break;
//					continue;
//				}
			if(_visLineIndexNear[line] < linePickups.Count)
			{

				Transform pickup = linePickups[_visLineIndexNear[line]].Pickup;

				// HACK: Also calc distance between avatar and pickup item (to check, if items are irrelevant for the triangle-method):
				float airLine = (_moveObject.position - pickup.position).magnitude;
				if(airLine <= (distNear * 1.3f))
				{
					Vector2 topPoint = new Vector2(pickup.position.x, pickup.position.z);
					
					float straightDist = GetStraightDistance(leftPoint, rightPoint, topPoint);

					if(straightDist <= distNear)
					{
						StartCoroutine(ChangePickupVisability(pickup, _visSwitchTime));
						//						Debug.Log ("heightC: " + heightC, pickup);
						_visLineIndexNear[line]++;
					}
				}
			}
			if(_visLineIndexFar[line] < linePickups.Count)
			{
				Transform pickup = linePickups[_visLineIndexFar[line]].Pickup;

				// HACK: Also calc distance between avatar and pickup item (to check, if items are irrelevant for the triangle-method):
				float airLine = (_moveObject.position - pickup.position).magnitude;
				if(airLine <= (distFar * 1.3f))
				{
					Vector2 topPoint = new Vector2(pickup.position.x, pickup.position.z);
					
					float straightDist = GetStraightDistance(leftPoint, rightPoint, topPoint);

					if(straightDist <= distFar)
					{
						// Update Visablity for Far-Distance
						StartCoroutine(StartPickupSemiVisability(pickup, _visSwitchTime));
						
						_visLineIndexFar[line]++;
					}
				}
			}

//					if(heightC <= distFar && heightC > distNear && airLine < (distFar * 2f))
//					{
//						// Update Visablity for Far-Distance
//						StartCoroutine(StartPickupSemiVisability(pickup, _visSwitchTime));
//
////						_visLineIndex[line]++;
//					}
//					else if(heightC <= distNear && airLine < (distNear * 2f))
//					{
//						StartCoroutine(ChangePickupVisability(pickup, _visSwitchTime));
////						Debug.Log ("heightC: " + heightC, pickup);
//						_visLineIndexNear[line]++;
//					}
//					else
//					{
//						// All other items on this line are far away...
//						done = true; // TODO: This does NOT work as optimazation... Seems to have the wrong order in the pickup container lists...
//					}
//				}
//			}
		}
	}

	private float GetStraightDistance(Vector2 leftPoint, Vector2 rightPoint, Vector2 topPoint)
	{
		// Calculating the straight distance from the avatar to the pickup by triangulating it and using the triangles hight.
		float lenA = (rightPoint - topPoint).magnitude;
		float lenB = (leftPoint - topPoint).magnitude;
		float lenC = (leftPoint - rightPoint).magnitude;
		float semiperimeter = (lenA + lenB + lenC) / 2.0f;
		
		float discriminant = semiperimeter * (semiperimeter - lenA) * (semiperimeter - lenB) * (semiperimeter - lenC);
		if(discriminant < 0.0f) discriminant *= -1.0f; // Discriminant must be positive!
		float heightC = (2.0f / lenC) * Mathf.Sqrt(discriminant);

		return heightC;
	}
	
	//	// TO DO: This seems to have a bug! (Items get visible to early.)
//	private void MoveVisLineForDist(float dist)
//	{
//		float checkedDist = 0;
//		Vector3 checkPos = GetPosOnSpline(_visSplineIndex, (float)_visIndexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.CENTER));
//		Dictionary<PickupLine, List<PickupElementVec3>> pickupLines = _track.pickupContainer.GetLineDict();
//
//		while(checkedDist < dist)
//		{
//			Vector3 curSplinePos = GetPosOnSpline(_visSplineIndex, (float)_visIndexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.LEFT5));
////			Vector3 curRightPos = GetPosOnSpline(_visSplineIndex, (float)_visIndexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.RIGHT5));
//
//			foreach(KeyValuePair<PickupLine, List<PickupElementVec3>> pickupLine in pickupLines)
//			{
//				int tempIndex = (int)pickupLine.Key;
//				
//				if(itemVisibilityIndizes[tempIndex] >= pickupLine.Value.Count)
//				{
//					// All items on this line done...
//					continue;
//				}
//				
//				Vector3 curPickupPos = pickupLine.Value[itemVisibilityIndizes[tempIndex]].position;
////				float tempDist = Vector3.Distance(curLeftPos, curPickupPos) + Vector3.Distance(curRightPos, curPickupPos);
//				float tempDist = Vector3.Distance(curSplinePos, curPickupPos);
//				
//				if(nextItemDistances[tempIndex] > tempDist)
//				{
//					nextItemDistances[tempIndex] = tempDist;
//				}
//				else
//				{
//					// Change visibility (transparency) of the items, that are in the closer distance:
//					Transform curTrans = _puManager.GetPickups().GetLine(pickupLine.Key)[itemVisibilityIndizes[tempIndex]].Pickup;
//					StartCoroutine(ChangePickupVisability(curTrans, _visSwitchTime));
//					
//					itemVisibilityIndizes[tempIndex]++;
//					nextItemDistances[tempIndex] = float.MaxValue;
//				}
//			}
//			// This distance calculation is not perfect, but it's doing its job for the moment...
//			float nextStep = (_visStepSize > dist ? dist : _visStepSize);
//			Vector3 nextPos = GetNextStepOnSpline(SplineLine.CENTER, ref _visSplineIndex, ref _visIndexPart, nextStep);
//			checkedDist += Vector3.Distance(nextPos, checkPos);
//			checkPos = nextPos;
//		}
//	}

	// Changes transparency and color to full visibility:
	public IEnumerator ChangePickupVisability(Transform item, float changeTime)
	{
		float startAlpha = item.renderer.material.color.a;
		AnimationCurve curve = new AnimationCurve(new Keyframe(0, startAlpha), new Keyframe(changeTime, 1.0f));
		AnimationCurve colorCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(changeTime, 1.0f));
		float curTime = 0.0f;
		PickupInfo puInfo = item.GetComponent<PickupInfo>();
		Color startColor = item.renderer.material.color;
		Color aimColor = _ruleConfig.GetPickupColor(puInfo.PickupColor);

		while(curTime < changeTime)
		{
			curTime += Time.deltaTime;

			Color tempCol = Color.Lerp(startColor, aimColor, colorCurve.Evaluate(curTime));
			tempCol.a = curve.Evaluate(curTime);
			item.renderer.material.color = tempCol;

			yield return new WaitForSeconds(Time.deltaTime);
		}
	}

	// Changes pickup from invisible to black and half transparency:
	private IEnumerator StartPickupSemiVisability(Transform item, float changeTime)
	{
		float startAlpha = item.renderer.material.color.a;

		if(startAlpha > _pickupDefaultAlpha)
		{
			// This will be the case, if the Sight-Gift has been used and all pickups are already fully visible.
			return false;
		}

		AnimationCurve curve = new AnimationCurve(new Keyframe(0, startAlpha), new Keyframe(changeTime, _pickupDefaultAlpha));
		float curTime = 0.0f;
		
		while(curTime < changeTime)
		{
			curTime += Time.deltaTime;

			Color tempCol = item.renderer.material.color;
			tempCol.a = curve.Evaluate(curTime);
			item.renderer.material.color = tempCol;

			yield return new WaitForSeconds(Time.deltaTime);
		}
	}

	public IEnumerator SpeedChange(float aimSpeed, float duration = 1.0f, bool endOfSpline = false)
	{
		float curTime = 0.0f;
		AnimationCurve curve = AnimationCurve.EaseInOut(curTime, _curSpeed, duration, aimSpeed);

		while(curTime < duration)
		{
			curTime += Time.deltaTime;

			// HACK: Don't know why there is such a huge problem with floats in C# -.-
			if(curTime >= duration)
			{
				_curSpeed = aimSpeed;
				break;
			}

			_curSpeed = curve.Evaluate(curTime);
			
			yield return new WaitForSeconds(Time.deltaTime);
		}

		if(endOfSpline && !_stopMovement)
		{
			ReachedEndOfSpline();
		}
	}

	private void ReachedEndOfSpline()
	{
		_stopMovement = true;

		_finalPointsDisplay.ShowFinalPoints(_levelInfo, _skillManager, _levelManager, _puManager.GoodItemAmount);
	}

	public void TriggerPause(bool enable)
	{
		_enablePause = enable;
	}

	public void ActivateSlowMotion()
	{
		if(_slowMotionActive == false)
		{
			_slowMoBackupSpeed = _curSpeed;

			StartCoroutine(SpeedChange(_speed / 2.0f, 0.5f));

			_slowMotionActive = true;
		}
	}

	public void DisableSlowMotion()
	{
		if(_slowMotionActive == true)
		{
			// TODO: Hardcoded time of 2 Seconds... (Same in ActivateSlowMotion Script)
			StartCoroutine(SpeedChange(_slowMoBackupSpeed, 2.0f));

			_slowMotionActive = false;
		}
	}

	public float GetCurrentSpeed()
	{
		return _curSpeed;
	}

	public void GiveLeftInput()
	{
		// Input for mobile devices:
#		if MOBILE
		if(_enablePause == false && _switchSpline == _spline)
		{
			_leftInput = true;
		}
#		endif
	}

	public void GiveRightInput()
	{		
		// Input for mobile devices:
#		if MOBILE
		if(_enablePause == false && _switchSpline == _spline)
		{
			_rightInput = true;
		}
#		endif
	}
}
