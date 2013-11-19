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

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
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
				if(_t == 1000)
				{
					_ind += _playAdd;
					_t = 0;

					if(_ind == _points.Count - 1)
					{
						_playForward = false;
						_t = 1000;
						_ind--;
					}
				}
			}
			else
			{
				if(_t == 0)
				{
					_ind += _playAdd;
					_t = 1000;

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
		if(_t > 1000) _t = 1000;

		Vector3 pos = MoveBetweenPoints(_ind, _t);
		_moveObject.position = pos;
	}

	Vector3 MoveBetweenPoints(int indexFrom, int part)
	{
		int size = _points.Count;
		Vector3 last=_points[0].position;


		float t = ((float) part) / 1000;
		int p = indexFrom;
		
		float h0 = 2 * t * t * t - 3 * t * t + 1;
		float h1 = -2 * t * t * t + 3 * t * t;
		float h2 = t * t * t - 2 * t * t + t;
		float h3 = t * t * t - t * t;
		
		int p0 = p;
		int p_1 = (size - 1 + p) % size;
		int pp1 = (p + 1) % size;
		
		float firstvec=1;
		float secvec=1;
		
		if(indexFrom==0)
		{
			firstvec=0;
		}
		if(indexFrom==size-2)
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
}
