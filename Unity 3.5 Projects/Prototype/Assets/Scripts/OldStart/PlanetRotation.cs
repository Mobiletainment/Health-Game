using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {
	
	public Transform _startPlanet;
	public float _rotSpeed = -1200.0f;
	
	private bool _rotate = true;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_rotate == true)
		{
			transform.RotateAround(_startPlanet.position, Vector3.forward, _rotSpeed * Time.deltaTime);
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// This is just for demonstration. (Stop and start rotation)
			_rotate = !_rotate;
		}
	}
}
