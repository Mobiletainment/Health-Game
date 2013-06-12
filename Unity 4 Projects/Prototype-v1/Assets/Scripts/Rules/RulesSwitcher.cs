using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public LevelInfo LevelInfo;
	
	public List<GameObject> Items;
	
	public float FlashLength = 0.4f;
	
	private List<Color> flashColors = new List<Color>();
	private int activeRule = 0;
	
	protected Camera FlashCamera;
	protected GameObject FlashWall;
	
	public UILabel countdownLabel;
	public int TimeLeft { get; protected set;}
	public int Score { get; protected set; }
	public UILabel scoreLabel;
	protected int level;
	protected Camera MainCamera;
	
	void Start()
	{
		DontDestroyOnLoad(this);
	
		Init();
	}
	
	protected void Init()
	{
		TimeLeft = LevelInfo.LevelDuration;
		level = LevelInfo.Level;
		Score = 0;
		UpdateScore(0);	
		UpdateCountdownLabel();
		InvokeRepeating("Countdown", 1.0f, 1.0f);

		flashColors.Add(new Color(160.0f/255, 82.0f/255, 45.0f/255, 255.0f/255));
		flashColors.Add(new Color(147.0f/255, 190.0f/255, 200.0f/255, 255.0f/255));
		flashColors.Add(new Color(0.0f, 0.4f, 0.0f, 1.0f)); //Green
		flashColors.Add(Color.gray);
//		flashColors.Add(Color.yellow);

		//flashColors.Add(Color.blue);
		
		
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
		Debug.Log("Flash active");
		FlashWall.renderer.material.color = flashColors[activeRule];
		FlashCamera.enabled = true;
		MainCamera.enabled = false;
		MainCamera.backgroundColor = flashColors[activeRule];
		//_aircraftReference.SetGoodTagIndex(activeRule);
		
		activeRule = (activeRule + 1) % flashColors.Count;
		Invoke("RuleFlashEnd", FlashLength);
		
		// Hier eventuell eine Coroutine aufrufen, die den Flashscreen "langsame" an und aus macht...
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
