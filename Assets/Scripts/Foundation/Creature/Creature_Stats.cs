using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class Creature_Stats : Stats
{
	public bool Player;
 	[HideInInspector]
	public bool Turn;
	public float Storey = 1;
	public float Height = 1.98f;

	public Equipment_Foundation PrimaryHand;	  
	public Equipment_Foundation SecondaryHand;  
	public Equipment_Foundation Armor;  
	public Equipment_Foundation Arrow;   

	public Catagory Catagory;

	public List<Status_Foundation> Passives = new List<Status_Foundation>();
	public List<Active_Foundation> Actives = new List<Active_Foundation>();
	public List<Defect_Foundation> Defects = new List<Defect_Foundation>();
	public List<Equipment_Foundation> Inventory = new List<Equipment_Foundation>();

	protected Raycast Raycast;
	public SpriteRenderer SpriteRenderer {private set;get;}
	
	protected override void Start ()
	{
		base.Start ();
		Raycast = GetComponent<Raycast>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public float Max_Hitpoints ()
	{
		float Level_Hitpoints = 10f * Tier.Formula(Get_Stat(Stat.Hitpoints_Level));
		float Primary_Secondary_Hitpoints = PrimaryHand.Get_Stat(Stat.Hitpoints) + 
								 			SecondaryHand.Get_Stat(Stat.Hitpoints);

		float Armor_Hitpoints = Armor.Get_Stat(Stat.Hitpoints);
		float Arrow_Hitpoints = Arrow.Get_Stat(Stat.Hitpoints);
		float Max_Hitpoints = Level_Hitpoints + Primary_Secondary_Hitpoints + Armor_Hitpoints + Arrow_Hitpoints;
		return Max_Hitpoints;
	}

	public float Combat_Level ()
	{
		float Tier_Hitpoints_Level = Tier.Formula(Get_Stat(Stat.Hitpoints_Level));
		float Tier_Melee_Level = Tier.Formula(Get_Stat(Stat.Melee_Level));
		float Tier_Magic_Level = Tier.Formula(Get_Stat(Stat.Magic_Level));
		float Tier_Archery_Level = Tier.Formula(Get_Stat(Stat.Archery_Level));
		float Sum_Of_Levels = Tier_Hitpoints_Level + Tier_Melee_Level + Tier_Magic_Level + Tier_Archery_Level;
		float Average_Of_Levels = Sum_Of_Levels/4f;
		float Find_Combat_Level;
		for (Find_Combat_Level = 0; Tier.Formula(Find_Combat_Level) <= Average_Of_Levels; Find_Combat_Level++);
		Find_Combat_Level--;
		return Find_Combat_Level;
	}
}