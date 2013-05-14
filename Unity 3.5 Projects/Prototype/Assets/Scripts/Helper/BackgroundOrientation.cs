using UnityEngine;
using System.Collections;

public class BackgroundOrientation : MonoBehaviour 
{
	public Transform _prefab;
	public float _spaceX;
	public float _spaceY;
	
	// Use this for initialization
	void Start () 
	{
		for(int x = 0; x < 50; ++x)
		{
			for(int y = 0; y < 50; ++y)
			{
				Transform box = Instantiate(_prefab, new Vector3(x * _spaceX, y * _spaceY, -10.0f), Quaternion.identity) as Transform;
				box.renderer.material.color = new Color(x, y, 0, 1.0f);
			}
		}
	}
}
