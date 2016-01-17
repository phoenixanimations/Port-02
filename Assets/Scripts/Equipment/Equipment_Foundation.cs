using UnityEngine;
using System.Collections;
using System_Control;

public class Equipment_Foundation : Raycast 
{
	protected Creature Cache;

	protected override void Awake ()
	{
		base.Awake ();
		Stat_Dictionary.Add("Equip_Level",0f);
	}

	protected override void Start ()
	{
		base.Start ();
		Cache = gameObject.GetComponent<Creature>();
		Cache.AddStatus += Status;
		Cache.AddCleanUpStatus += CleanUpStatus;
		
		Cache.Get_Stat(Stat.Hitpoints,				Get_Stat(Stat.Hitpoints));
		Cache.Get_Stat(Stat.Melee_Damage,			Get_Stat(Stat.Melee_Damage));
		Cache.Get_Stat(Stat.Magic_Damage,			Get_Stat(Stat.Magic_Damage));
		Cache.Get_Stat(Stat.Archery_Damage,			Get_Stat(Stat.Archery_Damage));
		Cache.Get_Stat(Stat.Critical_Damage,		Get_Stat(Stat.Critical_Damage));
		Cache.Get_Stat(Stat.Critical_Chance,		Get_Stat(Stat.Critical_Chance));
		Cache.Get_Stat(Stat.Accuracy,				Get_Stat(Stat.Accuracy));	
		Cache.Get_Stat(Stat.Evade,					Get_Stat(Stat.Evade));
		Cache.Get_Stat(Stat.Defect_Chance,			Get_Stat(Stat.Defect_Chance));
		Cache.Get_Stat(Stat.Passive_Chance,			Get_Stat(Stat.Passive_Chance));
		Cache.Get_Stat(Stat.Melee_Resistance,		Get_Stat(Stat.Melee_Resistance));
		Cache.Get_Stat(Stat.Magic_Resistance,		Get_Stat(Stat.Magic_Resistance));
		Cache.Get_Stat(Stat.Archery_Resistance,		Get_Stat(Stat.Archery_Resistance));
	
	}

	protected virtual void Status (){}

	protected virtual void CleanUpStatus (){}

	public virtual void Deactivate ()
	{
		if (Cache.Get_Stat(Stat.Hitpoints) >= (Cache.Get_Stat(Stat.Hitpoints) - Get_Stat (Stat.Hitpoints)))
		{
			Cache.Get_Stat(Stat.Hitpoints, -Get_Stat(Stat.Hitpoints));
		}
		Cache.Get_Stat(Stat.Melee_Damage,			-Get_Stat(Stat.Melee_Damage));
		Cache.Get_Stat(Stat.Magic_Damage,			-Get_Stat(Stat.Magic_Damage));
		Cache.Get_Stat(Stat.Archery_Damage,			-Get_Stat(Stat.Archery_Damage));
		Cache.Get_Stat(Stat.Critical_Damage,		-Get_Stat(Stat.Critical_Damage));
		Cache.Get_Stat(Stat.Critical_Chance,		-Get_Stat(Stat.Critical_Chance));
		Cache.Get_Stat(Stat.Accuracy,				-Get_Stat(Stat.Accuracy));	
		Cache.Get_Stat(Stat.Evade,					-Get_Stat(Stat.Evade));
		Cache.Get_Stat(Stat.Defect_Chance,			-Get_Stat(Stat.Defect_Chance));
		Cache.Get_Stat(Stat.Passive_Chance,			-Get_Stat(Stat.Passive_Chance));
		Cache.Get_Stat(Stat.Melee_Resistance,		-Get_Stat(Stat.Melee_Resistance));
		Cache.Get_Stat(Stat.Magic_Resistance,		-Get_Stat(Stat.Magic_Resistance));
		Cache.Get_Stat(Stat.Archery_Resistance,		-Get_Stat(Stat.Archery_Resistance));	

		Cache.AddStatus -= Status;
		Cache.AddCleanUpStatus -= CleanUpStatus;
		Destroy(this);
	}

}



//		ModifyHitpoints(Hitpoints); //If health > max health == max





//		ModifyHitpoints(10 * Tier.Formula(Equip_Level));