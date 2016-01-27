using UnityEngine;
using System;
using System.Collections;
using System_Control;

public class Weapon_Foundation : Equipment_Foundation
{	
	
	public delegate void Attack_Delegate (Phase Set_Phase);
	public event Attack_Delegate Assign_Passive = delegate {};

	public void Passive ()
	{
		Assign_Passive();
	}



}