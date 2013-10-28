using UnityEngine;
using System.Collections;

public class Skill 
{
	public string Name {get; private set;}
	
	//[System.ComponentModel.DefaultValue(0)]
	public int MinValue {get; private set;}
	//[System.ComponentModel.DefaultValue(10)]
	public int MaxValue {get; private set;}
	//[System.ComponentModel.DefaultValue(0)]
	public int DefaultValue {get; private set;}
	//[System.ComponentModel.DefaultValue(0)]
	public int CurrentValue {get; set;}
	
	public Skill(string name, int minValue = 0, int maxValue = 10, int defaultValue = 0, int currentValue = 0 )
	{
		Name = name;
		MinValue = minValue;
		MaxValue = maxValue;
		DefaultValue = defaultValue;
		CurrentValue = currentValue;
	}
	
	public void Increase()
	{
		if(CurrentValue < MaxValue)
			++CurrentValue;
	}
	
	public void Decrease()
	{
		if(CurrentValue > MinValue)
			--CurrentValue;
	}
	
}
