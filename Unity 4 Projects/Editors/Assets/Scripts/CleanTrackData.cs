using UnityEngine;
using System.Collections;

public class CleanTrackData : MonoBehaviour 
{
	// Save all spline information for runtime here: (Movement Splines can be calculated with these information.)
	public SplineContainerVec3 splineContainer = new SplineContainerVec3();
	// Save all pickup information for runtime here: (Pickups will spawn at these positions.)
	public PickupContainerVec3 pickupContainer = new PickupContainerVec3();
}
