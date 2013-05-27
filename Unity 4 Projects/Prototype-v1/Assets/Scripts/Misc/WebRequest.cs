using UnityEngine;
using System.Collections;

public class WebRequest : MonoBehaviour {
	
	private string urlString = "https://api.twitter.com/1/statuses/user_timeline.json?include_entities=true&include_rts=true&screen_name=twitterapi&count=1";
	
	// Use this for initialization
	void Start () {
		StartCoroutine(MyWebRequest());
	}
	
	private IEnumerator MyWebRequest()
	{
		Debug.Log("I started the request - " + Time.time);
		WWW www = new WWW(urlString);
		yield return www;
		
		Debug.Log("I am done - " + Time.time);
		
//		while(Time.time < 5.0f) // Wait 5 seconds before changing the text...
//			yield return null;
		
		guiText.text = www.text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
