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
	public float Hitpoints_Level = 1f;
//	public float Melee_Level = 1f;
//	public float Magic_Level = 1f;
//	public float Archery_Level = 1f;

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
			
		Get_Stat(Stat.Hitpoints_Level   ,  Hitpoints_Level,true);
		Get_Stat(Stat.Melee_Level,   Hitpoints_Level,true);//Hitpoints_Level
		Get_Stat(Stat.Magic_Level,   Hitpoints_Level,true);//Hitpoints_Level
		Get_Stat(Stat.Archery_Level, Hitpoints_Level,true);//Hitpoints_Level
		Primary_Weapon.Level = Hitpoints_Level;
		Secondary_Weapon.Level = Hitpoints_Level;
		Armor.Level = Hitpoints_Level;


		Get_Stat(Stat.Hitpoints,Primary_Weapon.Get_Stat(Stat.Hitpoints));
		Get_Stat(Stat.Hitpoints,Secondary_Weapon.Get_Stat(Stat.Hitpoints));
		Get_Stat(Stat.Movement,4f,true);
		Get_Stat(Stat.Hitpoints,10f,Stat.Hitpoints_Level,true);
		Get_Stat(Stat.Hitpoints,Armor.Get_Stat(Stat.Hitpoints));
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
		Heal_Bonus.Clear();
		Heal_Bonus.Add(0f);
		
		if (Primary_Weapon != null)   Primary_Weapon.Beginning_Of_Turn(this.gameObject);
		if (Secondary_Weapon != null) Secondary_Weapon.Beginning_Of_Turn(this.gameObject);
		if (Armor != null)			  Armor.Beginning_Of_Turn(this.gameObject);
		if (Defects.Count > 0)
		{
			Defects.ForEach(d => d.Assign_Status(this.gameObject));
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
