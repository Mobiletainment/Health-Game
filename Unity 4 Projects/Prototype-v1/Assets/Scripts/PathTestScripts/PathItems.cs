using UnityEngine;
using System.Collections;
public class PathItems : MonoBehaviour {
	
	// Define the width of the track (width is only one half of the track!)
	public float _trackSideWidth;
	public string _pathName = "FlightPath1";
	
	public GameObject _goodItem;
	public GameObject _badItem;
	
	public Camera _cam;
	public float _camHeight = 50.0f;
	
	public GameObject _vehiclePos;
	public Transform _flightObject;
	public float _timeInSec = 60;
	public float _camMovement=0;
	private float _middleDistance = 0.0f;
	public Transform _sphere;
	// LastPos is used for calculations of flight or path direction.
	private Vector3 _lastPos = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{	
		GameObject itemContainer = new GameObject();
		itemContainer.name = "ItemContainer";
		
		_lastPos = iTween.PointOnPath(iTweenPath.GetPath(_pathName), 0.0f);
		
		// Create Path Items:
		for(float i = 0.01f; i < 1.0f; i += 0.01f)
		{
			// TODO: I calc here more than I need... Most things are just for testing, so remove them afterwards!
			
			// Calc Normal Vectors on track to get positions for items:
			Vector3 pos = iTween.PointOnPath(iTweenPath.GetPath(_pathName), i);
			
			Vector3 curDir = pos - _lastPos;
			
			Vector2 leftDir2 = TurnLeft(new Vector2(curDir.x, curDir.z)).normalized;
			Vector2 rightDir2 = TurnRight(new Vector2(curDir.x, curDir.z)).normalized;
			
			Vector3 leftDir = new Vector3(leftDir2.x, 0, leftDir2.y);
			Vector3 rightDir = new Vector3(rightDir2.x, 0, rightDir2.y);
			
			Debug.DrawRay(pos, leftDir * 10.0f, Color.red, 100.0f);
			Debug.DrawRay(pos, rightDir * 10.0f, Color.red, 100.0f);
			
			// Put items on track:
			float rangeLeft = Random.Range(0, (int)(_trackSideWidth));
			float rangeRight = Random.Range(0, (int)(_trackSideWidth));
			
			// Put item left or right?
			float leftOrRight = Random.value;
			Vector3 side;
			float middleDistance;
			if(leftOrRight < 0.5f)
			{
				side = leftDir;	
				middleDistance = rangeLeft;
			}
			else
			{
				side = rightDir;
				middleDistance = rangeRight;
			}
			
			GameObject item;
			// For a random value < 0.3 put no item on this position.
			float goodOrEvil = Random.value;
			if(goodOrEvil >= 0.33f && goodOrEvil < 0.66f)
			{
				item = Instantiate(_goodItem, pos + (side * middleDistance), Quaternion.identity) as GameObject;
				item.tag = "Item1";
				item.transform.Rotate(new Vector3(270.0f, 180.0f, 0.0f));
				item.transform.parent = itemContainer.transform;
			}
			else if(goodOrEvil >= 0.66f)
			{
				item = Instantiate(_badItem, pos + (side * middleDistance), Quaternion.identity) as GameObject;
				item.tag = "Item2";
				item.transform.Rotate(new Vector3(270.0f, 180.0f, 0.0f));
				item.transform.parent = itemContainer.transform;
			}
			
			
			// Safe lastPos:
			_lastPos = pos;
		}
		
		// Init lastPos for Update routine:
		_lastPos = iTween.PointOnPath(iTweenPath.GetPath(_pathName), 0.0f);
		
		// Now let's start the flight:
		iTween.MoveTo(_vehiclePos, iTween.Hash("path", iTweenPath.GetPath(_pathName), "easetype", iTween.EaseType.linear, "time", _timeInSec));
	}
	
	// Update is called once per frame
	void Update() 
	{
		Vector3 pos = _vehiclePos.transform.position;
		Vector3 curDir = pos - _lastPos;
		
		Vector2 rightDir2 = TurnRight(new Vector2(curDir.x, curDir.z)).normalized;
		Vector3 rightDir = new Vector3(rightDir2.x, 0, rightDir2.y);
		
#		if UNITY_EDITOR
		if(Input.GetKey(KeyCode.A))
		{
			// To the left:
			if(_middleDistance > -_trackSideWidth)
			{
				_middleDistance -= 1.0f;
			}
		}
		else if(Input.GetKey(KeyCode.D))
		{
			// To the right:
			if(_middleDistance < _trackSideWidth)
			{
				_middleDistance += 1.0f;
			}
		}
#		endif
		//pos=_lastPos;
		_flightObject.LookAt(pos+ (curDir * 10.0f));
		
		Vector3 cam= pos;
		Vector3 sphere=pos;
		_flightObject.position = pos + rightDir * _middleDistance;

		float diff=_middleDistance-_camMovement;
		Debug.LogWarning(Mathf.Abs(_middleDistance-_camMovement));
		if (Mathf.Abs(_middleDistance-_camMovement)>_trackSideWidth/4.0f){
			_camMovement+=diff*0.03f;
		}

		cam.y+=_camHeight;
		cam+=rightDir*_camMovement;
		_sphere.position=sphere+=rightDir*_camMovement;
		_cam.transform.position=cam;// = new Vector3(_flightObject.position.x, _flightObject.position.y + _camHeight, _flightObject.position.z);
		_lastPos=pos;
	}
	
	private Vector2 TurnLeft(Vector2 vec)
	{
		return new Vector2(-vec.y, vec.x);
	}
	
	private Vector2 TurnRight(Vector2 vec)
	{
		return new Vector2(vec.y, -vec.x);
	}
}
