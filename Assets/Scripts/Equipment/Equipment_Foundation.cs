using UnityEngine;
using System.Collections;
using System_Control;

public class Equipment_Foundation : Stats 
{
	protected Creature Cache;
	public Assign_Class Class {get; protected set;}
	public Assign_Subclass Subclass {get; protected set;}

	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Stat_Dictionary.Add("Equip_Level",1f);
		Stat_Dictionary.Add("Defect_Chance",1f);
		Stat_Dictionary.Add("Passive_Chance",1f);

		Class = Assign_Class.None;
	  	Subclass = Assign_Subclass.None;

	}

	protected override void Start ()
	{
		base.Start ();
		Cache = gameObject.GetComponent<Creature>();
		
		Cache.Get_Stat(Stat.Hitpoints,				Get_Stat(Stat.Hitpoints));	
		Cache.Get_Stat(Stat.Evade,					Get_Stat(Stat.Evade));
		Cache.Get_Stat(Stat.Melee_Resistance,		Get_Stat(Stat.Melee_Resistance));
		Cache.Get_Stat(Stat.Magic_Resistance,		Get_Stat(Stat.Magic_Resistance));
		Cache.Get_Stat(Stat.Archery_Resistance,		Get_Stat(Stat.Archery_Resistance));

	}

	public virtual void Deactivate ()
	{
		if (Cache.Get_Stat(Stat.Hitpoints) >= (Cache.Get_Stat(Stat.Hitpoints) - Get_Stat (Stat.Hitpoints)))
		{
			Cache.Get_Stat(Stat.Hitpoints, -Get_Stat(Stat.Hitpoints));
		}
	
		Cache.Get_Stat(Stat.Evade,					-Get_Stat(Stat.Evade));
		Cache.Get_Stat(Stat.Melee_Resistance,		-Get_Stat(Stat.Melee_Resistance));
		Cache.Get_Stat(Stat.Magic_Resistance,		-Get_Stat(Stat.Magic_Resistance));
		Cache.Get_Stat(Stat.Archery_Resistance,		-Get_Stat(Stat.Archery_Resistance));	

		Destroy(this);
	}

}