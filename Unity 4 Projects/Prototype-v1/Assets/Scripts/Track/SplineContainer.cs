using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This enum shall be used to access all spline lines.
// Currently, I hardcoded this to 11 splines (1 in the middle, 5 left, and 5 right).
// IMPORTANT: If this has to be changed, do not forget to change SplineContainer too!
public enum SplineLine
{
	LEFT5 = 0,
	LEFT4,
	LEFT3,
	LEFT2,
	LEFT1,
	CENTER,
	RIGHT1,
	RIGHT2,
	RIGHT3,
	RIGHT4,
	RIGHT5,
}

// This is a container of Spline-ControlPointPositions.
// Actually I wanted to have an array like the folling containing all these elements.
// List<Vector3>[] _splineArray = new List<Vector3>[System.Enum.GetNames(typeof(SplineLine)).Length];
// But unity is having a problem serializing this array of Lists... (Same of List of Lists).
// I made this container generic, so that I can use it with Vector3 (runTime) and Transform (editorTime).
// Unity also has a problem serializing generics, but there is a workaround -> class SplineContainerVec3
[System.Serializable]
public class SplineContainer<T>
{
	[SerializeField]
	protected List<T> _splineLeft5 = new List<T>();
	[SerializeField]
	protected List<T> _splineLeft4 = new List<T>();
	[SerializeField]
	protected List<T> _splineLeft3 = new List<T>();
	[SerializeField]
	protected List<T> _splineLeft2 = new List<T>();
	[SerializeField]
	protected List<T> _splineLeft1 = new List<T>();
	[SerializeField]
	protected List<T> _splineCenter = new List<T>();
	[SerializeField]
	protected List<T> _splineRight1 = new List<T>();
	[SerializeField]
	protected List<T> _splineRight2 = new List<T>();
	[SerializeField]
	protected List<T> _splineRight3 = new List<T>();
	[SerializeField]
	protected List<T> _splineRight4 = new List<T>();
	[SerializeField]
	protected List<T> _splineRight5 = new List<T>();
	
	protected Dictionary<SplineLine, List<T>> _splines;
	
	public SplineContainer()
	{
		_splines = new Dictionary<SplineLine, List<T>>();
		
		_splines.Add(SplineLine.LEFT5, _splineLeft5);
		_splines.Add(SplineLine.LEFT4, _splineLeft4);
		_splines.Add(SplineLine.LEFT3, _splineLeft3);
		_splines.Add(SplineLine.LEFT2, _splineLeft2);
		_splines.Add(SplineLine.LEFT1, _splineLeft1);
		_splines.Add(SplineLine.CENTER, _splineCenter);
		_splines.Add(SplineLine.RIGHT1, _splineRight1);
		_splines.Add(SplineLine.RIGHT2, _splineRight2);
		_splines.Add(SplineLine.RIGHT3, _splineRight3);
		_splines.Add(SplineLine.RIGHT4, _splineRight4);
		_splines.Add(SplineLine.RIGHT5, _splineRight5);
	}
	
	public List<T> GetSpline(SplineLine line)
	{
		List<T> result = null;
		_splines.TryGetValue(line, out result);
		return result; 
	}

	// For drawing in the editor I do not want to use the "save" interface.
	// Note: Maybe, I will think about IEnumerator & IEnumerable Methods to do this... 
	// (To use foreach directly on this container.)
	public Dictionary<SplineLine, List<T>> GetSplineDict()
	{
		return _splines;
	}

	// Add another SplineContainer to this one:
	// Note: All spline control points from "addSpline" are added to the end of the existing list.
	public void AddSplineContainer(SplineContainer<T> addSpline)
	{
		foreach(KeyValuePair<SplineLine, List<T>> splineKV in addSpline.GetSplineDict())
		{
			GetSpline(splineKV.Key).AddRange(splineKV.Value);
		}
	}
}

// This class is a workaround to use a generic container and still be able to serialize it.
[System.Serializable]
public class SplineContainerVec3 : SplineContainer<Vector3>
{
}

[System.Serializable]
public class SplineContainerTrans : SplineContainer<Transform>
{
}