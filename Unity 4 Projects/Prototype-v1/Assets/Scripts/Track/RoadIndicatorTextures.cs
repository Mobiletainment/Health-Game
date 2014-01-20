using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RoadIndicatorTextures : ScriptableObject 
{
	[SerializeField]
	private List<Texture> _textureLevel;

	// Level is the amount of white-lanes (not an index! index -> level-1)
	public Texture GetTextureLevel(int level)
	{
		if(level > 0 && level <= _textureLevel.Count)
		{
			return _textureLevel[level-1];
		}

		return null;
	}
}
