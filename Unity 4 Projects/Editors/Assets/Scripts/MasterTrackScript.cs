using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class MasterTrackScript : MonoBehaviour 
{
	// TODO: Make nameCounter private and use a Getter that automatically increases the counter and a Reset Function.
	// Do not forget to change it everywhere, where it's used (currently TrackEditor & InsertArrowEditor)
	
	public enum Mode
	{
		NORMAL,
		ERASE,
		INSERT,
		PICKUP,
		SAVE
	};
	
	// Configuration of all TrackParts:
	public TrackPartMgr trackPartManager = null;
	// Configuration of all saved TrackParts:
	public SaveTracks saveTracks = null;
	// Configuration of the arrow-asset:
	public Transform arrowAsset = null;
	// Index of the currently selected TrackPart:
	public int partSelectionInd = 0;
	// Shall the GUI Inspector show the Configuration details (foldout):
	public bool showConfig = false;
	// A list of all TrackParts, that have been set so far:
	public List<TrackPartScript> currentTrackParts = new List<TrackPartScript>();
	// A counter to give the parts unique names:
	public int nameCounter = 0;
	// The current mode of the editor:
	public Mode editorMode = Mode.NORMAL;
	// An empty GameObject that contains all arrows, that are pointing on each TrackPart (e.g. to erase or insert):
	public GameObject changeArrowContainer = null;
	// A flag to delete a track in eraseMode just by selecting the arrow:
	public bool deleteWithoutConfirmation = false;
	// A flag to instant insert a track in insertionMonde just by selecting the arrow:
	public bool instantInsertion = false;
	// Shall the GUI Inspector show the Save-Options (foldout in SaveMode):
	public bool showSaveOptions = true;
	// Shall the GUI Inspector show the Load-Options (foldout in SaveMode):
	public bool showLoadOptions = true;
	// Shall the GUI Inspector show the Delete-Options (foldout in SaveMode):
	public bool showDeleteOptions = false;
	// The name of the Track (Saving option):
	public string trackName = null;
	// The index of the choice of loading a saved track:
	public int loadTrackIndex = 0;
	// The index of the chouce of deleting a saved track:
	public int deleteTrackIndex = 0;
	// Show the splines in the editor:
	public bool showSplines = false;
	// The runTime object to draw the splines:
	public GameObject splineObject = null;
	// A list of environment objects, that will be placed on the track when exporting to prefab:
	// TODO: This will be a list later on...
	public GameObject environmentObject = null;
	// For randomized pickup-activity, the left side line:
	public PickupLine leftLine = PickupLine.LEFT6;
	// For randomized pickup-activity, the right side line:
	public PickupLine rightLine = PickupLine.RIGHT6;
	// For randomized pickup-activity, the active-percentage:
	public float activePercentage = 0.5f;
}
