using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class CleanTrackData : MonoBehaviour 
{
	// Save all spline information for runtime here: (Movement Splines can be calculated with these information.)
	public SplineContainerVec3 splineContainer = new SplineContainerVec3();
	// DEPRECATED: Save all pickup information for runtime here: (Pickups will spawn at these positions.)
//	public PickupContainerVec3 pickupContainer = new PickupContainerVec3();
	// Save all SplinePlane Transforms for runtime here: (Materials need to be changed depending on skill.)
	public List<Transform> splinePlanes = new List<Transform>();
	// Save all References to Trackparts in the correct order here:
	public List<CleanTrackPartData> cleanTrackParts = new List<CleanTrackPartData>();
}
