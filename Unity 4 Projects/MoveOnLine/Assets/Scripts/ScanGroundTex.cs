using UnityEngine;
using System.Collections;

public class ScanGroundTex : MonoBehaviour {
	
	public Transform _scanPosObjLeft = null;
	public Transform _scanPosObjRight = null;
	public Transform _scanPosObjFrontLeft = null;
	public Transform _scanPosObjFrontRight = null;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// ----- TRANSLATION
		
		Vector3 goForward = transform.forward;
		goForward /= 100.0f;
		transform.position += goForward;
		
		Texture2D otherTex;
		Vector2 texStartPos = Ray2Tex(_scanPosObjLeft.position, -_scanPosObjLeft.up, out otherTex);
		
		if(otherTex != null)
		{
			Color col = otherTex.GetPixel((int)texStartPos.x, (int)texStartPos.y);
			Debug.Log(col);
			Debug.Log("Left: " + texStartPos);
		}
		
		Texture2D otherTex2;
		Vector2 texEndPos = Ray2Tex(_scanPosObjRight.position, -_scanPosObjRight.up, out otherTex2);
		
		if(otherTex2 != null)
		{
			Color col = otherTex2.GetPixel((int)texEndPos.x, (int)texEndPos.y);
			Debug.Log(col);
			Debug.Log("Right: " + texEndPos);
		}
		
		Vector2 checkLine = texEndPos - texStartPos;
		
		int testAmount = 10; // TODO: config (public attribute)
		
		checkLine /= testAmount;
		
		bool[] checkPositions = GetCheckPositions(testAmount, texStartPos, checkLine, otherTex);
		int balance = AnalyzeLine(checkPositions);
		
		Debug.Log("Balance: " + balance);
		
		if(balance != 0)
		{
			Vector3 move3d = ((_scanPosObjLeft.position - _scanPosObjRight.position) / (float)testAmount) * (balance / 2.0f);
//			Debug.DrawRay(transform.position, move3d, Color.magenta, 10.0f);
			
//			Vector3 vecDiff = transform.position - move3d;
			
//			Debug.Log(vecDiff);
//			Debug.Log(Vector3.Magnitude(_scanPosObjLeft.position - _scanPosObjRight.position));
//			Debug.Log(Vector3.Magnitude(move3d));
			
//			transform.position += -move3d;
			transform.position = Vector3.MoveTowards(transform.position, transform.position - move3d, Time.deltaTime * 1.0f);
		}
		
		// ----- ROTATION
		
		Texture2D otherTex3;
		Vector2 texFrontPosLeft = Ray2Tex(_scanPosObjFrontLeft.position, -_scanPosObjFrontLeft.up, out otherTex3);
		
		if(otherTex3 != null)
		{
			Debug.Log("Front Left: " + texFrontPosLeft);
		}
		
		Texture2D otherTex4;
		Vector2 texFrontPosRight = Ray2Tex(_scanPosObjFrontRight.position, -_scanPosObjFrontRight.up, out otherTex4);
		
		if(otherTex4 != null)
		{
			Debug.Log("Front Right: " + texFrontPosRight);
		}
		
		// TODO: This can be optimized by adjusting the control points in the 2 diagonal corners of a quad.
		// The first on the left front side, the second on the right back side. (you can get x and y for all corners)
		// Do not forget about rotations! Some Vector2 Calculations will do the trick ;)
		
		checkLine = texFrontPosRight - texFrontPosLeft;
		checkLine /= testAmount;
		
		checkPositions = GetCheckPositions(testAmount, texFrontPosLeft, checkLine, otherTex);
		balance = AnalyzeLine(checkPositions);
		
		Debug.Log("Balance #2: " + balance);
		
		Vector3 rotateLine = _scanPosObjFrontRight.position - _scanPosObjFrontLeft.position;
		Vector3 rotatePos = _scanPosObjFrontLeft.position + (rotateLine / 2.0f) + ((rotateLine / testAmount) * balance);
		Vector3 rotateDir = rotatePos - transform.position;
		
		transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rotateDir, Time.deltaTime * 1.0f, 0.0f));
		
	}
	
	Vector2 Ray2Tex(Vector3 position, Vector3 direction, out Texture2D otherTex)
	{
		otherTex = null;
		RaycastHit hit;
		
		Ray ray = new Ray(position, direction);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 10.0f);
		
		if(Physics.Raycast(ray, out hit))
		{
			Renderer otherRenderer = hit.collider.renderer;
			MeshCollider otherMeshCollider = hit.collider as MeshCollider;
			
			if(otherRenderer != null && otherRenderer.sharedMaterial != null 
				&& otherRenderer.sharedMaterial.mainTexture != null && otherMeshCollider != null)
			{
				otherTex = otherRenderer.material.mainTexture as Texture2D;
				Vector2 pixelUV = hit.textureCoord;
				pixelUV.x *= otherTex.width;
				pixelUV.y *= otherTex.height;
//				Color col = otherTex.GetPixel((int)pixelUV.x, (int)pixelUV.y);
//				Debug.Log(col);
				return pixelUV;
				
				// TODO: Next Steps:
				// Ray nach unten und Quer-Linie (Quer zu Lauf-Richtung).
				// Links und rechts runter (Abstand austesten), die Koordinaten auslesen.
				// Das ganze nochmal etwas weiter vorne (auch hier Abstand austesten).
				// Dann checken, ob man noch auf der Linie ist und wo die Linie vorne ist.
				// Überlegen, wie man mit Hilfe dieser Daten auf der Spur bleiben kann...
			}
		}
		
		Debug.LogWarning("Warning: No texture was found!");
		return Vector2.zero;
	}
	
	public bool[] GetCheckPositions(int testAmount, Vector2 texStartPos, Vector2 checkLine, Texture2D otherTex)
	{
		bool[] checkPositions = new bool[testAmount + 1];
		
		for(int i = 0; i <= testAmount; ++i)
		{
			Vector2 curPos = texStartPos + checkLine * i;
			Color col = otherTex.GetPixel((int)curPos.x, (int)curPos.y);
//			Debug.Log(col);
			
			if(col == Color.white)
			{
				checkPositions[i] = false;
			}
			else
			{
				checkPositions[i] = true;
			}
		}
		
		return checkPositions;
	}
	
	public int AnalyzeLine(bool[] checkLine)
	{
		int leftFalse = 0;
		for(int i = 0; i < checkLine.Length; ++i)
		{
			if(checkLine[i] == false)
			{
				++leftFalse;
			}
			else
			{
				break;
			}
		}
		
		int rightFalse = 0;
		for(int i = checkLine.Length - 1; i >= 0; --i)
		{
			if(checkLine[i] == false)
			{
				++rightFalse;
			}
			else
			{
				break;
			}
		}
		
		int diff = leftFalse - rightFalse;
		
		// TODO: Think about that...
		// Is it enoght to transform the avatar to the right position?
		// Or do I have to set an angle for rotation?
		// Or both? (e.g. translate for back-line, rotate for front line...)
//		if(diff == 0)
//		{
//			return; // ...perfeclty balanced.
//		}
//		else if(diff < 0)
//		{
//			return; // ...rightSide is bigger, line is on the left, character has to go left to get balanced.
//		}
//		else
//		{
//			return; // ...leftSide is bigger, character has to go right to get balanced
//		}
		
		return diff; // < 0 -> left; > 0 -> right; == 0 -> Perfectly balanced
		
	}
}
