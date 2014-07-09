using UnityEngine;
using System.Collections;

public class KeepButtonPressed : MonoBehaviour 
{
	private UIImageButton _target = null;
	private bool _wasPressed = false;

	private void Awake()
	{
		_target = gameObject.GetComponent<UIImageButton>();

		if(_target == null)
		{
			Debug.LogError("Error: KeepButtonPressed was not added to an UIImageButton Object!");
		}
	}

	private void OnClick()
	{
		_wasPressed = true;
	}
		
	private void Update()
	{
		if(_wasPressed)
			_target.SendMessage("OnHover", true);
	}
}
