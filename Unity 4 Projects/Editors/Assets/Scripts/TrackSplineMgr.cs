using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TrackSplineMgr : ScriptableObject
{
	[SerializeField]
	private SplineContainerVec3 _splineContainer = new SplineContainerVec3();

	public List<Vector3> GetSpline(SplineLine line)
	{
		return _splineContainer.GetSpline(line);
	}

//	public void Test()
//	{
//		GetSpline(0);
//
//		SplineLine curLine = SplineLine.CENTER;
//		GetSpline(curLine);
//		curLine++;
//		GetSpline(curLine);
//
//		if(curLine > SplineLine.RIGHT5)
//		{
//			Debug.Log ("Error!");
//		}
//	}
}
