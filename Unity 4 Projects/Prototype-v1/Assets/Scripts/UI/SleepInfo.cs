using UnityEngine;
using System.Collections;

public class SleepInfo : MonoBehaviour 
{
	private UILabel _target;

	private void Awake()
	{
		_target = gameObject.GetComponent<UILabel>();

		if(_target == null)
		{
			Debug.LogError("Error: The SleepInfo Script has not been added to an UILabel.");
		}
		else
		{
			_target.pivot = UIWidget.Pivot.Left;
		}
	}

	// Use this for initialization
	void Start () 
	{
		EnergyManager.UpdateState();

		if(AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY) <= 0 && EnergyManager.IsSleeping == false)
		{
			// TODO: Translation?!
			_target.text = "Flins ist müde...";
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
