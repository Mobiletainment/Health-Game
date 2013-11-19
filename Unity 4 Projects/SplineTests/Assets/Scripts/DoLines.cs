using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DoLines : MonoBehaviour {
	
	public List<Transform> points=new List<Transform>();
	
	
	
//	void iterateChildren(Transform trans){
//		foreach(Transform child in trans)
//		{
//			points.Add(child);
//			iterateChildren(child);
//		}
//	}
	// Use this for initialization
	void Start () {
		
//		iterateChildren(transform);
	

			
	/*	foreach (var bla in points){
			Debug.Log("Coordes: "+bla.position.x+", "+bla.position.z+" name: "+bla.name , bla);
			
		}*/
	}
	
	// Update is called once per frame
	void Update () {
//		points.Clear();
			
//		iterateChildren(transform);
	

			
		 int size = 0;
		foreach(var i in points) {
			if (i==null) continue;
			size++;
		}
	   Vector3 last=points[0].position;
	    for (int pos = 0; pos < size-1; pos++) {
			if(points[pos]==null)
				continue;
					
			
           
			

            for (int posz = 0; posz < 1000; posz++) {
                float t = ((float) posz) / 1000;       //size*10;
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
                Vector3 Tp1 = ((points[p0].position- points[p_1].position)
                        + (points[pp1].position - points[p].position)) *firstvec* (1 - 0.65f);
                int pp2 = (p + 2) % size;
                Vector3 Tp2 = ((points[pp1].position - points[p0].position)
                        + (points[pp2].position - points[pp1].position)) *secvec* (1 -0.65f);

                Vector3 T1 = points[(p) % size].position;
                Vector3 T2 = points[(p + 1) % size].position;

                Vector3 P = T1 * h0 + T2 * h1 + Tp1 * h2 + Tp2 * h3;
				
				Debug.DrawLine(last,P,Color.blue);
				last=P;
            }
        }
/*		for (int i=1;i<points.Count;i++){
			Debug.DrawLine(last.position,points[i].position,Color.blue);
			last=points[i];
		}*/
	
	}
}
