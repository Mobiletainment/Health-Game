using UnityEngine;
using System.Collections;

[System.Serializable]
public class TutorialTextManager : ScriptableObject 
{
	[SerializeField]
	private string[] _tutTexts;

	public string[] TutTexts
	{
		get { return _tutTexts; }
		set { _tutTexts = value; }
	}

	// For the editor:
	[SerializeField]
	private int[] _areaHeight;

	public int[] AreaHeight
	{
		get { return _areaHeight; }
		set { _areaHeight = value; }
	}
}
