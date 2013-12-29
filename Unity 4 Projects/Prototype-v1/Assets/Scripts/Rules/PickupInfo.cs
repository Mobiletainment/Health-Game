using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PickupInfo : MonoBehaviour
{
	public enum Shape
	{
		BOX = 0,
		CIRCLE
	}
	
	public enum Color
	{
		BLUE = 0,
		RED
	}
	
	public enum State
	{
		NORMAL = 0,
		INVERTED
	}

	[SerializeField]
	private Shape _shape;
	[SerializeField]
	private Color _color;
	[SerializeField]
	private State _state;
	
	public void Initialize(Shape shape, Color color, State state = State.NORMAL)
	{
		_shape = shape;
		_color = color;
		_state = state;
	}

	public Shape PickupShape
	{
		get { return _shape; }
		private set { _shape = value; }
	}

	public Color PickupColor
	{
		get { return _color; }
		private set { _color = value; }
	}

	public State PickupState
	{
		get { return _state; }
		private set { _state = value; }
	}
}
