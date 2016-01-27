using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class CreatureFoundation : Movement
{
	public bool Player;
	public bool Turn;

	public Assign_Class Primary_Class {protected set; get;}
	public Assign_Class Secondary_Class {protected set; get;}	
	public Assign_Subclass Primary_Subclass {protected set; get;}
	public Assign_Subclass Secondary_Subclass {protected set; get;}
	
	public string CreatureType;
	public string State;
	public delegate void Delegate ();
	
	protected Attack Cache_Attack;
	protected List<Type> Inventory = new List<Type>();
	protected Type Primary_Weapon;
	protected Type Secondary_Weapon;
	protected Type Helmet;
	protected Type Chest;
	protected Type Legs;
	protected bool EnableState;


	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Stat_Dictionary.Add("Hitpoints_Level", 1f);
		Stat_Dictionary.Add("Melee_Level",1f);
		Stat_Dictionary.Add("Magic_Level",1f);
		Stat_Dictionary.Add("Archery_Level",1f);

		Stat_Dictionary.Add("Primary_Damage",0f);
		Stat_Dictionary.Add("Primary_Accuracy",0f);
		Stat_Dictionary.Add("Secondary_Damage",0f);
		Stat_Dictionary.Add("Secondary_Accuracy",0f);
	
		Stat_Dictionary.Add("Primary_Critical_Damage",0f);
		Stat_Dictionary.Add("Primary_Critical_Chance",0f);
		Stat_Dictionary.Add("Secondary_Critical_Damage",0f);
		Stat_Dictionary.Add("Secondary_Critical_Chance",0f);

		Stat_Dictionary.Add("Primary_Number_Of_Attacks",0f);
		Stat_Dictionary.Add("Secondary_Number_Of_Attacks",0f);
		Stat_Dictionary.Add("Energy", 0f);
	}

	protected override void Start ()
	{
		base.Start ();
		gameObject.AddComponent<Display_Character_Stats>();
		gameObject.AddComponent<Attack>();
		Cache_Attack = GetComponent<Attack>();
	}

	
	public void Modify_Class (Assign_Class ChangePrimary = Assign_Class.None, Assign_Class ChangeSecondary = Assign_Class.None, Assign_Subclass ChangeSubclass = Assign_Subclass.None)
	{
		if (ChangePrimary != Assign_Class.None) Primary_Class = ChangePrimary;
		if (ChangeSecondary != Assign_Class.None) Secondary_Class = ChangeSecondary;
		if (ChangeSubclass != Assign_Subclass.None) Primary_Subclass = ChangeSubclass;
		if (ChangeSubclass != Assign_Subclass.None) Secondary_Subclass = ChangeSubclass;

	}
}