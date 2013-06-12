using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {
	
	UISlider itemsCountSlider;
	UISlider bonusCountSlider;
	GameObject ruleSwitcher;
	
	// Use this for initialization
	void Start () {
		itemsCountSlider = GameObject.Find("ItemsCount Slider").GetComponent<UISlider>();
	
		bonusCountSlider = GameObject.Find("Bonus Slider").GetComponent<UISlider>();
		
		ruleSwitcher = GameObject.Find("Rule Switcher");
		
		UILabel scoreLabel = GameObject.Find("Score Label").GetComponent<UILabel>();
		
		UIButton nextLevel = GameObject.Find("Button - Next Level").GetComponent<UIButton>();
		
		Debug.Log(nextLevel);
		
		if (ruleSwitcher != null)
		{
			RulesSwitcher rulesSwitcher = ruleSwitcher.GetComponent<RulesSwitcher>();
			
			scoreLabel.text = string.Format("You got: {0} of {1} items!", rulesSwitcher.Score, rulesSwitcher.LevelInfo.NecessaryPositiveItems);
			
			float itemsCount = (float)rulesSwitcher.Score / rulesSwitcher.LevelInfo.NecessaryPositiveItems;
			itemsCountSlider.sliderValue = itemsCount;
			
			/*
			if (itemsCountSlider.sliderValue >= 0.5f)
				nextLevel.enabled = true;
			else
				nextLevel.enabled = false;
				*/
			
			Debug.Log("ItemsCount: " + itemsCount + ", current: " + itemsCountSlider.sliderValue);
			
			if (itemsCount > 1.0f)
				bonusCountSlider.sliderValue = (float)rulesSwitcher.Score / rulesSwitcher.LevelInfo.TotalPositiveItemCount;
			else
				bonusCountSlider.sliderValue = 0.0f;
			
			rulesSwitcher.LevelInfo.Level += 1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
