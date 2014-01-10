using UnityEngine;
using System.Collections;

public class AnimatedMaterial : MonoBehaviour 
{
	public float _scrollSpeed = 0.5f;

	void Update()
	{
		float offset = Time.time * _scrollSpeed;
		renderer.material.mainTextureOffset = new Vector2(offset, 0);
	}
}