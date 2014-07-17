using UnityEngine;
using System.Collections;

public class ShowDescription : MonoBehaviour 
{
	public DescriptionFrame _descFrame;
	public AvatarState.State _type;
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
		_descFrame.availableLabel._type = _type;
		_descFrame.availableLabel.UpdateText();

		// Show the "Use Gift" Button in the Description or not...
		if(_textIndex == 0) // Energy Description Button
		{
			_descFrame.useGiftButton.gameObject.SetActive(true);
		}
		else
		{
			_descFrame.useGiftButton.gameObject.SetActive(false);
		}

		_descPanel.alpha = 1.0f;
		_descFrame.ShowOtherButtons(false);
	}
}
