using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public LevelInfo LevelInfo;
	
	public List<GameObject> Items;
	public GameObject FlashWall;
	public float FlashLength = 0.5f;
	
	public GameObject Vehicle;
	
	private List<Color> flashColors = new List<Color>();
	private int activeRule = 0;
	
	private Camera flashCamera;
	protected UILabel countdownLabel;
	public int TimeLeft { get; protected set;}
	
	void Start()
	{
		countdownLabel = GameObject.Find("CountdownLabel").GetComponent<UILabel>();
		UpdateCountdownLabel();
		InvokeRepeating("Countdown", 1.0f, 1.0f);
		
		flashColors.Add(Color.white);
//		flashColors.Add(Color.yellow);
//		flashColors.Add(Color.green);
		flashColors.Add(Color.blue);
		
		flashCamera = GameObject.Find("Flash Camera").camera;
		TimeLeft = LevelInfo.LevelDuration;
		InvokeRepeating("RuleFlashBegin", 0.0f, LevelInfo.RuleDuration);
		Debug.Log(FlashWall);
	}
	
	public bool IsItemHitGood(GameObject gameObject)
	{
		return Random.Range(0, 2) == 0;
	}
	
	public GameObject GetRandomBadItem()
	{
		return Items[Random.Range(0, 2)]; //refine logic for returning a good item according to the active rule
	}
	
	public GameObject GetRandomGoodItem()
	{
		return Items[Random.Range(2, 4)]; //refine logic for returning a good item according to the active rule
	}
	
	protected void RuleFlashBegin ()
	{
		//Debug.Log("FlashImage");
		//FlashWall.renderer.material.color = flashColors[activeRule];
		flashCamera.enabled = true;
		//_aircraftReference.SetGoodTagIndex(activeRule);
		
		activeRule = (activeRule + 1) % flashColors.Count;
		Invoke("RuleFlashEnd", FlashLength);
		
		// Hier eventuell eine Coroutine aufrufen, die den Flashscreen "langsame" an und aus macht...
	}
 
	protected void RuleFlashEnd ()
	{
		flashCamera.enabled = false;
	} 
	
	void Countdown()
	{
		if (--TimeLeft == 0)
		{
			CancelInvoke("Countdown");
			LoadGameOverScene();
		}
		
		UpdateCountdownLabel();
	}
	
	void UpdateCountdownLabel()
	{
		countdownLabel.text = string.Format("Time left: {0}s", TimeLeft);
	}
	
	void LoadGameOverScene()
	{
		Application.LoadLevel("GameOver");
	}
}
