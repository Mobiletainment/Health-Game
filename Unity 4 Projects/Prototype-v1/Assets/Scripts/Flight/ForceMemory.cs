using UnityEngine;
using System.Collections;

public class ForceMemory
{
	public ForceMemory(Vector3 direction, float force)
	{
		Direction = direction;
		SampleProgress = 0.0f;
		Force = force;
	}
	
	// An absolute direction, where the force goes to
	public Vector3 Direction { get; set; }

	// The strength of the force for this direction
	public float Force { get; set; }
	
	// The point, where the last sample was taken on a curve. (Must be between 0 or 1)
	private float sampleProgress;
	
	public float SampleProgress
	{
		get { return sampleProgress; }
		set { sampleProgress = Mathf.Clamp(value, 0.0f, 1.0f); }
	}
}