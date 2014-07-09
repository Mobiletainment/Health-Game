using UnityEngine;
using System.Collections;

public class DrawEnergyState : MonoBehaviour 
{
	public UISprite _spriteFull;
	public UISprite _spriteLow;

	public int size = 40; // square length
	public int startposLeft = 120; // 120 px (to the right) from the left.
	public int startposTop = -60; // -60 px (down) from the center.
	public int distanceSide = 40;
	public int distanceHeight = 20;

	// Use this for initialization
	private void Start() 
	{
		EnergyManager.UpdateState();

		int currentEnergy = AvatarState.GetStateValue(AvatarState.State.CURRENT_ENERGY);

//		// DEPRECATED: The maxiumum energy value is 15. There will be drawn 3 rows with each 5 columns of energy symbols.
//		int counter = 0;
//		for(int row = 0; row < 3; ++row)
//		{
//			for(int col = 0; col < 5; ++col)
//			{
//				counter++;
//				UISprite curSprite = (counter <= currentEnergy ? _spriteFull : _spriteLow);
//				UISprite spriteInstance = Instantiate(curSprite, Vector3.zero, Quaternion.identity) as UISprite;
//				spriteInstance.transform.parent = transform;
//				spriteInstance.transform.localScale = Vector3.one;
////				spriteInstance.SetRect(startposLeft + (col * (startposLeft + distanceSide)),
////				                       startposTop + (row * (startposTop + distanceHeight)),
////				                       size, size);
//				spriteInstance.topAnchor.target = transform;
//				spriteInstance.topAnchor.absolute = startposTop - (row * (distanceHeight + size)) + size;
//				spriteInstance.bottomAnchor.target = transform;
//				spriteInstance.bottomAnchor.absolute = startposTop - (row * (distanceHeight + size));
//				spriteInstance.leftAnchor.target = transform;
//				spriteInstance.leftAnchor.absolute = startposLeft + (col * (distanceSide + size));
//				spriteInstance.rightAnchor.target = transform;
//				spriteInstance.rightAnchor.absolute = startposLeft + (col * (distanceSide + size)) + size;
//			}
//
////			Debug.Log (startposTop - (row * (startposTop - distanceHeight)));
//		}

		// The maxiumum energy value is 6, all energy symbols are drawn in one row:
		int counter = 0;
		for(int col = 0; col < 6; ++col)
		{
			counter++;
			UISprite curSprite = (counter <= currentEnergy ? _spriteFull : _spriteLow);
			UISprite spriteInstance = Instantiate(curSprite, Vector3.zero, Quaternion.identity) as UISprite;
			spriteInstance.transform.parent = transform;
			spriteInstance.transform.localScale = Vector3.one;

			spriteInstance.topAnchor.target = transform;
			spriteInstance.topAnchor.absolute = startposTop + size;
			spriteInstance.bottomAnchor.target = transform;
			spriteInstance.bottomAnchor.absolute = startposTop;
			spriteInstance.leftAnchor.target = transform;
			spriteInstance.leftAnchor.absolute = startposLeft + (col * (distanceSide + size));
			spriteInstance.rightAnchor.target = transform;
			spriteInstance.rightAnchor.absolute = startposLeft + (col * (distanceSide + size)) + size;
		}
	}
}
