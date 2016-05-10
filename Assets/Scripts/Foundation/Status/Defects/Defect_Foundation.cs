using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;
//Clear non permanent 
public class Defect_Foundation : Status_Foundation
{
	public float Turns_Left;
//	public List <float> Permanent_Stat_Bonus = new List<float>();
//	public List <float> Temporary_Stat_Bonus = new List<float>();
//You attach the defect to your weapon
	//Amensia
	public override void Activate (Creature_States Creature, Raycast Raycast, State State, Attack Attack)
	{
		base.Activate (Creature, Raycast, State, Attack);
		if (State == State.BeginningOfTurn)
		{
			Turns_Left--;
		}	

		if (State == State.EndOfTurn && Turns_Left < 1)
		{
			Creature.Defects.Remove(this);
			Destroy(this);
		}
	}
}