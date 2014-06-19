using UnityEngine;
using System.Collections;

public class EnableTutorialSetting : MonoBehaviour 
{
	public static string PrefKey = "ETS_ShowTutorial";

	private UIToggle _target;

	public void Awake()
	{
		_target = gameObject.GetComponent<UIToggle>();
		_target.startsActive = System.Convert.ToBoolean(PlayerPrefs.GetInt(PrefKey));
	}

	public void OnValueChange() 
	{
		PlayerPrefs.SetInt(PrefKey, System.Convert.ToInt32(_target.value));
		PlayerPrefs.Save();
	}
}
