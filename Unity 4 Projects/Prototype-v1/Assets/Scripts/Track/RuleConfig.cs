using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RuleConfig : ScriptableObject
{
	public enum RuleShape
	{
		BOX = 0,
		CIRCLE,
		NONE
	}

	[SerializeField]
	private Color[] _pickupColors;
	[SerializeField]
	private Transform[] _pickupShapes;
	[SerializeField]
	private Transform[] _ruleShapes; // Must be configured with 3 shapes in same order as RuleShape enum -> Box, Circle, None

	public Color[] PickupColors
	{
		get { return _pickupColors; }
		private set { _pickupColors = value; }
	}

	public Color GetPickupColor(PickupInfo.Color color)
	{
		return _pickupColors[(int)color];
	}

	public Transform[] PickupShapes
	{
		get { return _pickupShapes; }
		private set { _pickupShapes = value; }
	}
	
	public Transform GetPickupShape(PickupInfo.Shape shape)
	{
		return _pickupShapes[(int)shape];
	}

	public Transform[] RuleShapes
	{
		get { return _ruleShapes; }
		private set { _ruleShapes = value; }
	}
	
	public Transform GetRuleShapeTrans(RuleShape shape)
	{
		return _ruleShapes[(int)shape];
	}
}
