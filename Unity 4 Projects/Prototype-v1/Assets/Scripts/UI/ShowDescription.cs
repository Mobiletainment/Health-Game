using UnityEngine;
using System.Collections;

public class ShowDescription : MonoBehaviour 
{
	public DescriptionFrame _descFrame;
	public string _headline;
	public int _textIndex;

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
		_descFrame.headlineLabel.text = _headline;
		_descFrame.descriptionLabel.text = _descFrame.textReference.TutTexts[_textIndex];
		_descPanel.alpha = 1.0f;
		_descFrame.ShowOtherButtons(false);
	}
}
