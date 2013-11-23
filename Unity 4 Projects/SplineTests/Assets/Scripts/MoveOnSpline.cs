using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnSpline : MonoBehaviour {

	public List<Transform> _points = new List<Transform>();
	public Transform _moveObject;
	
	public int _ind = 0;
	public int _t = 0;
	public bool _play = false;

	private int _playAdd = 0;
	private bool _playForward = true;

	public float _speed = 1.0f; // Units per Second.
	private List<float> _ctrlPointDistances = new List<float>();
	private float _splineLength = 0;
//	private float _curPart = 0;

	// Use this for initialization
	void Start() 
	{
		for(int i = 0; i < 3; ++i)
		{
			_ctrlPointDistances.Add (CalcDistBetweenCtrlPoints(i));
		}

		foreach(float f in _ctrlPointDistances)
		{
			Debug.Log ("Dist: " + f);
			_splineLength += f;
		}
		Debug.Log ("Sum: " + _splineLength);

		// Initilialize Avatar position:
		_moveObject.position = GetPosOnSpline(0, 0);
	}
	
	// Update is called once per frame
	void Update() 
	{
		Debug.DrawRay (_moveObject.position, Vector3.up, Color.red, 10.0f);
//		Debug.Log("----- Speed: "+_speed * Time.deltaTime);
		Vector3 nextPos = _moveObject.position;
		float curDist = 0;
		int divisor = 20000;

		while(true)
		{
			// JUST A PLAY DEMO.
			if(_play)
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
			}

			if(_ind < 0) _ind = 0;
			if(_ind > _points.Count - 2) _ind = _points.Count - 2;
			if(_t < 0) _t = 0;
			if(_t > divisor) _t = divisor;

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

//		++_t;
//		_curPart += Time.deltaTime * 20.0f; // PROBLEM! Das stimmt nicht!
//		if(_t < 0) _t = 0;
//		float test = (_ctrlPointDistances[0] / _speed);
//		if(_curPart > test)
//		{
//			_t = 0;
//			_curPart = 0;
//		}
//		Vector3 pos = GetPosBetweenPoints(0, _curPart, _ctrlPointDistances[0]);
//
//		// TODO: Debug: HIER DIE GESCHW. ausrechnen und ausgeben!
//		float geschw = Vector3.Distance(_moveObject.position, pos);
//		Debug.Log ("Speed: " + geschw); // Sichtlich wird nicht immer der gleiche Abstand beim Fahren erziehlt...
//		// GetPosBetweenPoints überdenken!!
//
//		_moveObject.position = pos;
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
		Vector3 last=_points[0].position;


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
		Vector3 Tp1 = ((_points[p0].position- _points[p_1].position)
		               + (_points[pp1].position - _points[p].position)) *firstvec* (1 - 0.65f);
		int pp2 = (p + 2) % size;
		Vector3 Tp2 = ((_points[pp1].position - _points[p0].position)
		               + (_points[pp2].position - _points[pp1].position)) *secvec* (1 -0.65f);
		
		Vector3 T1 = _points[(p) % size].position;
		Vector3 T2 = _points[(p + 1) % size].position;
		
		Vector3 P = T1 * h0 + T2 * h1 + Tp1 * h2 + Tp2 * h3;
		
		Debug.DrawLine(last,P,Color.blue);
		last=P;

		return P;
	}

	private float CalcDistBetweenCtrlPoints(int indexFrom)
	{
		float dist = 0;
		Vector3 curPos = GetPosOnSpline(indexFrom, 0);

		for(int i = 1; i <= 1000; ++i)
		{
			Vector3 nextPos = GetPosOnSpline(indexFrom, i/1000.0f);

			dist += Vector3.Distance(curPos, nextPos);
			curPos = nextPos;
		}

		return dist;
	}
}
