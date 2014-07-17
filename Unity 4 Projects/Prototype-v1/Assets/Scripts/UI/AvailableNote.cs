using UnityEngine;
using System.Collections;

public class AvailableNote : MonoBehaviour 
{
	public AvatarState.State _type;

	private UILabel _target;

	private void Awake()
	{
		_target = gameObject.GetComponent<UILabel>();

		if(_target == null)
		{
			Debug.LogError("Error: AvailableNote has to be attached to an UILabel!");
		}
	}
	
	private void Start() 
	{
		UpdateText();
	}

	public void UpdateText()
	{
		// TODO: Translation?!
		if(_type == AvatarState.State.CURRENT_ENERGY)
		{
			EnergyManager.UpdateState();
			_target.text = "Verfügbare Energie: " + AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY);
		}
		else
		{
			_target.text = "Verfügbar: " + AvatarState.GetStateValue(_type);
		}
	}
}
