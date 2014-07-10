using UnityEngine;
using System.Collections;

public class ToggleQuickFix : MonoBehaviour 
{
	// This is just a Quickfix for NGUI UIToggle.
	// The Problem: If a UIToggle gets deactivated (because the parent UIPanel gets faded out (alpha = 0)), the box collider might be deactivated.
	// After fading the UIPanel back in, the box collider has NAN values as sizes and does not react to clicks anymore...

	private UIPanel _parentPanel;
	private BoxCollider _collider;
	public float _sizeX = 37f, _sizeY = 37f;
	public float _centerX = -2f, _centerY = -1f;

	void Start() 
	{
		_parentPanel = transform.parent.gameObject.GetComponent<UIPanel>();
		_collider = gameObject.GetComponent<BoxCollider>();

		if(_parentPanel == null)
		{
			Debug.LogError("Parent Panel is null!");
		}
		if(_collider == null)
		{
			Debug.LogError("BoxCollider is null!");
		}

//		UISprite sprite = gameObject.GetComponent<UISprite>();
//		if(sprite != null)
//		{
//			_sizeX = sprite.localSize.x;
//			_sizeY = sprite.localSize.y;
//			Debug.Log("X: " + _sizeX + ", Y: " + _sizeY);
//		}
//		else
//		{
//			Debug.LogError("Sprite component is null!");
//		}
	}
	
	void Update () 
	{
		if(_parentPanel.alpha > 0)
		{
//			if(float.IsNaN(_collider.size.x) || float.IsNaN(_collider.size.y) || float.IsInfinity(_collider.size.x) || float.IsInfinity(_collider.size.y))
			{
				_collider.size = new Vector3(_sizeX, _sizeY, 0.0f);
				_collider.center = new Vector3(_centerX, _centerY, 0.0f);
//				Debug.Log ("Corrected UIToggle BoxCollider.");
			}
		}
	}
}
