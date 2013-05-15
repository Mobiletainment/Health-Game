using UnityEngine;
using System.Collections;

public class RulesSwitcher : MonoBehaviour
{
	public float ruleDuration = 5.0f; //#seconds before the next rule is applied
	public float flashLength = 0.5f;
	public Color flashColor;
	
	private GUITexture imageObject;
	
	 //This is property syntax is js. It looks wierd, but it's a getter just like C#
	void Start()
	{
		Texture2D tex = new Texture2D (1, 1);
		tex.SetPixel(0, 0, Color.white);
		tex.Apply();
		
		GameObject gameObj = new GameObject("Image Object");
		gameObj.transform.position = new Vector3(0, 0, -45);
 		gameObj.transform.localScale = new Vector3(0, 0, 1);
 
		
		imageObject = gameObj.AddComponent<GUITexture>();
		imageObject.texture = tex;
		imageObject.color = flashColor;
		imageObject.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
		imageObject.enabled = false;
		Debug.Log(imageObject);
		InvokeRepeating("FlashImage", 5.0f, ruleDuration);
	}
	

	
	protected void FlashImage ()
	{
		//Debug.Log("FlashImage");
		imageObject.enabled = true;
		Invoke("HideImage", flashLength);
	}
 
	protected void HideImage ()
	{
		imageObject.enabled = false;
	} 
	
	
}
