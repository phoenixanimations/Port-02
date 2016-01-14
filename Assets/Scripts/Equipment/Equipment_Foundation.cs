﻿using UnityEngine;
using System.Collections;
using System_Control;

public class Equipment_Foundation : Raycast 
{
	protected Creature Cache;
	protected float Equip_Level = 1f;
	protected float Accuracy;

	protected override void Start ()
	{
		base.Start ();
		Cache = gameObject.GetComponent<Creature>();
		Cache.AddStatus += Status;
		Cache.AddCleanUpStatus += CleanUpStatus;
		
		Cache.ModifyHitpoints(Hitpoints);
		Cache.ModifyDamage (Melee_Damage, Magic_Damage, Archery_Damage);
//		Cache.ModifyAccuracy(Accuracy);
		Cache.ModifyEvade(Evade);
		Cache.ModifyDefectChance(Defect_Chance);
		Cache.ModifyPassiveChance(Passive_Chance);
		Cache.ModifyCritical(Critical_Chance,Critical_Damage);
		Cache.ModifyResistance(Melee_Resistance,Magic_Resistance,Archery_Resistance); 
	}

	protected virtual void Status (){}

	protected virtual void CleanUpStatus (){}

	public virtual void Deactivate ()
	{
		Cache.ModifyHitpoints(-Hitpoints);
		Cache.ModifyDamage (-Melee_Damage, -Magic_Damage, -Archery_Damage);
//		Cache.ModifyAccuracy(-Accuracy);
		Cache.ModifyEvade(-Evade);
		Cache.ModifyDefectChance(-Defect_Chance);
		Cache.ModifyPassiveChance(-Passive_Chance);
		Cache.ModifyCritical(-Critical_Chance,-Critical_Damage);
		Cache.ModifyResistance(-Melee_Resistance,-Magic_Resistance,-Archery_Resistance); 
		
		Cache.AddStatus -= Status;
		Cache.AddCleanUpStatus -= CleanUpStatus;
		Destroy(this);
	}
	
	public void ModifyEquip_Level (float ModifyTierLevel) 
	{
		Equip_Level += ModifyTierLevel;
	}
	public void ModifyAccuracy (float ModifyAccuracyPercent)
	{
		Accuracy += ModifyAccuracyPercent;
	}


}



//		ModifyHitpoints(Hitpoints); //If health > max health == max





//		ModifyHitpoints(10 * Tier.Formula(Equip_Level));