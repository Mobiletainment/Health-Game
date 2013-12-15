using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RoadIndicatorTextures : ScriptableObject 
{
	[SerializeField]
	private List<Texture> _textureLevel;

	public Texture GetTextureLevel(int level)
	{
		if(level >= 0 && level < _textureLevel.Count)
		{
			return _textureLevel[level];
		}

		return null;
	}
}
