using UnityEngine;
using System.Collections;
using System;
using System_Control;

public class Equipment_Foundation : Stats 
{
	public float Hitpoints;
	public float Melee_Damage;
	public float Magic_Damage, Archery_Damage, Critical_Damage;
	public float Melee_Resistance;
	public float Magic_Resistance, Archery_Resistance;
	public float Critical_Chance;
	public float Accuracy, Evade, Defect_Chance, Passive_Chance;
	
	public Assign_Class Class;
	public Assign_Subclass Subclass;
	public Status_Foundation Status; //Make a list

	public Stat Assign_Stat;
	public float Amount;
	public bool Set_Stat;

	protected Creature Cache;

	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Stat_Dictionary.Add("Equip_Level",1f);
		Stat_Dictionary.Add("Defect_Chance",1f);
		Stat_Dictionary.Add("Passive_Chance",1f);
	}

	protected override void Start ()
	{
		base.Start ();
		if (gameObject.GetComponent<Creature>() == null)
		{
			Debug.LogError("Attach Equipment to a creature!");
			return;
		}


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
		if (Status != null) Status.Deactivate(); //Modify for lists
		Destroy(this);
	}

}