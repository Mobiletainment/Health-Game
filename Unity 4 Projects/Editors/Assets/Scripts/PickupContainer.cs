using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This enum shall be used to access all pickup lines, that are lying between the splines.
// Currently, I hardcoded this to 12 lines (6 left and 6 right from the middle-spline).
// IMPORTANT: If this has to be changed, do not forget to change PickupContainer too!
public enum PickupLine
{
	LEFT6 = 0,
	LEFT5,
	LEFT4,
	LEFT3,
	LEFT2,
	LEFT1,
	RIGHT1,
	RIGHT2,
	RIGHT3,
	RIGHT4,
	RIGHT5,
	RIGHT6,
}

// PickupContainer holds a list of PickupElements and not a KeyValuePair because it is easier to extend (and work with)
// the own class than the KV-Pair.
[System.Serializable]
public class PickupElement<T>
{
	[SerializeField]
	public T position;
	// Position will do anything for T = Transform, but for T = Vector3, I additionally need a Quaternion:
	[SerializeField]
	public Quaternion rotation;
	[SerializeField]
	public bool active = false;
	// This class might be extended... e.g. what element it has to be, etc.
}

[System.Serializable]
public class PickupElementVec3 : PickupElement<Vector3>
{
}

[System.Serializable]
public class PickupElementTrans : PickupElement<Transform>
{
}

// This is a container of Pickup-Positions.
// The data can be configured in the TrackEditor.
// All TrackParts have their possible positions for items, this container also knwos, if the items are active or not.
// NOTE: I know, this container is very similar to the SplineContainer, but I couldn't find another quick'n'easy 
// solution for my needs without getting a very confusing class-system...
[System.Serializable]
public class PickupContainer<T>
{
	[SerializeField]
	protected List<T> _lineLeft6 = new List<T>();
	[SerializeField]
	protected List<T> _lineLeft5 = new List<T>();
	[SerializeField]
	protected List<T> _lineLeft4 = new List<T>();
	[SerializeField]
	protected List<T> _lineLeft3 = new List<T>();
	[SerializeField]
	protected List<T> _lineLeft2 = new List<T>();
	[SerializeField]
	protected List<T> _lineLeft1 = new List<T>();
	[SerializeField]
	protected List<T> _lineRight1 = new List<T>();
	[SerializeField]
	protected List<T> _lineRight2 = new List<T>();
	[SerializeField]
	protected List<T> _lineRight3 = new List<T>();
	[SerializeField]
	protected List<T> _lineRight4 = new List<T>();
	[SerializeField]
	protected List<T> _lineRight5 = new List<T>();
	[SerializeField]
	protected List<T> _lineRight6 = new List<T>();
	
	protected Dictionary<PickupLine, List<T>> _lines;
	
	public PickupContainer()
	{
		_lines = new Dictionary<PickupLine, List<T>>();
		
		_lines.Add(PickupLine.LEFT6, _lineLeft6);
		_lines.Add(PickupLine.LEFT5, _lineLeft5);
		_lines.Add(PickupLine.LEFT4, _lineLeft4);
		_lines.Add(PickupLine.LEFT3, _lineLeft3);
		_lines.Add(PickupLine.LEFT2, _lineLeft2);
		_lines.Add(PickupLine.LEFT1, _lineLeft1);
		_lines.Add(PickupLine.RIGHT1, _lineRight1);
		_lines.Add(PickupLine.RIGHT2, _lineRight2);
		_lines.Add(PickupLine.RIGHT3, _lineRight3);
		_lines.Add(PickupLine.RIGHT4, _lineRight4);
		_lines.Add(PickupLine.RIGHT5, _lineRight5);
		_lines.Add(PickupLine.RIGHT6, _lineRight6);
	}
	
	public List<T> GetLine(PickupLine line)
	{
		List<T> result = null;
		_lines.TryGetValue(line, out result);
		return result; 
	}

	public Dictionary<PickupLine, List<T>> GetLineDict()
	{
		return _lines;
	}
	
	// Add another PickupContainer to this one:
	public void AddPickupContainer(PickupContainer<T> addLine)
	{
		foreach(KeyValuePair<PickupLine, List<T>> lineKV in addLine.GetLineDict())
		{
			GetLine(lineKV.Key).AddRange(lineKV.Value);
		}
	}
}

[System.Serializable]
public class PickupContainerVec3 : PickupContainer<PickupElementVec3>
{
}

[System.Serializable]
public class PickupContainerTrans : PickupContainer<PickupElementTrans>
{
}