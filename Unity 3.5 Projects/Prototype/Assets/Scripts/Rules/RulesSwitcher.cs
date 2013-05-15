using UnityEngine;
using System.Collections;

public class RulesSwitcher : MonoBehaviour
{
	public float ruleDuration = 5.0f; //#seconds before the next rule is applied
	public float flashLength = 0.5f;
	
	private Camera flashCamera;
	
	void Start()
	{
		flashCamera = GameObject.Find("Flash Camera").camera;
		InvokeRepeating("FlashImage", 0.0f, ruleDuration);
	}
	
	
	protected void FlashImage ()
	{
		//Debug.Log("FlashImage");
		flashCamera.enabled = true;
		Invoke("HideImage", flashLength);
	}
 
	protected void HideImage ()
	{
		flashCamera.enabled = false;
	} 
	
	
}
