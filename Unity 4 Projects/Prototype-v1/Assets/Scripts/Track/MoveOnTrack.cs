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

	private float _switchTime = 0.3f; // TODO: MAKE THIS PUBLIC (CONFIGUREABLE)

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

	// Use this for initialization
	void Start () {
		_moveObject = transform;

		// Init Controlpoints for current spline:
		_points = _track.splineContainer.GetSpline(_spline);
		
		// Initilialize Avatar position:
		_moveObject.position = GetPosOnSpline(0, 0, _points);
		_lastPos = _moveObject.position;
		_nextPos = _lastPos;

		// Init SwitchSpline:
		_switchSpline = _spline;
	}
	
	// Update is called once per frame
	void Update() 
	{
		// ---- INPUT START ----
		bool leftInput = false;
		bool rightInput = false;

// Input for Editor or Win / Linux / Mac:
#		if UNITY_EDITOR || UNITY_STANDALONE
		if(Input.GetKeyDown(KeyCode.A))
		{
			leftInput = true;
		}
		else if(Input.GetKeyDown(KeyCode.D))
		{
			rightInput = true;
		}
// Input for mobile devices:
#		elif MOBILE
		if(Input.GetMouseButtonDown(0))
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



		if(leftInput == true)
		{
			if(_switchSpline > _leftMaxSpline)
			{
//				_spline--;
//				_points = _track.splineContainer.GetSpline(_spline);
//				// _switchPoints = _track.splineContainer.GetSpline(_spline - 1);
//				// _switchInProgress = true;
//				
//				_moveObject.position = GetPosOnSpline(_splineIndex, (float)_indexPart/(float)_divisor, _points);
//				_lastPos = _moveObject.position;


				_switchSpline--;
			}
		}
		else if(rightInput == true)
		{
			if(_switchSpline < _rightMaxSpline)
			{
//				_spline++;
//				_points = _track.splineContainer.GetSpline(_spline);
//				// _switchPoints = _track.splineContainer.GetSpline(_spline + 1);
//				// _switchInProgress = true;
//				
//				_moveObject.position = GetPosOnSpline(_splineIndex, (float)_indexPart/(float)_divisor, _points);
//				_lastPos = _moveObject.position;


				_switchSpline++;
			}
		}
		// ---- INPUT END ----

//		if(_switchInProgress)
//		{
//			// TODO...	
//		}




		// Backup index & part:
		int splineIndex = _splineIndex;
		int indexPart = _indexPart;

		// Update Object Position:
		_lastPos = _nextPos;
		_lastSwitchPos = _nextSwitchPos;
		_nextPos = GetNextStepOnSpline(_spline, ref _splineIndex, ref _indexPart, _speed);
		Debug.DrawRay(_nextPos, _moveObject.up, Color.green, 10.0f);

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
//			Vector3 switchDiff = GetNextStepOnSpline(_switchSpline, ref splineIndex, ref indexPart, _speed);
//			Vector3 switchDiff = GetPosOnSpline(splineIndex, (float)indexPart / (float)_divisor, _track.splineContainer.GetSpline(_switchSpline));
//			float diff = Vector3.Distance(_moveObject.position, switchDiff);
			float diff = Vector3.Distance(_moveObject.position, _lastSwitchPos);
//			Debug.DrawRay(switchDiff, _moveObject.up, Color.red, 10.0f);

			_nextSwitchPos = GetPosOnSpline(_splineIndex, (float)_indexPart / (float)_divisor, _track.splineContainer.GetSpline(_switchSpline));
			Debug.DrawRay(_nextSwitchPos, _moveObject.up, Color.blue, 10.0f);


//			Debug.Log (diff);
			if(diff > 0.012f)
			{
//				Debug.Log ("Switch in progress...");
//				Debug.Log ("Big Diff");
				Vector3 posProp = Vector3.Slerp(_moveObject.position, _nextSwitchPos, _switchTime);

				// Finally, move the object:
				_moveObject.position = posProp;
			}
			// If I do not write explicitly "diff <= ...f", it does not work. Well done, C# -.-
			else if(diff <= 0.012f)
			{
				_spline = _switchSpline;

				_moveObject.position = _nextSwitchPos;
				Debug.Log ("Switch END");
				_nextPos = _nextSwitchPos;
				_lastPos = _nextPos;
			}
		}
		else
		{
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
			if(curDist >= speed * Time.deltaTime)
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
}
