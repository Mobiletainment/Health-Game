#if UNITY_IPHONE || UNITY_ANDROID
#	define MOBILE
#endif
using UnityEngine;
using System.Collections.Generic;
public class PathItems : MonoBehaviour {
	
	// Define the width of the track (width is only one half of the track!)
	public float _trackSideWidth;
	public string _pathName = "FlightPath1";
	
	public Camera _cam;
	public float _camHeight = 50.0f;
	
	public GameObject _vehiclePos;
	public Transform _flightObject;
	
	public float _camMovement=0;
	private float _middleDistance = 0.0f;
	private Vector3 _quadpos;
	public Transform _marker;
	
	public float _directionMultiplier = 1.0f;
	
	[HideInInspector]
	public  RulesSwitcher _rulesSwitcher;
	
	private int _markIndex;
	//public List<Vector3> items = new List<Vector3>();
	//public Transform _sphere;
	// LastPos is used for calculations of flight or path direction.
	private Vector3 _lastPos = Vector3.zero;
	
	void Awake()
	{
		//Reuse RulesSwitcher between Levels for information transfer
		GameObject rulesSwitcherGameObject = GameObject.Find("Rule Switcher");
		
		if (rulesSwitcherGameObject == null)
		{
			rulesSwitcherGameObject = Instantiate(Resources.Load("Prefabs/Rule Switcher", typeof(GameObject))) as GameObject;
			rulesSwitcherGameObject.name = "Rule Switcher";
			
		}
		
		_rulesSwitcher = rulesSwitcherGameObject.GetComponent<RulesSwitcher>();
	}
	
	// Use this for initialization
	void Start () 
	{	
		_rulesSwitcher.countdownLabel = GameObject.Find("CountdownLabel").GetComponent<UILabel>();
		_rulesSwitcher.scoreLabel = GameObject.Find("ScoreLabel").GetComponent<UILabel>();
		_flightObject.gameObject.GetComponent<ItemHit>().RuleSwitcher = _rulesSwitcher;
		
		
		
		
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
				item = Instantiate(_rulesSwitcher.GetRandomGoodItem(), pos + (side * middleDistance), Quaternion.identity) as GameObject;
				item.transform.localScale *= 1.5f;
				item.transform.parent = itemContainer.transform;
				//items.Add(item.transform.position);
			}
			else if(goodOrEvil >= 0.66f)
			{
				item = Instantiate(_rulesSwitcher.GetRandomBadItem(), pos + (side * middleDistance), Quaternion.identity) as GameObject;
				item.transform.localScale *= 1.5f;
				item.transform.parent = itemContainer.transform;
			}
			
			
			// Safe lastPos:
			_lastPos = pos;
		}
		
		// Init lastPos for Update routine:
		_lastPos = iTween.PointOnPath(iTweenPath.GetPath(_pathName), 0.0f);
		
		// Now let's start the flight:
		iTween.MoveTo(_vehiclePos, iTween.Hash("path", iTweenPath.GetPath(_pathName), "easetype", iTween.EaseType.linear, "time", _rulesSwitcher.LevelInfo.LevelDuration));
	}
	
	// Update is called once per frame
	void Update() 
	{
		Vector3 pos = _vehiclePos.transform.position;
		Vector3 curDir = pos - _lastPos;
		

		Vector2 rightDir2 = TurnRight(new Vector2(curDir.x, curDir.z)).normalized;
		Vector3 rightDir = new Vector3(rightDir2.x, 0, rightDir2.y);
		
		Debug.DrawRay(pos, curDir.normalized * 10.0f, Color.blue, 100.0f);
		
		float deltaDistance = 0.0f;
		
#		if UNITY_EDITOR
		
		if(Input.GetKey(KeyCode.A))
		{
			// To the left:
			if(_middleDistance > -_trackSideWidth)
			{
				deltaDistance = -1.0f;
			}
		}
		else if(Input.GetKey(KeyCode.D))
		{
			// To the right:
			if(_middleDistance < _trackSideWidth)
			{
				deltaDistance = 1.0f;
			}
		} 
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			//Debug.Log ("Space");
//			Vector3 hullPoint = pos + curDir.normalized * 10;
//			Debug.DrawRay(pos, curDir.normalized * 10, Color.yellow, 100f);
			
			Collider[] hits = Physics.OverlapSphere(pos, _trackSideWidth); //.SphereCastAll(pos, 100.0f, curDir.normalized, 0);
			
			foreach(Collider hit in hits)
			{
				_marker.position=new Vector3(hit.transform.position.x,hit.transform.position.y,hit.transform.position.z);
				Debug.Log("Hit object at dist " + (pos - hit.transform.position).magnitude, hit.transform);
				break;
			}
		}
#		elif MOBILE
		Debug.LogWarning(Input.touchCount);
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(Input.touchCount - 1);
			float touchPos = touch.position.x;
				
			deltaDistance = touchPos < Screen.width * 0.5f ? -1.0f : 1.0f;
		}
#		endif
		
		_middleDistance += deltaDistance * _directionMultiplier;
		
		//pos=_lastPos;
		Debug.DrawRay(pos, (curDir * 100.0f), Color.yellow, 100.0f);
		
		_flightObject.LookAt((pos + rightDir * _middleDistance) + (curDir * 100.0f));
		
		Vector3 cam= pos;

		_quadpos=_flightObject.position = pos + rightDir * _middleDistance;

		float diff=_middleDistance-_camMovement;
		//Debug.LogWarning(Mathf.Abs(_middleDistance-_camMovement));
		if (Mathf.Abs(_middleDistance-_camMovement)>_trackSideWidth/4.0f){
			_camMovement+=diff*0.03f;
		}
//	    Texture2D texture = new Texture2D(1, 1);
//	    texture.SetPixel(0,0,new Color(1,0,0));
//	    texture.Apply();
//	    GUI.skin.box.normal.background = texture;
//	    GUI.Box(new Rect(pos.x,pos.y,10,10), GUIContent.none);
		cam.y+=_camHeight;
		cam+=rightDir*_camMovement;
		//_sphere.position=sphere+=rightDir*_camMovement;
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
