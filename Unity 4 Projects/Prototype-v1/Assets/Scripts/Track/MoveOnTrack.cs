#if UNITY_IPHONE || UNITY_ANDROID
#	define MOBILE
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnTrack : MonoBehaviour 
{
	// Config Members:
	public CleanTrackData _track = null;
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

	private SkillManager _skillManager;
	private int _skillMovement;
	private int _skillVisibility;

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

//	private float _splineLength = 0;

	private int _divisor = 20000;

	// The spline, the user wants to move on:
	public SplineLine _switchSpline;

	// Manage visibility of items:
	private int[] itemVisibilityIndizes = new int[System.Enum.GetNames(typeof(PickupLine)).Length];
	private float[] nextItemDistances = new float[System.Enum.GetNames(typeof(PickupLine)).Length];
	private int _visSplineIndex = 0;
	private int _visIndexPart = 0;
	private float _visStepSize = 0.1f;

	void Awake()
	{
		_skillManager = new SkillManager();
		_skillManager.Init();

		_skillMovement = _skillManager.GetSkillByName("Agility").CurrentValue;
		_skillVisibility = _skillManager.GetSkillByName("Sight").CurrentValue;

		Debug.Log ("Movement: " + _skillMovement + ", Visibility: " + _skillVisibility);
	}

	// Use this for initialization
	void Start () {
		// Init the moveable object (Avatar):
		_moveObject = transform;

		// Get Access to the PickupManager:
		_puManager = gameObject.GetComponent<PickupManager>() as PickupManager;
		if(!_puManager)
			Debug.LogError("Error: No PickupManager available!\nPlease add a PickupManager Script to the MoveOnTrack-Object.");

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
				tempCol.a = _pickupDefaultAlpha;
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
		MoveVisLineForDist(visStartDist);
	}
	
	// Update is called once per frame
	void Update() 
	{
		// ---- INPUT START ----
		bool leftInput = false;
		bool rightInput = false;
// Input for Editor or Win / Linux / Mac:
#		if UNITY_EDITOR || UNITY_STANDALONE
		if(Input.GetKey(KeyCode.A))
		{
			leftInput = true;
		}
		else if(Input.GetKey(KeyCode.D))
		{
			rightInput = true;
		}
// Input for mobile devices:
#		elif MOBILE
		if(Input.GetMouseButton(0))
		{
			float touchPos = Input.mousePosition.x;

			if(touchPos < Screen.width * 0.5f)
			{
				leftInput = true;
			}
			else
			{
				rightInput = true;
			}
		}
#		endif


		if (_switchSpline==_spline)
		if(leftInput == true)
		{
			if(_switchSpline > _leftMaxSpline)
			{
				if(SplineAccessGaranted(_switchSpline-1, _skillMovement))
				{
					_switchSpline--;
				}
			}
		}
		else if(rightInput == true)
		{
			if(_switchSpline < _rightMaxSpline)
			{
				if(SplineAccessGaranted(_switchSpline+1, _skillMovement))
				{
					_switchSpline++;
				}
			}
		}
		// ---- INPUT END ----

		// Update Pickup Visibility:
		MoveVisLineForDist(_speed * Time.deltaTime);

		// Update Object Position:
		_lastPos = _nextPos;
		_lastSwitchPos = _nextSwitchPos;
		_nextPos = GetNextStepOnSpline(_spline, ref _splineIndex, ref _indexPart, _speed * Time.deltaTime);

		// Update Camera Position:
		Vector3 camPos = GetPosOnSpline(_splineIndex, (float)_indexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.CENTER));
		_camMover.position = camPos;

		// Update Rotations:
		Vector3 curDir = _nextPos - _lastPos;
		Quaternion nextObjRot = Quaternion.Slerp(_moveObject.rotation, Quaternion.LookRotation(curDir), 0.1f);
		_moveObject.rotation = nextObjRot;
		// Camera Rotation:
		Quaternion nextCamRot = Quaternion.Slerp(_camMover.rotation, Quaternion.LookRotation(curDir), 0.1f);
		_camMover.rotation = nextCamRot;

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
	
	private Vector3 GetNextStepOnSpline(SplineLine spline, ref int splineIndex, ref int indexPart, float speed)
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
			
			if(splineIndex < 0) splineIndex = 0;
			if(splineIndex > points.Count - 2) splineIndex = points.Count - 2;
			if(indexPart < 0) indexPart = 0;
			if(indexPart > _divisor) indexPart = _divisor;

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
	
	private void MoveVisLineForDist(float dist)
	{
		float checkedDist = 0;
		Vector3 checkPos = GetPosOnSpline(_visSplineIndex, (float)_visIndexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.CENTER));
		
		while(checkedDist < dist)
		{
			Vector3 curLeftPos = GetPosOnSpline(_visSplineIndex, (float)_visIndexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.LEFT5));
			Vector3 curRightPos = GetPosOnSpline(_visSplineIndex, (float)_visIndexPart/(float)_divisor, _track.splineContainer.GetSpline(SplineLine.RIGHT5));
			Dictionary<PickupLine, List<PickupElementVec3>> pickupLines = _track.pickupContainer.GetLineDict();
			foreach(KeyValuePair<PickupLine, List<PickupElementVec3>> pickupLine in pickupLines)
			{
				int tempIndex = (int)pickupLine.Key;
				
				if(itemVisibilityIndizes[tempIndex] >= pickupLine.Value.Count)
				{
					// All items on this line done...
					continue;
				}
				
				Vector3 curPickupPos = pickupLine.Value[itemVisibilityIndizes[tempIndex]].position;
				float tempDist = Vector3.Distance(curLeftPos, curPickupPos) + Vector3.Distance(curRightPos, curPickupPos);
				
				if(nextItemDistances[tempIndex] > tempDist)
				{
					nextItemDistances[tempIndex] = tempDist;
				}
				else
				{
					// Change visibility (transparency) of the items, that are in the closer distance:
					Transform curTrans = _puManager.GetPickups().GetLine(pickupLine.Key)[itemVisibilityIndizes[tempIndex]].Pickup;
					StartCoroutine(ChangePickupVisability(curTrans, _visSwitchTime));
					
					itemVisibilityIndizes[tempIndex]++;
					nextItemDistances[tempIndex] = float.MaxValue;
				}
			}
			// This distance calculation is not perfect, but it's doing its job for the moment...
			float nextStep = (_visStepSize > dist ? dist : _visStepSize);
			Vector3 nextPos = GetNextStepOnSpline(SplineLine.CENTER, ref _visSplineIndex, ref _visIndexPart, nextStep);
			checkedDist += Vector3.Distance(nextPos, checkPos);
			checkPos = nextPos;
		}
	}

	IEnumerator ChangePickupVisability(Transform item, float changeTime)
	{
		float startAlpha = item.renderer.material.color.a;
		AnimationCurve curve = new AnimationCurve(new Keyframe(0, startAlpha), new Keyframe(changeTime, 1.0f));
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
}
