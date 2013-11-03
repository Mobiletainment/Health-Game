using UnityEngine;
using System.Collections;

public class RayTexTest : MonoBehaviour 
{
    void Update() 
	{

    }
	
	// Call this in Update Method to check Color in Texture via MouseClick.
	void MouseClickDemo()
	{
		if (!Input.GetMouseButton(0))
			return;
		
		RaycastHit hit;
		if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
			return;
		
		Renderer renderer = hit.collider.renderer;
		MeshCollider meshCollider = hit.collider as MeshCollider;
		
		if (renderer == null || renderer.sharedMaterial == null 
			|| renderer.sharedMaterial.mainTexture == null || meshCollider == null)
			return;
		
		Texture2D tex = renderer.material.mainTexture as Texture2D;
		Vector2 pixelUV = hit.textureCoord;
		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;
//		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
//		tex.Apply();
		Color col = tex.GetPixel((int)pixelUV.x, (int)pixelUV.y);
		Debug.Log(col);
	}
}
