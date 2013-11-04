using UnityEngine;
using System.Collections;

// Code from: http://mobile.tutsplus.com/tutorials/game-engine/unity3d-third-person-cameras/

public class FollowCamera : MonoBehaviour 
{
    public GameObject target;
    public float damping = 1;
	
    private Vector3 offset;
	
    void Start() 
	{
        offset = target.transform.position - transform.position;
    }
	
    void LateUpdate() 
	{
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
        transform.LookAt(target.transform);
    }
}
