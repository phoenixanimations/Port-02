using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class CreatureFoundation : Movement
{
	public bool Player;
	public bool Turn;

	public float Hitpoints_Level {get; private set;}
	public float Melee_Level     {get; private set;}
	public float Magic_Level     {get; private set;}
	public float Archery_Level   {get; private set;} 
	protected Assign_Class PrimaryClass;
	protected Assign_Class SecondaryClass;	
	protected Assign_Subclass Subclass;
	protected float PrimaryDamage;
	protected float SecondaryDamage;

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

	protected override void Start ()
	{
		base.Start ();
		ModifyHitpoints(50 * Tier.Formula(Hitpoints_Level));
	}

	public void ModifyLevel (float MeleeLevelAmount = 0f, float MagicLevelAmount = 0f, float ArcheryLevelAmount = 0f, float HitpointsLevelAmount = 0f) 
	{
		Melee_Level += MeleeLevelAmount;
		Magic_Level += MagicLevelAmount;
		Archery_Level += ArcheryLevelAmount;
		Hitpoints_Level += HitpointsLevelAmount;
	}

	public void ModifyClass (Assign_Class ChangePrimary = Assign_Class.None, Assign_Class ChangeSecondary = Assign_Class.None, Assign_Subclass ChangeSubclass = Assign_Subclass.None)
	{
		if (ChangePrimary != Assign_Class.None) PrimaryClass = ChangePrimary;
		if (ChangeSecondary != Assign_Class.None) SecondaryClass = ChangeSecondary;
		if (ChangeSubclass != Assign_Subclass.None) Subclass = ChangeSubclass;
	}
	
	public void ModifyDamage (float PrimaryDamageAmount = 0f, float SecondaryDamageAmount = 0f)
	{
		PrimaryDamage += PrimaryDamageAmount;
		SecondaryDamage += SecondaryDamageAmount;
	}
}