using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ShowSplineEditor : MonoBehaviour
{
	public int smoothness = 100; // Higher is better.
	private SplineContainerTrans _splines = null;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if(_splines != null)
		{
			foreach(List<Transform> ctrlPoints in _splines.GetSplineDict().Values)
			{
				if(ctrlPoints.Count > 0)
				{
					int size = ctrlPoints.Count;
					
					Vector3 last = ctrlPoints[0].position;
					for (int pos = 0; pos < size-1; pos++) 
					{
						for (int posz = 0; posz < smoothness; posz++) 
						{
							float t = ((float) posz) / smoothness;
							int p = pos;
							
							float h0 = 2 * t * t * t - 3 * t * t + 1;
							float h1 = -2 * t * t * t + 3 * t * t;
							float h2 = t * t * t - 2 * t * t + t;
							float h3 = t * t * t - t * t;
							
							int p0 = p;
							int p_1 = (size - 1 + p) % size;
							int pp1 = (p + 1) % size;
							
							float firstvec=1;
							float secvec=1;
							
							if (pos==0){
								firstvec=0;
							}
							if (pos==size-2){
								secvec=0;
							}

							// TODO: Make hardcoded values configureable (1 - 0.65f)
							// Just figure out, what it means 0 - 1 (more or less bent)...
							Vector3 Tp1 = ((ctrlPoints[p0].position- ctrlPoints[p_1].position)
							               + (ctrlPoints[pp1].position - ctrlPoints[p].position)) *firstvec* (1 - 0.65f);
							int pp2 = (p + 2) % size;
							Vector3 Tp2 = ((ctrlPoints[pp1].position - ctrlPoints[p0].position)
							               + (ctrlPoints[pp2].position - ctrlPoints[pp1].position)) *secvec* (1 - 0.65f);
							
							Vector3 T1 = ctrlPoints[(p) % size].position;
							Vector3 T2 = ctrlPoints[(p + 1) % size].position;
							
							Vector3 P = T1 * h0 + T2 * h1 + Tp1 * h2 + Tp2 * h3;
							
							Debug.DrawLine(last,P,Color.blue);
							last=P;
						}
					}
				}
			}
		}
	}

	public void SetSplineContainer(SplineContainerTrans splines)
	{
		_splines = splines;
	}
}
