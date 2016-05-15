using UnityEngine;
using System.Collections;
using System_Control;

public class Status_Foundation : Stats
{
	public State When_To_Activate;
	public string Status_Notes;
	public virtual void Activate (Creature_States Creature, Raycast Raycast, State State, Attack Attack) 
	{
		
	}
}