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
		_button.transform.position.Set(50, _text.height / 2.0f,0);

	}
	void OnEnable(){
		_sprite = transform.GetComponentInChildren<UISprite> ();
		_button = transform.GetComponentInChildren<UIButton> ();

	}
	// Update is called once per frame
	void Update () {
	
	}
}
