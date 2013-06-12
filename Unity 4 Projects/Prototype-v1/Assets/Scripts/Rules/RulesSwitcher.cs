using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public LevelInfo LevelInfo;
	
	public List<GameObject> Items;
	public GameObject FlashWall;
	public float FlashLength = 0.5f;
	
	private List<Color> flashColors = new List<Color>();
	private int activeRule = 0;
	
	private Camera flashCamera;
	protected UILabel countdownLabel;
	public int TimeLeft { get; protected set;}
	public int Score { get; protected set; }
	protected UILabel scoreLabel;
	
	void Start()
	{
		DontDestroyOnLoad(this);
		countdownLabel = GameObject.Find("CountdownLabel").GetComponent<UILabel>();
		scoreLabel = GameObject.Find("ScoreLabel").GetComponent<UILabel>();
		
		TimeLeft = LevelInfo.LevelDuration;
		Score = 0;
		UpdateScore(0);	
		UpdateCountdownLabel();
		InvokeRepeating("Countdown", 1.0f, 1.0f);
		
		flashColors.Add(Color.white);
//		flashColors.Add(Color.yellow);
//		flashColors.Add(Color.green);
		flashColors.Add(Color.blue);
		
		flashCamera = GameObject.Find("Flash Camera").camera;

		InvokeRepeating("RuleFlashBegin", 0.0f, LevelInfo.RuleDuration);
		Debug.Log(FlashWall);
	}
	
	public bool IsItemHitGood(GameObject gameObject)
	{
		return Random.Range(0, 2) == 0; //TODO:
	}
	
	public GameObject GetRandomBadItem()
	{
		return Items[Random.Range(0, 2)]; //TODO: refine logic for returning a good item according to the active rule
	}
	
	public GameObject GetRandomGoodItem()
	{
		return Items[Random.Range(2, 4)]; //TOOD: refine logic for returning a good item according to the active rule
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
	
	public void UpdateScore(int i = 1)
	{
		Score = Score + i;
		
		if (Score < 0) //avoid negative score
			Score = 0;
		
		scoreLabel.text = string.Format("Score: {0}/{1}", Score.ToString(), LevelInfo.NecessaryPositiveItems);		
	}
}
