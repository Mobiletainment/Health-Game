using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CleanTrackPartData : MonoBehaviour 
{
	// Does this TrackPart contain a Rule:
	public bool isRule = false;
	// Or is it a finish line: (only one can be true - finish line or rule)
	public bool isFinishLine = false;
	// If it is a rule or finishLine, a position & rotation should be set:
	public Vector3 extraPosition;
	public Quaternion extraRotation;

	// Save all pickup information for runtime here: (Pickups will spawn at these positions.)
	public PickupContainerVec3 pickupContainer = new PickupContainerVec3();
}
