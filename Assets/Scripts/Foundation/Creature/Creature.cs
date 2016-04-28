using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System_Control.Extensions;

[RequireComponent (typeof (Raycast))]
public class Creature : Creature_Physics 
{ 
	public Creature_AI Assign_AI;
	public float Change_All_Levels;

	protected override void Start ()
	{
		base.Start (); 
		if (Player) gameObject.AddComponent<CreatureController>();
		Get_Stat(Stat.Hitpoints,Max_Hitpoints(),true);
	}

	public void AI () 
	{
		Assign_AI.StateMachine();
	}
}

///Have a level up for change all levels
// Have a level up section in the thingy