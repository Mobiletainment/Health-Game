using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackPartScript : MonoBehaviour
{
	// Name of this TrackPart.
	[SerializeField]
	private string _name;
	
	[SerializeField]
	private GameObject _startReferenceObject;
	[SerializeField]
	private GameObject _endReferenceObject;
	[SerializeField]
	private GameObject _splineReferenceObject;
	[SerializeField]
	private GameObject _pickupReferenceObject;
	[SerializeField]
	private GameObject _environmentReferenceObject;
	[SerializeField]
	private GameObject _bordersReferenceObject;

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
		get { return _startReferenceObject; }
		set { _startReferenceObject = value; }
	}
	
	public GameObject ReferenceObjectEnd
	{
		get { return _endReferenceObject; }
		set { _endReferenceObject = value; }
	}

	public GameObject ReferenceObjectSpline
	{
		get { return _splineReferenceObject; }
		set { _splineReferenceObject = value; }
	}

	public GameObject ReferenceObjectPickup
	{
		get { return _pickupReferenceObject; }
		set { _pickupReferenceObject = value; }
	}

	public GameObject ReferenceObjectEnvironment
	{
		get { return _environmentReferenceObject; }
		set { _environmentReferenceObject = value; }
	}

	public GameObject ReferenceObjectBorders
	{
		get { return _bordersReferenceObject; }
		set { _bordersReferenceObject = value; }
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
