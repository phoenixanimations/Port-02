using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class CreatureFoundation : Movement
{
	[HideInInspector]
	public bool Turn;
	public bool Player;
	[HideInInspector]
	public string CreatureType, State;
	public GameObject Primary_Weapon;
	public GameObject Secondary_Weapon;
	public GameObject Helmet;
	public GameObject Chest;
	public GameObject Legs;
	public delegate void Delegate ();

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
	}
}