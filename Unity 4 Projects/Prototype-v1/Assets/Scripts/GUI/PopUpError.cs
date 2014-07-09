using UnityEngine;
using System.Collections;

public class PopUpError : MonoBehaviour {
	public UILabel _text;
    public UILabel _title;
//	UISprite _sprite;
//	UIImageButton _button;
	// Use this for initialization
	void Start () {
	}
	public void setErrorMsg(string ErrorMsg) {
		_text.text = ErrorMsg;

//		_sprite.height = _text.height + 60;
//
//		Vector3 temp = _button.transform.localPosition;
//		temp.y = -_sprite.height / 2.0f+20;
//		_button.transform.localPosition = temp;
//
//        _title.transform.localPosition = new Vector3(0.0f, _text.height, 0.0f);

		//Debug.Log (_button.transform.localPosition);
	}
//	void OnEnable(){
//		_sprite = transform.GetComponentInChildren<UISprite> ();
//		_button = transform.GetComponentInChildren<UIImageButton> ();
//
//	}
	// Update is called once per frame
//	void Update () {
//	
//	}
}
