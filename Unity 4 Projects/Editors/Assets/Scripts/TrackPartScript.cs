using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackPartScript : MonoBehaviour
{
	// Name of this TrackPart.
	[SerializeField]
	private string _name;
	
	[SerializeField]
	private GameObject _referenceObjectStart;
	[SerializeField]
	private GameObject _referenceObjectEnd;

	[SerializeField]
//	private List<Transform>[] _splines = new List<Transform>[System.Enum.GetNames(typeof(SplineLine)).Length];
	private SplineContainerTrans _splines = new SplineContainerTrans();

	// Getter & Setter:
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}
	
	public GameObject ReferenceObjectStart
	{
		get { return _referenceObjectStart; }
		set { _referenceObjectStart = value; }
	}
	
	public GameObject ReferenceObjectEnd
	{
		get { return _referenceObjectEnd; }
		set { _referenceObjectEnd = value; }
	}

	public List<Transform> GetSpline(SplineLine line)
	{
		return _splines.GetSpline(line);
	}
}
