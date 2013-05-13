using UnityEngine;
using System.Collections;

public class InitialSpeed : MonoBehaviour {
	
	public Transform _limitUp;
	public Transform _limitDown;
	public AnimationCurve _speedCurve;
	public float _pointerAccelerator = 1.0f;
	
	private float _curTime = 0.0f;
	private float _limitDiff;
	private float _limitDownY;
	private bool _move = true;
	
	// Use this for initialization
	void Start () 
	{
		_limitDownY = _limitDown.position.y;
		
		_limitDiff = Vector3.Distance(_limitUp.position, _limitDown.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_move == true)
		{
			_curTime += Time.deltaTime * _pointerAccelerator;
			
			// Keep time between 0 & 1:
			while(_curTime > 1.0f)
				_curTime -= 1.0f;
			
			float hight = _speedCurve.Evaluate(_curTime);
			
			transform.position = new Vector3(transform.position.x, _limitDownY + hight * _limitDiff, transform.position.z);
		}
		
		if(Input.GetKeyDown(KeyCode.Return))
		{
			// This is just for demonstration. (Stop and start rotation)
			_move = !_move;
		}
	}
}
