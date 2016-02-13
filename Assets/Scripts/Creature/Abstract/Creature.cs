using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;
[RequireComponent (typeof (Display_Character_Stats))]
public class Creature : CreatureMethods 
{ 
	public override void Dead ()
	{
		base.Dead ();
		if (Get_Stat(Stat.Hitpoints) < 1) 
		{
			if (!Player) GameManager.crystal.Remove(this);
			if (Player) GameManager.castles.Remove (this);
			Destroy (this.gameObject);
		}
	}

	public override void Assign_Stats ()
	{
		base.Assign_Stats ();
		CreatureType = "Creature";
		if (Primary_Weapon != null) 	Get_Stat(Stat.Hitpoints,Primary_Weapon.Get_Stat(Stat.Hitpoints));
		if (Secondary_Weapon != null)   Get_Stat(Stat.Hitpoints,Secondary_Weapon.Get_Stat(Stat.Hitpoints));
		if (Armor != null)			 	Get_Stat(Stat.Hitpoints,Armor.Get_Stat(Stat.Hitpoints));
		
		Get_Stat(Stat.Hitpoints,50,Stat.Hitpoints_Level);
		Get_Stat(Stat.Melee_Damage,1,Stat.Melee_Level);
		Get_Stat(Stat.Magic_Damage,1,Stat.Magic_Level);
		Get_Stat(Stat.Archery_Damage,1,Stat.Archery_Level);
	}

	protected override void Start ()
	{
		base.Start ();
		EnableState = true;
		if (!Player) GameManager.crystal.Add(this);
		if (Player) GameManager.castles.Add (this);
		if (Player) gameObject.AddComponent<Character_Controller>().hideFlags = HideFlags.HideInInspector;
	}

	public void Activate_Status () 			   
	{
		if (Primary_Weapon != null)   Primary_Weapon.Beginning_Of_Turn(this.gameObject);
		if (Secondary_Weapon != null) Secondary_Weapon.Beginning_Of_Turn(this.gameObject);
		if (Armor != null)			  Armor.Beginning_Of_Turn(this.gameObject);
		if (Status.Count > 0)
		{
			foreach (var i in Status) 
			{
				i.Assign_Status(this.gameObject);
				i.Beginning_Of_Turn();
			}
		}
	}
}
