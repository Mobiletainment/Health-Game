using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {
	
//	UISlider itemsCountSlider;
//	UISlider bonusCountSlider;
//	GameObject ruleSwitcher;
	
	// Use this for initialization
	void Start () {
//		itemsCountSlider = GameObject.Find("ItemsCount Slider").GetComponent<UISlider>();
//	
//		bonusCountSlider = GameObject.Find("Bonus Slider").GetComponent<UISlider>();
//		
//		ruleSwitcher = GameObject.Find("Rule Switcher");
//		
//		UILabel scoreLabel = GameObject.Find("Score Label").GetComponent<UILabel>();
//		
//		UIButton nextLevel = GameObject.Find("Button - Next Level").GetComponent<UIButton>();
//		
//		Debug.Log(nextLevel);

		/*
		if (ruleSwitcher != null)
		{
			RulesSwitcher rulesSwitcher = ruleSwitcher.GetComponent<RulesSwitcher>();
			
			scoreLabel.text = string.Format("You got: {0} items!", rulesSwitcher.Score);
			
			float itemsCount = (float)rulesSwitcher.Score / rulesSwitcher.LevelInfo.NecessaryPositiveItems;
			itemsCountSlider.value = itemsCount;

//			if (itemsCountSlider.sliderValue >= 0.5f)
//				nextLevel.enabled = true;
//			else
//				nextLevel.enabled = false;
			
			Debug.Log("ItemsCount: " + itemsCount + ", current: " + itemsCountSlider.value);
			
			if (itemsCount > 1.0f)
				bonusCountSlider.value = (float)rulesSwitcher.Score / rulesSwitcher.LevelInfo.TotalPositiveItemCount;
			else
				bonusCountSlider.value = 0.0f;
		}
		*/
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
