using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;

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

	protected override void Awake ()
	{
		base.Awake ();
		CreatureType = "Creature";
		EnableState = true;
		if (!Player) GameManager.crystal.Add(this);
		if (Player) GameManager.castles.Add (this);
		if (Player) gameObject.AddComponent<Character_Controller>().hideFlags = HideFlags.HideInInspector;
		Get_Stat(Stat.Hitpoints_Level,1f,true);
		Get_Stat(Stat.Melee_Level,1f,true);
		Get_Stat(Stat.Magic_Level,1f,true);
		Get_Stat(Stat.Archery_Level,1f,true);

	}

	protected override void Start ()
	{
		base.Start ();
		Get_Stat(Stat.Hitpoints,50,Stat.Hitpoints_Level);
	}
}