using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System_Control;

public class Equipment_Foundation : Stats 
{
	public int ID;
	public Assign_Class Class;
	public Assign_Subclass Subclass;
	public List<Status_Foundation> Status = new List<Status_Foundation>();
	protected Creature Cache;

	public void Beginning_Of_Turn ()
	{
		if (Status_Less_Than_Zero()) return;
//		Debug.Log();
		foreach (var i in Status) 
		{
//			i.Beginning_Of_Turn();
		}
	}

	public void Attack_Status (Phase Which_Phase)
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
//			i.Attack_Status(Which_Phase);
		}
	}

	public void End_Of_Turn ()
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
//			i.End_Of_Turn();
		}
	}

	public override void Assign_Stats ()
	{
		base.Assign_Stats ();

		if (gameObject.GetComponent<Creature>() == null)
		{
			Debug.LogError("Attach Equipment to a creature!");
			return;
		}	
		Cache = gameObject.GetComponent<Creature>();

		Cache.Get_Stat(Stat.Hitpoints,			Get_Stat(Stat.Hitpoints));	
		Cache.Get_Stat(Stat.Melee_Damage,		Get_Stat(Stat.Melee_Damage));
		Cache.Get_Stat(Stat.Magic_Damage,		Get_Stat(Stat.Magic_Damage));
		Cache.Get_Stat(Stat.Archery_Damage,		Get_Stat(Stat.Archery_Damage));
		Cache.Get_Stat(Stat.Critical_Damage,	Get_Stat(Stat.Critical_Damage));
		Cache.Get_Stat(Stat.Critical_Chance,	Get_Stat(Stat.Critical_Chance));
		Cache.Get_Stat(Stat.Accuracy,			Get_Stat(Stat.Accuracy));
		Cache.Get_Stat(Stat.Evade,				Get_Stat(Stat.Evade));
		Cache.Get_Stat(Stat.Melee_Resistance,	Get_Stat(Stat.Melee_Resistance));
		Cache.Get_Stat(Stat.Magic_Resistance,	Get_Stat(Stat.Magic_Resistance));
		Cache.Get_Stat(Stat.Archery_Resistance,	Get_Stat(Stat.Archery_Resistance));
	}

	public virtual void Terminate_Stats ()
	{
		if (Cache.Get_Stat(Stat.Hitpoints) >= (Cache.Get_Stat(Stat.Hitpoints) - Get_Stat (Stat.Hitpoints)))
		{
			Cache.Get_Stat(Stat.Hitpoints, -Get_Stat(Stat.Hitpoints));
		}
		Cache.Get_Stat(Stat.Melee_Damage,		-Get_Stat(Stat.Melee_Damage));
		Cache.Get_Stat(Stat.Magic_Damage,		-Get_Stat(Stat.Magic_Damage));
		Cache.Get_Stat(Stat.Archery_Damage,		-Get_Stat(Stat.Archery_Damage));
		Cache.Get_Stat(Stat.Critical_Damage,	-Get_Stat(Stat.Critical_Damage));
		Cache.Get_Stat(Stat.Critical_Chance,	-Get_Stat(Stat.Critical_Chance));
		Cache.Get_Stat(Stat.Accuracy,			-Get_Stat(Stat.Accuracy));
		Cache.Get_Stat(Stat.Evade,				-Get_Stat(Stat.Evade));
		Cache.Get_Stat(Stat.Melee_Resistance,	-Get_Stat(Stat.Melee_Resistance));
		Cache.Get_Stat(Stat.Magic_Resistance,	-Get_Stat(Stat.Magic_Resistance));
		Cache.Get_Stat(Stat.Archery_Resistance,	-Get_Stat(Stat.Archery_Resistance));

		Terminate_Status ();
		Destroy(this);
	}

	private void Terminate_Status ()
	{
		foreach (var i in Status)
		{
			i.Terminate_Stats();
		}
	}
	
	private bool Status_Less_Than_Zero () 
	{
		if (Status.Count > 0) return false;
		return true;
	}
}