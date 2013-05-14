using UnityEngine;
using System.Collections;

public class BackgroundOrientation : MonoBehaviour 
{
	public Transform _camPos;
	public Transform _prefab;
	public float _xMax;
	public float _yMax;
	public float _spaceX;
	public float _spaceY;
	
	// This is just a simple script to add background-cubes (or whatever prfab is) for orientation. (Demo)
	void Start () 
	{
		for(int x = (int)-_xMax / 2; x < (int)_xMax / 2; ++x)
		{
			for(int y = (int)-_yMax / 2; y < (int)_yMax / 2; ++y)
			{
				Transform box = Instantiate(_prefab, new Vector3(x * _spaceX, y * _spaceY, 0.0f), Quaternion.identity) as Transform;
				box.renderer.material.color = new Color((x > 0 ? x : -x), (y > 0 ? y : -y), 0, 1.0f);
				
				if (y % 2 == 0)
					box.tag = "Good Item";
				else
					box.tag = "Bad Item";
			}
		}
	}
	
	void LateUpdate()
	{
		// Camera follows the Aircraft:
		camera.transform.position = _camPos.position;	
	}
}
