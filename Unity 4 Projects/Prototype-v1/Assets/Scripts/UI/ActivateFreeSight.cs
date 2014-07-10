using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateFreeSight : MonoBehaviour 
{
	public MoveOnTrack _moveOnTrack;
	public float _duration = 1.0f;

	private UISprite _sprite;
	private bool _wasClicked = false;

	private void Start()
	{
		// Disable this button, if no sight-gifts are available
		if(AvatarState.GetStateValue(AvatarState.State.GIFT_FREE_SIGHT) <= 0)
		{
//			gameObject.SetActive(false);
			gameObject.GetComponent<UIImageButton>().isEnabled = false;
		}
		
		_sprite = transform.GetComponentInChildren(typeof(UISprite)) as UISprite;
	}

	private void OnClick() 
	{
		// This button can only be used once...
		if(_wasClicked == false)
		{
			_wasClicked = true;

			PickupManager puManager = _moveOnTrack.GetPickupManager();
			PickupContainer<PickupManager.PickupLev> pickups = puManager.GetPickups();

			foreach(KeyValuePair<PickupLine, List<PickupManager.PickupLev>> puPair in pickups.GetLineDict())
			{
				foreach(PickupManager.PickupLev pickupLev in puPair.Value)
				{
					StartCoroutine(_moveOnTrack.ChangePickupVisability(pickupLev.Pickup, _duration));
				}
			}

			// The gift "FreeSight" has been used:
			AvatarState.DecreaseStateValue(AvatarState.State.GIFT_FREE_SIGHT);

			// Disable the button, because its work is done:
			StartCoroutine(DisableButtonIn(_duration));
		}
	}

	public IEnumerator DisableButtonIn(float seconds)
	{
		float timer = 0.0f;
		
		while(timer < seconds)
		{
			timer += Time.deltaTime;

			_sprite.fillAmount = 1.0f - (timer / seconds);
			
			yield return new WaitForSeconds(Time.deltaTime);
		}
		
		_sprite.fillAmount = 0f;
		gameObject.SetActive(false);
	}
}
