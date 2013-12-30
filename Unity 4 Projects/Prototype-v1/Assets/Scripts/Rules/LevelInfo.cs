using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelInfo : MonoBehaviour
{
	// FIND OTHER SOLUTION:
	private static int[] PositiveItemCountConfig = new int[] { 20, 20, 20, 28, 40 }; //Level 1 = 8 good Items in total, etc.
	private static int[] TotalPositiveItemCountConfig = new int[] { 35, 45, 55, 60, 70, 90, 120 };
	
	public int Level;
	public int NecessaryPositiveItems { get { return PositiveItemCountConfig[Level]; } }
	public int TotalPositiveItemCount { get { return TotalPositiveItemCountConfig[Level]; } }
}
