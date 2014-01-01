using UnityEngine;
using System.Collections;

// Original Source: http://wiki.unity3d.com/index.php?title=SetRenderQueue

[AddComponentMenu("Effects/SetRenderQueue")]
[RequireComponent(typeof(Renderer))]
public class SetRenderQueue : MonoBehaviour 
{
	public int queue = 3000;
	
	protected void Awake() 
	{
		if (!renderer || !renderer.sharedMaterial)
			return;

		renderer.sharedMaterial.renderQueue = queue;
	}
}

// Original Code:
//public class SetRenderQueue : MonoBehaviour {
//	public int queue = 1;
//	
//	public int[] queues;
//	
//	protected void Start() {
//		if (!renderer || !renderer.sharedMaterial || queues == null)
//			return;
//		renderer.sharedMaterial.renderQueue = queue;
//		for (int i = 0; i < queues.Length && i < renderer.sharedMaterials.Length; i++)
//			renderer.sharedMaterials[i].renderQueue = queues[i];
//	}
//	
//}