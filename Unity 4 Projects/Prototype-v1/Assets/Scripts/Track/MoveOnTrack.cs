using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnTrack : MonoBehaviour 
{
	// Config Members:
	public CleanTrackData _track = null;
	public float _speed = 1.0f; // Units per Second.
	public SplineLine _spline = SplineLine.CENTER;
	public SplineLine _leftMaxSpline = SplineLine.LEFT1;
	public SplineLine _rightMaxSpline = SplineLine.RIGHT1;

	public AnimationCurve _switchCurve = new AnimationCurve();

	private List<Vector3> _points = new List<Vector3>();
	private Transform _moveObject;

	private bool _switchInProgress = false;
	private List<Vector3> _switchPoints = new List<Vector3>();
	
	private int _ind = 0;
	private int _t = 0;
	
	private int _playAdd = 0;
	private bool _playForward = true;

	private float _splineLength = 0;

	// Use this for initialization
	void Start () {
		_moveObject = transform;

		// Init Controlpoints for current spline:
		_points = _track.splineContainer.GetSpline(_spline);
		
		// Initilialize Avatar position:
		_moveObject.position = GetPosOnSpline(0, 0);
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			if(_spline > _leftMaxSpline)
			{
				_spline--;
				_points = _track.splineContainer.GetSpline(_spline);
//				_switchPoints = _track.splineContainer.GetSpline(_spline - 1);
//				_switchInProgress = true;
			}
		}
		else if(Input.GetKeyDown(KeyCode.D))
		{
			if(_spline < _rightMaxSpline)
			{
				_spline++;
				_points = _track.splineContainer.GetSpline(_spline);
//				_switchPoints = _track.splineContainer.GetSpline(_spline + 1);
//				_switchInProgress = true;
			}
		}



		// Get the list of the spline-controlPoint-positions
//		_points = _track.splineContainer.GetSpline(_spline);


		// Movement...
//		Debug.DrawRay (_moveObject.position, Vector3.up, Color.red, 10.0f);
		//		Debug.Log("----- Speed: "+_speed * Time.deltaTime);
		Vector3 nextPos = _moveObject.position;
		float curDist = 0;
		int divisor = 20000;
		
		while(true)
		{
			if(_playForward)
			{
				_playAdd = 1;
			}
			else
			{
				_playAdd = -1;
			}
			
			if(_playForward)
			{
				if(_t == divisor)
				{
					_ind += _playAdd;
					_t = 0;
					
					if(_ind == _points.Count - 1)
					{
						_playForward = false;
						_t = divisor;
						_ind--;
					}
				}
			}
			else
			{
				if(_t == 0)
				{
					_ind += _playAdd;
					_t = divisor;
					
					if(_ind == -1)
					{
						_playForward = true;
						_t = 0;
					}
				}
			}
			
			_t += 20 * _playAdd;
			
			if(_ind < 0) _ind = 0;
			if(_ind > _points.Count - 2) _ind = _points.Count - 2;
			if(_t < 0) _t = 0;
			if(_t > divisor) _t = divisor;

			if(_switchInProgress)
			{
				// TODO...	
			}
			
			Vector3 pos = GetPosOnSpline(_ind, (float)_t/(float)divisor);
			curDist += Vector3.Distance(nextPos, pos);
			nextPos = pos;
			//			Debug.Log ("curDist: " + curDist);
			if(curDist >= _speed * Time.deltaTime)
			{
				//				Debug.Log ("GO!");
				//				Debug.Log ("Dist: " + Vector3.Distance(nextPos, pos));
				//				nextPos = pos;
				break;
			}
		}
		
		_moveObject.position = nextPos;
	}
	
	/**
	 * GetPosOnSpline calculates a position between 2 neighbour controlPoints.
	 * @param controlPointIndex is the index of the current control point on the spline.
	 * @param section is the relative position (0 - 1) on the spline between the current nad the next control point.
	 * @return the Position on the spline.
	 **/
	Vector3 GetPosOnSpline(int controlPointIndex, float section)
	{
		// float.Epsilon
		if(section < 0 || section > 1.0f)
		{
			Debug.LogError ("Section is out of range (0.0f - 1.0f) -> section: "+section);
		}
		
		int size = _points.Count;
		Vector3 last=_points[0];
		
		
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
		Vector3 Tp1 = ((_points[p0]- _points[p_1])
		               + (_points[pp1] - _points[p])) *firstvec* (1 - 0.65f); // TODO: Change hardcoded!
		int pp2 = (p + 2) % size;
		Vector3 Tp2 = ((_points[pp1] - _points[p0])
		               + (_points[pp2] - _points[pp1])) *secvec* (1 -0.65f); // TODO: Change hardcoded!
		
		Vector3 T1 = _points[(p) % size];
		Vector3 T2 = _points[(p + 1) % size];
		
		Vector3 P = T1 * h0 + T2 * h1 + Tp1 * h2 + Tp2 * h3;
		
//		Debug.DrawLine(last,P,Color.blue);
		last=P;
		
		return P;
	}
}
