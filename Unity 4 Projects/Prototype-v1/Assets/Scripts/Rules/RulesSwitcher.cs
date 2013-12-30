using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public LevelInfo LevelInfo; // TODO...

	public UILabel scoreLabel;
	public UILabel lifesLabel;
	public int Score { get; protected set; }
	public int LifesLeft { get; protected set;}

	private int level;

	private Rule _leftRule;
	private Rule _rightRule;

	private ECPNManager ecpnManager;

	public ECPNManager Backend {
		get {
			if (ecpnManager == null)
				ecpnManager = GameObject.Find ("ComponentManager").GetComponent<ECPNManager> ();
			
			return ecpnManager;
		}
	}

	public void SetLeftRule(Rule r)
	{
		_leftRule = r;
	}

	public void SetRightRule(Rule r)
	{
		_rightRule = r;
	}
	
	void Awake()
	{
		Init();
	}
	
	void Start()
	{
		//DontDestroyOnLoad(this);
	}
	
	protected void Init()
	{
		level = LevelInfo.Level;
		Score = 0;
		UpdateScore(0);	

		LifesLeft = 0;
		UpdateLife(0);
	}
	
	public bool IsItemHitGood(GameObject gameObject, ItemHit.Side side)
	{
		PickupInfo puInfo = gameObject.GetComponent<PickupInfo>();
		if(puInfo != null)
		{
			Rule rule = (side == ItemHit.Side.LEFT ? _leftRule : _rightRule);
			return rule.CheckRule(puInfo);
		}

		return false;
	}

	// TODO... (This is never ever beeing called!)
	void LevelDone()
	{
		Backend.SendPushMessage("Ihr Kind hat 1 Level geschafft! Bitte loben Sie es!");

		LoadGameOverScene();
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

	public void UpdateLife(int i = -1)
	{
		LifesLeft = LifesLeft + i;

		if(LifesLeft >= 0)
		{
			lifesLabel.text = string.Format("Lifes left: {0}", LifesLeft.ToString());
		}
	}
	
	public void Update()
	{
		//if a new level has been started, this persistent object isn't awaked a second time so we manually need to update the information
		if (level != LevelInfo.Level) 
		{
			Init();
		}
	}
}
