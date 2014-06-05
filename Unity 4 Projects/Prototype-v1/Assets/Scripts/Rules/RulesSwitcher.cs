using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RulesSwitcher : MonoBehaviour
{
	public UILabel scoreLabel;
	public UILabel lifesLabel; // Note: Now abused as EnergyLabel...
	public int LifesLeft { get; protected set;}

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
		LifesLeft = 0;
		UpdateLife(0);

		WriteOutEnergyLevel();
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
//	void LevelDone()
//	{
//        LoadGameOverScene();
//	}
//
//	void LoadGameOverScene()
//	{
//		Application.LoadLevel("GameOver");
//	}

	public void UpdateLife(int i = -1)
	{
		LifesLeft = LifesLeft + i;

//		if(LifesLeft >= 0)
//		{
//			lifesLabel.text = string.Format("Verbleibende Leben: {0}", LifesLeft.ToString());
//		}
	}

	private void WriteOutEnergyLevel()
	{
		AvatarState.DecreaseStateValue(AvatarState.State.CURRENT_ENERGY); // THIS IS JUST FOR DEMO!
		AvatarState.Save();
		lifesLabel.text = string.Format("Bestehende Energie: {0}", AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY));
	}
}
