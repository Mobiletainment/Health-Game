using UnityEngine;
using System.Collections;

public class GiftPresentation : MonoBehaviour 
{
	public UILabel _giftAmountEnergy;
	public UILabel _giftAmountSight;
	public UILabel _giftAmountSlowMotion;
	public UILabel _giftAmountResurrection;

	public void Start()
	{
		int energy = AvatarState.GetStateValue(AvatarState.State.GIFT_ENERGY_BOOST);
		int sight = AvatarState.GetStateValue(AvatarState.State.GIFT_FREE_SIGHT);
		int slowmo = AvatarState.GetStateValue(AvatarState.State.GIFT_SLOW_MOTION);
		int resurrection = AvatarState.GetStateValue(AvatarState.State.GIFT_RESURRECTION);

		if(energy > 0)
		{
			_giftAmountEnergy.text = energy.ToString();
		}
		else
		{
			_giftAmountEnergy.transform.parent.gameObject.SetActive(false);
		}

		if(sight > 0)
		{
			_giftAmountSight.text = sight.ToString();
		}
		else
		{
			_giftAmountSight.transform.parent.gameObject.SetActive(false);
		}

		if(slowmo > 0)
		{
			_giftAmountSlowMotion.text = slowmo.ToString();
		}
		else
		{
			_giftAmountSlowMotion.transform.parent.gameObject.SetActive(false);
		}

		if(resurrection > 0)
		{
			_giftAmountResurrection.text = resurrection.ToString();
		}
		else
		{
			_giftAmountResurrection.transform.parent.gameObject.SetActive(false);
		}
	}
}
