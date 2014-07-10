using UnityEngine;
using System.Collections;

public class ActivateSlowMotion : MonoBehaviour 
{
	public MoveOnTrack _moveOnTrack;
	public float _duration = 15.0f;

	private bool _active = false;
	private float _timeLeft;
	private UIImageButton _imageButton;
	private UISprite _sprite;

	private int _giftAmount = 0;

	private void Start()
	{
		_giftAmount = AvatarState.GetStateValue(AvatarState.State.GIFT_SLOW_MOTION);

		// Disable this button, if no gifts are available
		if(_giftAmount <= 0)
		{
//			gameObject.SetActive(false);
			gameObject.GetComponent<UIImageButton>().isEnabled = false;
		}

		_imageButton = gameObject.GetComponent<UIImageButton>();
		_sprite = transform.GetComponentInChildren(typeof(UISprite)) as UISprite;
	}

	private void OnClick()
	{
		StartSlowMotion();

		// The gift "SlowMotion" has been used:
		AvatarState.DecreaseStateValue(AvatarState.State.GIFT_SLOW_MOTION);
		_giftAmount--;
	}

	private void Update()
	{
		if(_active == true)
		{
			_sprite.fillAmount = _timeLeft / _duration;

			if(_timeLeft <= 0.0f)
			{
				EndSlowMotion();
			}

			_timeLeft -= Time.deltaTime;
		}
	}

	private void StartSlowMotion()
	{
		_timeLeft = _duration;
		_active = true;

		_moveOnTrack.ActivateSlowMotion();

		_imageButton.isEnabled = false;
	}

	private void EndSlowMotion()
	{
		_active = false;

		_moveOnTrack.DisableSlowMotion();

		if(_giftAmount > 0)
		{
			StartCoroutine(EnableButtonIn(2.0f)); // Hardcoded like in MoveOnTrack.

			_sprite.fillAmount = 1.0f;
		}
		else
		{
			// All gifts have been used -> Disable the button.
			gameObject.SetActive(false);
		}
	}

	public IEnumerator EnableButtonIn(float seconds)
	{
		float timer = 0.0f;

		while(timer < seconds)
		{
			timer += Time.deltaTime;

			yield return new WaitForSeconds(Time.deltaTime);
		}
		
		_imageButton.isEnabled = true;
	}
}
