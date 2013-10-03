using UnityEngine;
using System.Collections;

public class TrackPartScript : MonoBehaviour
{
	// Name of this TrackPart.
	[SerializeField]
	private string _name;
	
	[SerializeField]
	private GameObject _referenceObjectStart;
	[SerializeField]
	private GameObject _referenceObjectEnd;
	
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
}