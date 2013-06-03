using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour 
{
	tk2dTextMesh textMesh;
    int score = 0;

    // Use this for initialization
    void Start () {
        textMesh = GetComponent<tk2dTextMesh>();
		textMesh.MakePixelPerfect();
		textMesh.text = "Score: 0";
		textMesh.Commit();
    }

    // Update is called once per frame
	
	public void UpdateScore(int i = 1)
	{
		score = score + i;
		
		if (score < 0) //avoid negative score
			score = 0;
		
		textMesh.text = "Score: " + score.ToString();

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
		
	}
	
    void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            UpdateScore(1);
        }
    }
}
