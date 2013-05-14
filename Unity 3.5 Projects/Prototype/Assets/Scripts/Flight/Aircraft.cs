using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Aircraft : MonoBehaviour
{	
	public float _speed = 15;
	public float _rotationMul = 100.0f;
	
	public float _accSpeed = 2.0f;
	
	private float _curDrift = 0.0f;
	private float _rotationInterpol = 0.0f;
	
	// This is actually not needed (A simple force & direction member instead would be fine too.)
	private ForceMemory _currentForce;
	
	// For HUD Control:
	private bool _hudControl = false;
	private float _hudRotation = 0.0f;
	
	private bool _changedDirection = false;
	
	// Use this for initialization
	void Start() 
	{
        rigidbody.AddForce(transform.up * _speed, ForceMode.VelocityChange);
		
		_currentForce = new ForceMemory(gameObject.transform.up, _speed);
	}
	
	//is called for every fixed framerate frame. Should be used instead of Update when dealing with Rigidbody.
	void FixedUpdate()
	{
		// Clamp current speed to maximum:
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, _speed);
		
//		// Control rotation via Keys (A & D):
//		if(Input.GetKey(KeyCode.A)) // Left
//		{
//			_changedDirection = true;
//			
//			transform.Rotate(Vector3.forward * Time.deltaTime * _rotationMul);
//		}
//		else if(Input.GetKey(KeyCode.D)) // Right
//		{
//			_changedDirection = true;
//			
//			transform.Rotate(Vector3.forward * Time.deltaTime * -_rotationMul);
//		}
		
		// Control rotation via HUD Interface:
		if(_hudControl == true)
		{
			_changedDirection = true;
			
			transform.Rotate(Vector3.forward * Time.deltaTime * -_hudRotation);
			
			_currentForce = null;
		}
		
		if(_currentForce == null)
		{
			_currentForce = new ForceMemory(transform.up, 0);
		}
		
		// Get force (strength) for current rotation / direction:
		float force = Mathf.Lerp(_currentForce.Force, _speed, _accSpeed);
		
		// Calculate drift-vector => Fake centrifugal force...
		Vector3 driftVec = transform.right;
		
		// Care about left-right combinations (no jumps between fast direction switches):
		_rotationInterpol = Mathf.Lerp(_rotationInterpol, -_hudRotation, 0.1f);
		driftVec *= _rotationInterpol * 0.005f;
		
		if(_changedDirection == false)
		{
			_curDrift = Mathf.Lerp(_curDrift, 0.0f, 0.1f);
			driftVec *= _curDrift;
		}
		else if(_changedDirection == true)
		{
			_curDrift = Mathf.Lerp(_curDrift, driftVec.magnitude, 0.1f);			
			driftVec *= _curDrift;
			
			_changedDirection = false;
		}
			
		rigidbody.AddForce((transform.up + driftVec) * force, ForceMode.VelocityChange);
		
		_currentForce.Force += force;
	}
	
	public void LateUpdate()
	{
		Vector3 cvel = rigidbody.velocity; // current
		Vector3 tvel = cvel.normalized * _speed; // target
		rigidbody.velocity = Vector3.Lerp(cvel, tvel, Time.deltaTime * 1.0f);
	}
	
	// TODO:
	// EnableHUDControl & SetHUDRotation aren't properties, so the unity editor doesent see it...
	// There is a property to make it invisible, but I'm currently to lazy to google for it :P
	public void EnableHUDControl(bool enable)
	{
		_hudControl = enable;
		
//		if(enable == false)
//			_hudRotation = 0.0f;
	}
	
	public void SetHUDRotation(float hudRotation)
	{
		// TODO: Make 200 configureable!
		_hudRotation = Mathf.Clamp(hudRotation, -200, 200);
	}
}
