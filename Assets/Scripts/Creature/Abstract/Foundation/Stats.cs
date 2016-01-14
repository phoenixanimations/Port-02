using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//using System_Control;
//Change every space to a _
public class Stats : BasicTile
{
	public string Name;
	public string Description;
	
	public int ID;

	public float Hitpoints;

	protected float Melee_Resistance;
	protected float Magic_Resistance;
	protected float Archery_Resistance;

	public float Melee_Damage;
	public float Magic_Damage;
	public float Archery_Damage;

	protected float Evade;
	protected float Defect_Chance;
	protected float Passive_Chance;

	protected float Critical_Chance;
	protected float Critical_Damage;

//	protected float Melee_Damage {get; private set;}
//	protected float Magic_Damage {get; private set;}
//	protected float Archery_Damage {get; private set;}
//
//	protected float Evade {get; private set;}
//	protected float Accuracy {get; private set;}
//	protected float Defect_Chance {get; private set;}
//	protected float Passive_Chance {get; private set;}
//
//	protected float Critical_Chance {get; private set;}
//	protected float Critical_Damage {get; private set;}

//!!!!!!!!!!!!!!!!!!them all Enums? !!!!!!!!!!!!!!!!!


	public void ModifyHitpoints (float HitpointsAmount) //, bool SetHitpoints = false
	{
		Hitpoints += HitpointsAmount;
	}

	public void ModifyDamage (float ModifyMeleeDamage = 0f, float ModifyMagicDamage = 0f, float ModifyArcheryDamage = 0f)  
	{
			Melee_Damage += Mathf.Floor(ModifyMeleeDamage);
			Magic_Damage +=  Mathf.Floor(ModifyMagicDamage);
			Archery_Damage +=  Mathf.Floor(ModifyArcheryDamage);
	}

	public void ModifyEvade (float ModifyEvadePercent)
	{
		Evade += ModifyEvadePercent;
	}

	public void ModifyDefectChance (float DefectChanceAmount)
	{
		DefectChanceAmount += Defect_Chance;
	}
	
	public void ModifyPassiveChance (float PassiveChanceAmount)
	{
		Passive_Chance += PassiveChanceAmount;
	}

	public void ModifyCritical (float Critical_ChanceAmount, float Critical_DamageAmount)
	{
		Critical_Chance += Critical_ChanceAmount;
		Critical_Damage += Critical_DamageAmount;
	}

	public void ModifyResistance (float ModifyMeleeResistance = 0f, float ModifyMagicResistance = 0f, float ModifyArcheryResistance = 0f)
	{
		Melee_Resistance += ModifyMeleeResistance;
    	Magic_Resistance += ModifyMagicResistance;
    	Archery_Resistance += ModifyArcheryResistance;
	}
}



/*

Accuracy = TierArray(Class_Level);
Evade = TierArray(Enemy.Class_Level) + Primary.Evade + Secondary.Evade + Armor.Evade; 
Primary_Accuracy = 0.5 * (Accuracy + Primary.Accuracy + Armor.Accuracy) / Enemy.Evade
Secondary_Accuracy = 0.5 * (Accuracy + Secondary.Accuracy + Armor.Accuracy) / Enemy.Evade
*/
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
 * 	Melee_Level_DualWieldNerf = -10;
 * 	Magic_Level_DualWieldNerf = -10;
 * 	Archery_Level_DualWieldNerf = -10;
 * 	Demo_Level_DualWieldNerf = -10;
 *
 *	Melee_PrimaryDamage_Bonus = Mathf.floor(0.5 * Melee_Bonus);
 *	Melee_SecondaryDamage_Bonus = Mathf.floor(0.5 * Melee_Bonus);
 *	Magic_PrimaryDamage_Bonus = Mathf.floor(0.5 * Magic_Bonus);
 *	Magic_SecondaryDamage_Bonus = Mathf.floor(0.5 * Magic_Bonus);
 *	Archery_PrimaryDamage_Bonus = Mathf.floor(0.5 * Archery_Bonus);
 *	Archery_SecondaryDamage_Bonus = Mathf.floor(0.5 * Archery_Bonus);
 *	Demo_PrimaryDamage_Bonus = Mathf.floor(0.5 * Demo_Bonus);
 *	Demo_SecondaryDamage_Bonus = Mathf.floor(0.5 * Demo_Bonus);
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