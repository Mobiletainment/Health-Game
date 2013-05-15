using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public GameObject flashWall;
	public float ruleDuration = 5.0f; //#seconds before the next rule is applied
	public float flashLength = 0.5f;
	
	public Aircraft _aircraftReference;
	
	private List<Color> flashColors = new List<Color>();
	private int activeRule = 0;
	
	private Camera flashCamera;
	
	void Start()
	{
		flashColors.Add(Color.white);
//		flashColors.Add(Color.yellow);
//		flashColors.Add(Color.green);
		flashColors.Add(Color.blue);
		
		flashCamera = GameObject.Find("Flash Camera").camera;
		InvokeRepeating("RuleFlashBegin", 0.0f, ruleDuration);
	}
	
	
	protected void RuleFlashBegin ()
	{
		//Debug.Log("FlashImage");
		flashWall.renderer.material.color = flashColors[activeRule];
		flashCamera.enabled = true;
		_aircraftReference.SetGoodTagIndex(activeRule);
		
		activeRule = (activeRule + 1) % flashColors.Count;
		Invoke("RuleFlashEnd", flashLength);
		
		// Hier eventuell eine Coroutine aufrufen, die den Flashscreen "langsame" an und aus macht...
	}
 
	protected void RuleFlashEnd ()
	{
		flashCamera.enabled = false;
	} 
	
	
}
