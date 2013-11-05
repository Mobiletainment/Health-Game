using UnityEngine;
using System.Collections;

// Known Issues:

// If the speed is too fast, the avatar will leave the track.
// Possible solution: The scanObjects have to have more distance beween each other.
// Or change the rotation...


public class ScanGroundTex : MonoBehaviour {
	
	public Transform _scanPosObjLeft = null;
	public Transform _scanPosObjRight = null;
	public Transform _scanPosObjFrontLeft = null;
	public Transform _scanPosObjFrontRight = null;
	
	public int _testAmount = 10;
	public float _moveSpeed = 1.2f;
	
	// FUCKING UGLY BOOL SALAT :(
		// TODO: Refactor!
	bool _moveLeft = false;
	bool _moveRight = false;
	bool _noLine; 
	bool _lineAgain;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// ----- SWITCH LINE
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_moveLeft = true;
			_moveRight = false;
			
			_noLine = false;
			_lineAgain = false;
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			_moveRight = true;
			_moveLeft = false;
			
			_noLine = false;
			_lineAgain = false;
		}
		
		// ----- TRANSLATION
		
		Vector3 goForward = transform.forward;
		goForward *= Time.deltaTime * _moveSpeed;
		transform.position += goForward;
		
		Texture2D otherTex;
		Vector2 texStartPos = Ray2Tex(_scanPosObjLeft.position, -_scanPosObjLeft.up, out otherTex);
		
		if(otherTex != null)
		{
//			Color col = otherTex.GetPixel((int)texStartPos.x, (int)texStartPos.y);
//			Debug.Log(col);
//			Debug.Log("Left: " + texStartPos);
		}
		
		Texture2D otherTex2;
		Vector2 texEndPos = Ray2Tex(_scanPosObjRight.position, -_scanPosObjRight.up, out otherTex2);
		
		if(otherTex2 != null)
		{
//			Color col = otherTex2.GetPixel((int)texEndPos.x, (int)texEndPos.y);
//			Debug.Log(col);
//			Debug.Log("Right: " + texEndPos);
		}
		
		Vector2 checkLine = texEndPos - texStartPos;
		
		checkLine /= _testAmount;
		
		bool[] checkPositions = GetCheckPositions(_testAmount, texStartPos, checkLine, otherTex);
		
		// Check Line Switching first...
		if(_moveLeft)
		{
			MoveToNextSideLine(-transform.right, checkPositions);
		}
		else if(_moveRight)
		{
			MoveToNextSideLine(transform.right, checkPositions);
		}
		else // The is no line switch going on currently (Normal movement):
		{
			int balance = AnalyzeLine(checkPositions);
	//		Debug.Log("Balance: " + balance);
			
			if(balance != 0)
			{
				Vector3 move3d = ((_scanPosObjLeft.position - _scanPosObjRight.position) / (float)_testAmount) * (balance / 2.0f);
	//			transform.position = Vector3.MoveTowards(transform.position, transform.position - move3d, Time.deltaTime * 1.0f);
				transform.position = Vector3.Slerp(transform.position, transform.position - move3d, Time.deltaTime * 1.0f);
			}
			
			// ----- ROTATION
			
			Vector2 texFrontPosLeft = Ray2Tex(_scanPosObjFrontLeft.position, -_scanPosObjFrontLeft.up, out otherTex);
			Vector2 texFrontPosRight = Ray2Tex(_scanPosObjFrontRight.position, -_scanPosObjFrontRight.up, out otherTex);
			
			// TODO: This can be optimized by adjusting the control points in the 2 diagonal corners of a quad.
			// The first on the left front side, the second on the right back side. (you can get x and y for all corners)
			// Do not forget about rotations! Some Vector2 Calculations will do the trick ;)
			
			checkLine = texFrontPosRight - texFrontPosLeft;
			checkLine /= _testAmount;
			
			checkPositions = GetCheckPositions(_testAmount, texFrontPosLeft, checkLine, otherTex);
			balance = AnalyzeLine(checkPositions);
			
			Vector3 rotateLine = _scanPosObjFrontRight.position - _scanPosObjFrontLeft.position;
			Vector3 rotatePos = _scanPosObjFrontLeft.position + (rotateLine / 2.0f) + ((rotateLine / _testAmount) * balance);
			Vector3 rotateDir = rotatePos - transform.position;
			
			transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rotateDir, Time.deltaTime * 1.0f, 0.0f));
		}
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
	
	public void MoveToNextSideLine(Vector3 direction, bool[] checkPositions)
	{		
		bool foundOne = false;
		foreach(bool check in checkPositions)
		{
			if(check == true)
			{
				foundOne = true;
				break;
			}
		}
		if(foundOne == false)
		{
			_noLine = true;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * 10.0f);
		//transform.position = Vector3.Slerp(transform.position, transform.position - move3d, Time.deltaTime * 1.0f);
		
		if(_noLine == true && _lineAgain == false)
		{
			foreach(bool check in checkPositions)
			{
				if(check == true)
				{
					_lineAgain = true;
					
					_moveLeft = false;
					_moveRight = false;
					
					break;
				}
			}
		}
	}
}
