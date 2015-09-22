using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Stats : BasicTile
{
	public float TestTier;
	public float Result;

	public List<float> ListDamage = new List<float>();
	
	public float TotalDamage;

	protected override void Update ()
	{
		base.Update ();
		Result = (TierArray(TestTier));
		TotalDamage = CalculateList(ListDamage);
	}

	public int Health;
	public int Damage;

	private int test;
	protected List<int> ListHealth = new List<int>();


	protected float CalculateList (List<float> IntArray)
	{
		float Total = 0;
		for (int i = 0; i < IntArray.Count; i++) Total += IntArray[i];
		return Total;
	}

	public void AddDamage    (int DamageAmount)  {Damage += DamageAmount;}
	public void RemoveDamage (int DamageAmount)  {Damage -= DamageAmount;}
	public void AddHealth    (int HealthAmount)  {Health += HealthAmount;}
	public void RemoveHealth (int HealthAmount)  {Health -= HealthAmount;}

	public float TierArray (float TierNumber) 
	{
		float lastdigit = (TierNumber % 10);
		float firstdigit =	TierNumber * .1f;
		if (TierNumber < 10 && TierNumber > 0)
			firstdigit = 0;
		if (TierNumber < 1)
		{
			if (TierNumber == 0)
				return 10;
			if (TierNumber == -1 || TierNumber == -2)
				return 9;
			if (TierNumber == -3 || TierNumber == -4)
				return 8;
			if (TierNumber == -5 || TierNumber == -6)
				return 7;
			if (TierNumber == -7 || TierNumber == -8)
				return 6;
			if (TierNumber == -9 || TierNumber == -10)
				return 5;
			if (TierNumber <= -11 && TierNumber > -15)
				return 4;
			if (TierNumber <= -15 && TierNumber > -19)
				return 3;
			if (TierNumber <= -19 && TierNumber > -25)
				return 2;
			if (TierNumber <= -25 && TierNumber > -35)
				return 1;
			if (TierNumber <= -35)
				return 0;	
		}
		return (10 + lastdigit) * (Mathf.Pow(2,Mathf.Floor(firstdigit)));
	}
}


 


/*
 **********PLAYER**********
 * String Name;
 * String Description;
 * String Class;
 * String SubClass;
 * String Slot;
 * 
 * int ID;
 *
 * float Hitpoints = Tier ((Weapon.Hitpoints) + (Shield.Hitpoints) + (Helmet.Hitpoints) + (Chest.Hitpoints) + (Legs.Hitpoints) + Modify_Hitpoints_Level);
 * float Accuracy;
 * float Evade;
 * 
 * float True_Hitpoints_Level;
 * float True_Melee_Level;
 * float True_Magic_Level;
 * float True_Archery_Level;
 * 
 * float Hitpoints_Level_Bonus;
 * 
 * float Modify_Hitpoints_Level = Tier(True_Hitpoints_Level + Hitpoints_Level_Bonus);
 * float Modify_Melee_Level = Tier(True_Melee_Level + Bonus);
 * float Modify_Magic_Level
 * float Modify_Archery_Level
 * 
 * float Primary_Melee_Damage = Modify_Melee_Level + Weapon.Melee;
 * float Secondary_Melee_Damage = Modify_Melee_Level + Weapon.Melee;
 * 
 * if (DW) 
 * Melee_Level_Bonus = -10;
 * 
 * float Primary_Archery_Damage
 * float Secondary_Archery_Damage
 * 
 * float Primary_Magic_Damage
 * float Secondary_Magic_Damage
 * 
 * int Defect_Chance = Weapon.Defect_Chance + Shield.Defect_Chance + Helmet.Defect_Chance + Chest.Defect_Chance + Legs.Defect_Chance;
 * Delegate Defect;
 * 
 * int Passive_Chance = Weapon.Passive_Chance + Shield.Passive_Chance + Helmet.Passive_Chance + Chest.Passive_Chance + Legs.Passive_Chance;
 * Delegate Passive;
 * 
 * float Melee_Resistance;
 * float Magic_Resistance;
 * float Archery_Resistance;
 * 
 * int Movement;
 * int Force;
 * 
 * *********WEAPON**********
 * String Name;
 * String Description;
 * String Class;
 * String SubClass;
 * String Slot;
 * 
 * int ID;
 * 
 * float Tier;
 * 
 * float Hitpoints;
 * float Accuracy;
 * float Evade;
 * 
 * float Modify_Melee_Tier = Tier + 5;
 * float Modify_Magic_Tier = Tier;
 * float Modify_Archery_Tier = Tier;
 * 
 * float Melee_Damage 
 * float Archery_Damage
 * float Magic_Damage
 *
 * int Defect_Chance
 * Delegate Defect;
 * 
 * int Passive_Chance
 * Delegate Passive;
 * 
 * float Melee_Resistance;
 * float Magic_Resistance;
 * float Archery_Resistance;
 * 
 * int Movement;
 * int Force;
 * 
 * int NumberOf
 */