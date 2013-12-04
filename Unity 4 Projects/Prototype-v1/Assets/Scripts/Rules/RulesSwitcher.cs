using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public LevelInfo LevelInfo;
	
	public List<GameObject> Items;
	
	public float FlashLength = 0.4f;
	
	protected Camera FlashCamera;
	protected GameObject FlashWall;
	
	public UILabel countdownLabel;
	public int TimeLeft { get; protected set;}
	public int Score { get; protected set; }
	public UILabel scoreLabel;
	protected int level;
	protected Camera MainCamera;
	
	protected List<Rule> CurrentRuleSet;
	protected Rule CurrentActiveRule;
	
	void Awake()
	{
		CurrentActiveRule = LevelInfo.Rule1;
	}
	
	void Start()
	{
		DontDestroyOnLoad(this);
		Init();
	}
	
	protected void Init()
	{
		for(int i = 0; i < Items.Count; ++i)
		{
			Items[i].tag = i.ToString();
		}
		
		TimeLeft = LevelInfo.LevelDuration;
		level = LevelInfo.Level;
		Score = 0;
		UpdateScore(0);	
		UpdateCountdownLabel();
		InvokeRepeating("Countdown", 1.0f, 1.0f);
		
		//Load Stuff needed for Flash
		if (GameObject.Find("Flash Camera") != null)
			FlashCamera = GameObject.Find("Flash Camera").camera;
		else //Load from Resources
		{
			FlashCamera = (Instantiate(Resources.Load("Prefabs/Flash Camera", typeof(GameObject))) as GameObject).camera;
			FlashCamera.name = "Flash Camera";
		}
		
		FlashWall = GameObject.Find("Flash Wall");
		
		if (FlashWall == null)
		{
			FlashWall = Instantiate(Resources.Load("Prefabs/Flash Wall", typeof(GameObject))) as GameObject;
			FlashWall.name = "Flash Wall";
		}
		
		GameObject flashLight = GameObject.Find("Flash Point light");
		
		if (flashLight == null)
		{
			flashLight = Instantiate(Resources.Load("Prefabs/Flash Point light", typeof(GameObject))) as GameObject;
			flashLight.name = "Flash Point light";		
		}
		
		if (GameObject.Find("Main Camera") != null)
			MainCamera = GameObject.Find("Main Camera").camera;
		
		CurrentRuleSet = LevelInfo.CurrentRuleSet;
		InvokeRepeating("RuleFlashBegin", 0.0f, LevelInfo.RuleDuration);
	}
	
	public bool IsItemHitGood(GameObject gameObject)
	{
		if(gameObject.tag!="Untagged") {
			int itemIndex = int.Parse(gameObject.tag);
			return CurrentActiveRule.GoodItems.Contains(itemIndex);
		}
	return false;
	}
	
	public GameObject GetRandomBadItem()
	{
		int itemIndex = Random.Range(0, CurrentActiveRule.BadItems.Count - 1);
		return Items[CurrentActiveRule.BadItems[itemIndex]]; //TODO: refine logic for returning a good item according to the active rule
	}
	
	public GameObject GetRandomGoodItem()
	{
		int itemIndex = Random.Range(0, CurrentActiveRule.GoodItems.Count - 1);
		return Items[CurrentActiveRule.GoodItems[itemIndex]]; //TOOD: refine logic for returning a good item according to the active rule
	}
	
	protected void RuleFlashBegin ()
	{
		if (CurrentRuleSet.Count > 0)
		{
			NextRule();
			FlashWall.renderer.material.color = LevelInfo.SignalColors[CurrentActiveRule.Index];
			FlashCamera.enabled = true;
			MainCamera.enabled = false;
			MainCamera.backgroundColor = LevelInfo.SignalColors[CurrentActiveRule.Index];
			//_aircraftReference.SetGoodTagIndex(activeRule);
			
			Invoke("RuleFlashEnd", FlashLength);
		}
		// Hier eventuell eine Coroutine aufrufen, die den Flashscreen "langsame" an und aus macht...
	}
	
	protected void NextRule()
	{
		int randomRuleIndex = Random.Range(0, CurrentRuleSet.Count);
		CurrentActiveRule = CurrentRuleSet[randomRuleIndex];
		CurrentRuleSet.Remove(CurrentActiveRule); //don't use this same rule again
	}
 
	protected void RuleFlashEnd ()
	{
		FlashCamera.enabled = false;
		MainCamera.enabled = true;
	} 
	
	void Countdown()
	{
		if (--TimeLeft == 0)
		{
			CancelInvoke("Countdown");
			CancelInvoke("RuleFlashBegin");
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
	
	public void Update()
	{
		if (level != LevelInfo.Level) //if a new level has been started, this persistent object isn't awaked a second time so we manually need to update the information
		{
			Init();
		}
		
	}
}
