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
	private GameObject _referenceObjectSpline;
	[SerializeField]
	private GameObject _referenceObjectPickup;

	[SerializeField]
	private SplineContainerTrans _splines = new SplineContainerTrans();
	[SerializeField]
	private PickupContainerTrans _pickups = new PickupContainerTrans();

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

	public GameObject ReferenceObjectSpline
	{
		get { return _referenceObjectSpline; }
		set { _referenceObjectSpline = value; }
	}

	public GameObject ReferenceObjectPickup
	{
		get { return _referenceObjectPickup; }
		set { _referenceObjectPickup = value; }
	}

	public SplineContainerTrans GetSplineContainer()
	{
		return _splines;
	}

	public PickupContainerTrans GetPickupContainer()
	{
		return _pickups;
	}
}
