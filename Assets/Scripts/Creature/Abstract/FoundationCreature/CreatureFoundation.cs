using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class CreatureFoundation : Movement
{
	public bool Player;
	public bool Turn;

	protected Assign_Class PrimaryClass;
	protected Assign_Class SecondaryClass;	
	protected Assign_Subclass Subclass;
	
	public string CreatureType;
	public string State;
	public delegate void Delegate ();
	protected List<Type> Inventory = new List<Type>();
	protected Type Primary_Weapon;
	protected Type Secondary_Weapon;
	protected Type Helmet;
	protected Type Chest;
	protected Type Legs;
	protected bool EnableState;

	protected override void Awake ()
	{
		base.Awake ();
		Stat_Dictionary.Add("Hitpoints_Level", 1f);
		Stat_Dictionary.Add("Melee_Level",1f);
		Stat_Dictionary.Add("Magic_Level",1f);
		Stat_Dictionary.Add("Archery_Level",1f);
		Stat_Dictionary.Add("PrimaryDamage",0f);
		Stat_Dictionary.Add("SecondaryDamage",0f);
		Stat_Dictionary.Add("PrimaryAccuracy",0f);
		Stat_Dictionary.Add("SecondaryAccuracy",0f);

	
	}

	protected override void Start ()
	{
		base.Start ();
		gameObject.AddComponent<Display_Character_Stats>();
	}

	
	public void ModifyClass (Assign_Class ChangePrimary = Assign_Class.None, Assign_Class ChangeSecondary = Assign_Class.None, Assign_Subclass ChangeSubclass = Assign_Subclass.None)
	{
		if (ChangePrimary != Assign_Class.None) PrimaryClass = ChangePrimary;
		if (ChangeSecondary != Assign_Class.None) SecondaryClass = ChangeSecondary;
		if (ChangeSubclass != Assign_Subclass.None) Subclass = ChangeSubclass;
	}
}