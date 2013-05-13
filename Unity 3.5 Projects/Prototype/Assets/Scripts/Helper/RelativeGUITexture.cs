/*
This script will position a GUITexture on the screen using numbers that represent its position
as a fraction of the screen size rather than absolute pixel positions. For example to put
a texture in the center of the screen you would use 0/5, 0.5 as its position for halfway across
and half way down.

In addition, the size of the GUITexture is provided as a fraction so that an image that we want to be half the
size of the screen will have a size of 0.5, 0.5 This editor value is the fractional position on the screen where the GUITexture should be place
*/

using UnityEngine;
using System.Collections;

public class RelativeGUITexture : MonoBehaviour 
{
	public float relativeSizeMax;
	public GUITexture guiTextureToPosition;

	void Start () 
	{
		
		float pixelReference = (Screen.width < Screen.height) ? Screen.width : Screen.height;
				
		
		Vector2 guiSize = new Vector2();
		
		// This converts the fraction values to absolute pixel values but uses the original size if the one specified is too small
       if (pixelReference * relativeSizeMax < 44.0) //Minimum GUITexture width/height on iOS
       {
           guiSize.x = guiTexture.pixelInset.width;
           guiSize.y = guiTexture.pixelInset.height;
       }
	   else
	   {
           guiSize.x = pixelReference * relativeSizeMax; //scale image
           guiSize.y = pixelReference * relativeSizeMax;
				Debug.Log(guiTexture.pixelInset);
       }
		
	   // This places the GUITexture at the correct pixel relative position and scales it to the correct size
       guiTexture.pixelInset = new Rect(guiTextureToPosition.pixelInset.x - guiSize.x * 0.5f, guiTextureToPosition.pixelInset.y - guiSize.y * 0.5f, guiSize.x, guiSize.y);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
