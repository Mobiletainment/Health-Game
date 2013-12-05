using UnityEngine;
using System.Collections;

public class PopUpError : MonoBehaviour {
	public UILabel _text;
	UISprite _sprite;
	UIButton _button;
	// Use this for initialization
	void Start () {
	}
	public void setErrorMsg(string ErrorMsg) {
		_text.text = ErrorMsg;
		_sprite.height = _text.height + 60;

		Vector3 temp = _button.transform.localPosition;
		temp.y = -_sprite.height / 2.0f+20;
		_button.transform.localPosition = temp;
		Debug.Log (_button.transform.localPosition);

	}
	void OnEnable(){
		_sprite = transform.GetComponentInChildren<UISprite> ();
		_button = transform.GetComponentInChildren<UIButton> ();

	}
	// Update is called once per frame
	void Update () {
	
	}
}
