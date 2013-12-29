using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Rule
{
	// Member:
	[SerializeField]
	private bool _hasShape = false;
	[SerializeField]
	private bool _hasColor = false;
	[SerializeField]
	private PickupInfo.Shape _shape;
	[SerializeField]
	private PickupInfo.Color _color;

	// Getter:
	public PickupInfo.Shape Shape
	{
		get { return _shape; }
		private set { _hasShape = true; _shape = value; }
	}

	public PickupInfo.Color Color
	{
		get { return _color; }
		private set { _hasColor = true; _color = value; }
	}

	// Constructors & Initializer:
	private void Init(bool hasShape, PickupInfo.Shape shape, bool hasColor, PickupInfo.Color color)
	{
		if(hasShape)
			Shape = shape;
		if(hasColor)
			Color = color;
	}

	public Rule(PickupInfo.Shape shape, PickupInfo.Color color)
	{
		Init(true, shape, true, color);
	}

	public Rule(PickupInfo.Shape shape)
	{
		Init(true, shape, false, 0);
	}

	public Rule(PickupInfo.Color color)
	{
		Init(false, 0, true, color);
	}

	// Methods:
	public bool CheckRule(PickupInfo puInfo)
	{
		bool result = true;

		if(_hasShape) // Rule requires a shape
		{
			if(puInfo.PickupShape != _shape) // Rule requires other shape then the currently collected PickupItem
			{
				if(puInfo.PickupState == PickupInfo.State.NORMAL) // The state of the Item is not inverted
				{
					result = false; // Broken rule!
				}
			}
		}

		if(_hasColor) // Rule requires a color
		{
			if(puInfo.PickupColor != _color) // Another color was collected
			{
				if(puInfo.PickupState == PickupInfo.State.NORMAL) // The item state is not inverted
				{
					result = false; // Broken rule!
				}
			}
		}

		return result;
	}




	// DEPRECATED START!
	public int Index;
	public List<int> GoodItems;
	public List<int> BadItems;
	
	public Rule(int ruleIndex, int goodItemIndex1, int goodItemIndex2, int badItemIndex1, int badItemIndex2)
	{
		Index = ruleIndex;
		GoodItems = new List<int>() { goodItemIndex1, goodItemIndex2 };
		BadItems  = new List<int>() { badItemIndex1, badItemIndex2 };
	}
	// DEPRECATED END!
}
