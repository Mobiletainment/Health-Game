using UnityEngine;
using System.Collections;

public class CloseDescription : MonoBehaviour 
{
	public DescriptionFrame _descFrame;

	private UIPanel _descPanel;
	
	private void Start() 
	{
		_descPanel = _descFrame.GetComponent<UIPanel>();
		
		if(_descPanel == null)
		{
			Debug.LogError("The DescriptionFrame does not have an UIPanel!");
		}
	}

	private void OnClick()
	{
		_descPanel.alpha = 0.0f;

		_descFrame.ShowOtherButtons(true);
	}
}
