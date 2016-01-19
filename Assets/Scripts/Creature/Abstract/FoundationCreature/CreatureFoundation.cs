using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class CreatureFoundation : Movement
{
	public bool Player;
	public bool Turn;

	protected Assign_Class Primary_Class;
	protected Assign_Class Secondary_Class;	
	protected Assign_Subclass Primary_Subclass;
	protected Assign_Subclass Secondary_Subclass;

	
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

		Stat_Dictionary.Add("Primary_Damage",0f);
		Stat_Dictionary.Add("Primary_Accuracy",0f);
		Stat_Dictionary.Add("Secondary_Damage",0f);
		Stat_Dictionary.Add("Secondary_Accuracy",0f);
	
		Stat_Dictionary.Add("Primary_Critical_Damage",0f);
		Stat_Dictionary.Add("Primary_Critical_Chance",0f);
		Stat_Dictionary.Add("Secondary_Critical_Damage",0f);
		Stat_Dictionary.Add("Secondary_Critical_Chance",0f);
		
		Stat_Dictionary.Add("Primary_Defect_Chance",0f);
		Stat_Dictionary.Add("Primary_Passive_Chance",0f);
		Stat_Dictionary.Add("Secondary_Defect_Chance",0f);
		Stat_Dictionary.Add("Secondary_Passive_Chance",0f);

	}

	protected override void Start ()
	{
		base.Start ();
		gameObject.AddComponent<Display_Character_Stats>();
	}

	
	public void Modify_Class (Assign_Class ChangePrimary = Assign_Class.None, Assign_Class ChangeSecondary = Assign_Class.None, Assign_Subclass ChangeSubclass = Assign_Subclass.None)
	{
		if (ChangePrimary != Assign_Class.None) Primary_Class = ChangePrimary;
		if (ChangeSecondary != Assign_Class.None) Secondary_Class = ChangeSecondary;
		if (ChangeSubclass != Assign_Subclass.None) Primary_Subclass = ChangeSubclass;
		if (ChangeSubclass != Assign_Subclass.None) Secondary_Subclass = ChangeSubclass;

	}
}