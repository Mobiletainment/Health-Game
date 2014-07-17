using UnityEngine;
using System.Collections;

public class DescriptionFrame : MonoBehaviour 
{
	public UILabel headlineLabel;
	public UILabel descriptionLabel;
	public AvailableNote availableLabel;
	public TutorialTextManager textReference;
	public UIImageButton useGiftButton;
	public UIImageButton[] otherButtons;

	public void ShowOtherButtons(bool active)
	{
		foreach(UIImageButton button in otherButtons)
		{
			button.gameObject.SetActive(active);
		}
	}
}
