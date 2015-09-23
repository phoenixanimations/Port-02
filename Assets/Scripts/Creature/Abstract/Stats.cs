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
 * String Primary_Slot;
 * String Secondary_Slot;
 * String Helmet_Slot;
 * String Chest_Slot;
 * String Legs_Slot;
 * String Ammo_Slot;
 * 
 * 
 * int ID;
 *
 *
 *
 * float Hitpoints = TierArray((Weapon.Hitpoints) + (Shield.Hitpoints) + (Helmet.Hitpoints) + (Chest.Hitpoints) + (Legs.Hitpoints) + (Modified_Hitpoints_Level));
 * 
 **********In a FUNCTION**********
 * float Primary_Accuracy = Mathf.floor(0.5 * (TierArray(Primary.Accuracy + Modified_Class_Level + Accuracy_Bonus) / TierArray(Enemy.Evade + Modified_Class_Level)));
 * float Secondary_Accuracy = Mathf.floor(0.5 * (TierArray(Secondary.Accuracy + Modified_Class_Level + Accuracy_Bonus) / TierArray(Enemy.Evade + Modified_Class_Level)));
 * float Evade = Mathf.floor(TierArray(Primary.Evade + Secondary.Evade + Modified_Class_Level + Evade_Bonus));
 **********In a FUNCTION**********
 * 
 * float True_Hitpoints_Level;
 * float True_Melee_Level;
 * float True_Magic_Level;
 * float True_Archery_Level;
 * //float True_Demo_Level;
 * 
 *  
 * [component]
 * 
 * if (DualWielding) {
 * 	Melee_Level_Bonus = -10;
 * 	Magic_Level_Bonus = -10;
 * 	Archery_Level_Bonus = -10;
 * 	Demo_Level_Bonus = -10;
 * }
 * 
 * float Hitpoints_Level_Bonus;
 * 
 * float Modified_Hitpoints_Level = (True_Hitpoints_Level + 50 + Hitpoints_Level_Bonus);
 * float Modified_Melee_Level = (True_Melee_Level + Melee_Level_Bonus);
 * float Modified_Magic_Level = (True_Magic_Level + Magic_Level_Bonus);
 * float Modified_Archery_Level = (True_Archery_Level + Archery_Level_Bonus);
 * //float Modified_Demo_Level = (True_Demo_Level + Demo_Level_Bonus);
 * 
 * float Primary_Melee_Damage = TierArray(Modified_Melee_Level + Primary.Melee_Damage);
 * float Secondary_Melee_Damage = TierArray(Modified_Melee_Level + Secondary.Melee_Damage);
 * 
 * float Primary_Magic_Damage = TierArray(Modified_Magic_Level + Primary.Magic_Damage);
 * float Secondary_Magic_Damage = TierArray(Modified_Magic_Level + Secondary.Magic_Damage);
 * 
 * float Primary_Archery_Damage = TierArray(Modified_Archery_Level + Primary.Archery_Damage);
 * float Secondary_Archery_Damage = TierArray(Modified_Archery_Level + Secondary.Archery_Damage);
 * 
 * //float Primary_Demo_Damage = TierArray(Modified_Demo_Level + Primary.Demo_Damage);
 * //float Secondary_Demo_Damage = TierArray(Modified_Demo_Level + Secondary.Demo_Damage);
 * 
 * int Defect_Chance = (Primary.Defect_Chance + Secondary.Defect_Chance + Helmet.Defect_Chance + Chest.Defect_Chance + Legs.Defect_Chance + Ammo.Defect_Chance);
 * Delegate Defect;
 * 
 * int Passive_Chance = (Primary.Passive_Chance + Secondary.Passive_Chance + Helmet.Passive_Chance + Chest.Passive_Chance + Legs.Passive_Chance + Ammo.Pasive_Chance);
 * Delegate Passive;
 * 
 * float Melee_Resistance;
 * float Magic_Resistance;
 * float Archery_Resistance;
 * //float Demo_Resistance;
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
 * float Modified_MeleeDamage_ClassMod = Tier + 5;
 * float Modified_MeleeAccuracy_ClassMod = Tier + 0;
 * float Modified_MeleeEvade_ClassMod = Tier + 0;
 * float Modified_MagicDamage_ClassMod = Tier + 0;
 * float Modified_MagicAccuracy_ClassMod = Tier + 0;
 * float Modified_MagicEvade_ClassMod = Tier + 5;
 * float Modified_ArcheryDamage_ClassMod = Tier + 0;
 * float Modified_ArcheryAccuracy_ClassMod = Tier + 5;
 * float Modified_ArcheryEvade_ClassMod = Tier + 0;
 * //float Modified_DemoDamage_ClassMod = Tier + 0;
 * //float Modified_DemoAccuracy_ClassMod = Tier + 0;
 * //float Modified_DemoEvade_ClassMod = Tier + 0;
 * 
 * float Melee_Damage;
 * float Magic_Damage;
 * float Archery_Damage;
 * //float Demo_Damage;
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
 * float Demo_Resistance;
 * 
 * int Movement;
 * int Force;
 * 
 * int NumberOf
 */