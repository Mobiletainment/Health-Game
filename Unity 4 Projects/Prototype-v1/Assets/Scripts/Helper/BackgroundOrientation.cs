using UnityEngine;
using System.Collections;

public class BackgroundOrientation : MonoBehaviour 
{
	public Transform _camPos;
	public Transform _prefabGood;
	public Transform _prefabBad;
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
				float xRange = Random.Range(0, (int)(_spaceX * 2/5));
				xRange = (Random.value < 0.5f ? xRange : -xRange);
				float yRange = Random.Range(0, (int)(_spaceY * 2/5));
				yRange = (Random.value < 0.5f ? yRange : -yRange);
				
				Transform item;
				float xPos = x * _spaceX + xRange;
				float yPos = y * _spaceY + yRange;
				
				//if (y % 2 == 0)
				if(Random.value < 0.5f)
				{
					item = Instantiate(_prefabGood, new Vector3(xPos, yPos, 0.0f), Quaternion.identity) as Transform;
					item.tag = "Item1";
				}
				else
				{
					item = Instantiate(_prefabBad, new Vector3(x * _spaceX, y * _spaceY, 0.0f), Quaternion.identity) as Transform;
					item.tag = "Item2";
				}
				
				item.renderer.material.color = new Color((x > 0 ? x : -x), (y > 0 ? y : -y), 0, 1.0f);
			}
		}
	}
	
	void LateUpdate()
	{
		// Camera follows the Aircraft:
		camera.transform.position = _camPos.position;	
	}
}
