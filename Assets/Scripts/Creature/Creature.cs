using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System.Linq;
[RequireComponent (typeof (Display_Character_Stats))]
public class Creature : CreatureMethods 
{ 
	[Header("Config Levels")]
	public float Melee_Level = 1f;
	public float Magic_Level = 1f;
	public float Archery_Level = 1f;

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
		
		Get_Stat(Stat.Hitpoints,10f,Stat.Hitpoints_Level);
		Get_Stat(Stat.Melee_Damage,Melee_Level,Stat.Melee_Level);
		Get_Stat(Stat.Magic_Damage,Magic_Level,Stat.Magic_Level);
		Get_Stat(Stat.Archery_Damage,Archery_Level,Stat.Archery_Level);
		Get_Stat(Stat.Movement,4f,true);
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
		if (Defects.Count > 0)
		{
			Defects.ForEach(d => d.Beginning_Of_Turn());
		}
		if (Actives.Count > 0)
		{
			foreach (var i in Actives) 
			{
				i.Assign_Status(this.gameObject);
				i.Beginning_Of_Turn();
			}
		}
	}
}
