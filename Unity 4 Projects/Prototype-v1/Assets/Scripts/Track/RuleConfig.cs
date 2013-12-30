using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RuleConfig : ScriptableObject
{
	public enum ParticleShape
	{
		BOX = 0,
		CIRCLE,
		NONE // PARTCILE MUST BE CREATED! TODO!
	}

	[SerializeField]
	private Color[] _pickupColors;
	[SerializeField]
	private Transform[] _pickupShapes;
	[SerializeField]
	private ParticleSystem[] _ruleParticles;

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

	public ParticleSystem[] RuleParticles
	{
		get { return _ruleParticles; }
		private set { _ruleParticles = value; }
	}
	
	public ParticleSystem GetRuleParticle(ParticleShape shape)
	{
		return _ruleParticles[(int)shape];
	}
}
