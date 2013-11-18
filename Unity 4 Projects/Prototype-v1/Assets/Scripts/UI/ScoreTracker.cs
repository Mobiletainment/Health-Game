using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour
{
	UILabel textMesh;
	int score = 0;

	// Use this for initialization
	void Start ()
	{
		textMesh = GameObject.Find ("ItemsCount Slider").GetComponent<UILabel> ();
		textMesh.text = "Score: 0";
	}

	// Update is called once per frame
	
	public void UpdateScore (int i = 1)
	{
		score = score + i;
		
		if (score < 0) //avoid negative score
			score = 0;
		
		textMesh.text = "Score: " + score.ToString ();
	}
	
	void Update ()
	{
		if (Input.GetKey (KeyCode.Q)) {
			UpdateScore (1);
		}
	}
}
