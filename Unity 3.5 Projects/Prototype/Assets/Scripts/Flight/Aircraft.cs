using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Aircraft : MonoBehaviour
{	
	public float _speed = 1;
	// TODO: ConstantAdd & ConstantRemove sollten durch Kurven definiert sein.
	// Bei Add: Am anfang sehr kleine Steigung, und dann sehr schnell! (D.h., bei einer Wendung, wird nur wenig in
	// eine Richtung gelenkt, aber bleibt man bei einer Richtung, beschleunigt man schnell.
	// Bei Remove umgekehrt: Am Anfang nimmt die Beschleunigung recht rasch ab, aber der Rest geht dann nur langsam weg.
	// So sollte ein Drift zusammen kommen... glaube ich zumindest xD
	// Denn so, wie es aktuell ist, bekommt man speed dazu, wenn man viele kleine Drehungen macht. Die gehen alle in etwa
	// in die gleiche Richtung, und summieren sich auf ohne ende, so dass man immer schneller wird. (z.B. Beschleunigen 
	// durch: links, rechts, links, rechts, ... -> Gerade aus, aber immer +0.4 speed, der nur sehr langsam abgebaut wird.)
	// PROBLEM: Das Raumschiff wird langsamer dadurch.
	public float _constantRemove = 0.04f;
	public float _constantAdd = 0.4f; // Use this to add force frame by frame, till the sum == speed.
	public float _rotationMul = 50.0f;
	
	public AnimationCurve _constantAddCurve;
	public AnimationCurve _constantRemoveCurve;
	public float _sampleSpeed = 1.0f;
	public float _accSpeed = 1.0f;
	public float _maxDrift = 1.0f;
	
	private float _curDrift = 0.0f;
	
	private List<ForceMemory> _removeForceList;
	private ForceMemory _currentForce;
	
	// For HUD Control:
	private bool _hudControl = false;
	private float _hudRotation = 0.0f;
	
	private bool _changedDirection = false;
	
	// Use this for initialization
	void Start() 
	{
		_removeForceList = new List<ForceMemory>();
		
        rigidbody.AddForce(transform.up * _speed, ForceMode.VelocityChange);
		
		_currentForce = new ForceMemory(gameObject.transform.up, _speed);
	}
	
	//is called for every fixed framerate frame. Should be used instead of Update when dealing with Rigidbody.
	void FixedUpdate()
	{
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, _speed);
		
		// Control rotation via Keys (A & D):
		if(Input.GetKey(KeyCode.A)) // Left
		{
			_changedDirection = true;
			
			transform.Rotate(Vector3.forward * Time.deltaTime * _rotationMul);
			
//			return;
		}
		else if(Input.GetKey(KeyCode.D)) // Right
		{
			_changedDirection = true;
			
			transform.Rotate(Vector3.forward * Time.deltaTime * -_rotationMul);
			
//			return;
		}
		
		// Control rotation via HUD Interface:
		if(_hudControl == true)
		{
			_changedDirection = true;
			
			transform.Rotate(Vector3.forward * Time.deltaTime * -_hudRotation);
			
//			return;
		}
		
		if(_changedDirection == true)
		{
			_removeForceList.Add(_currentForce);
			_currentForce = null;
			
			//_changedDirection = false;
		}
		
//		if(Input.GetKeyDown(KeyCode.W))
//		{
//			rigidbody.AddForce(transform.up * _speed, ForceMode.VelocityChange);
//		}
//		if(Input.GetKeyDown(KeyCode.S))
//		{
//			rigidbody.AddForce(transform.up * -_speed, ForceMode.VelocityChange);
//		}
		
//		Debug.Log(rigidbody.velocity.magnitude);
//		Debug.Log(_hudRotation);
		
		if(_currentForce == null)
		{
			_currentForce = new ForceMemory(transform.up, 0);
		}
		
		// Add the new force step by step:
		// Only add force, if it does not make the aircraft faster than the max-speed:
//		if(rigidbody.velocity.magnitude < _speed)
//		{
			// Get the force, that shall be added from the curve:
//			_currentForce.SampleProgress += Time.deltaTime * _sampleSpeed;
//			float forceMul = _constantAddCurve.Evaluate(_currentForce.SampleProgress);
//			float force = _constantAdd * forceMul;
			
			// Add as much as possible:
//			float force = _speed - rigidbody.velocity.magnitude;
			
			// Add linear speed:
			float force = Mathf.Lerp(_currentForce.Force, _speed, _accSpeed);
		
		Vector3 driftVec = transform.right; // Vector3.zero;
		driftVec *= -_hudRotation * 0.005f;
		
		if(_changedDirection == false)
		{
			_curDrift = Mathf.Lerp(_curDrift, 0.0f, 0.1f);
			driftVec *= _curDrift;
		}
		else if(_changedDirection == true)
		{
//			driftVec = transform.right;
			
//			if(_hudRotation > 0)
//				driftVec *= -1.0f;
			
//			driftVec *= -_hudRotation * 0.005f;
			
			//Debug.Log(_curDrift + " : " + driftVec.magnitude);
			
			_curDrift = Mathf.Lerp(_curDrift, driftVec.magnitude, 0.1f);			
			
			driftVec *= _curDrift;
			
			_changedDirection = false;
		}
			
			rigidbody.AddForce((transform.up + driftVec) * force, ForceMode.VelocityChange);
			
			_currentForce.Force += force;
			
//			Debug.Log(_currentForce.Force);
//		}
		
		// Remove the old forces:
//		for(int i = 0; i < _removeForceList.Count; ++i)
//		{
//			ForceMemory forceMem = _removeForceList[i];
//			
//			// Check, if force can be removed from the list:
//			if(forceMem.Force <= 0)
//			{
//				// Make sure, that the force in the given direction is really 0:
//				if(forceMem.Force < 0)
//				{
//					rigidbody.AddForce(forceMem.Direction * -forceMem.Force, ForceMode.VelocityChange);
//				}
//				
//				_removeForceList.RemoveAt(i);
//				--i;
//				continue;
//			}
//			
//			// Get the force, that shall be removed from the curve:
//			float removeForce = _constantRemoveCurve.Evaluate(_currentForce.SampleProgress);
//			_currentForce.SampleProgress -= Time.deltaTime * _sampleSpeed;
//			
//			removeForce *= _constantRemove;
//			
//			if(forceMem.Force > 0 && forceMem.Force < removeForce)
//			{
//				removeForce = forceMem.Force;
//			}
//			
//			rigidbody.AddForce(forceMem.Direction * -removeForce, ForceMode.VelocityChange);
//			forceMem.Force -= removeForce;
//		}
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
