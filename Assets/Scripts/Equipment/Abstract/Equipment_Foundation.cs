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
	public float Level = 1;

	public override void Level_Up (Stat Stat, float Amount = 1, bool SetLevel = false)
	{
		base.Level_Up (Stat, Amount, SetLevel);
		if (Stat == Stat.Hitpoints)
		{
			Get_Stat(Stat,Tier.Formula(Level) * Level * Stat_Multiplier[(int)Stat],true);
			return;
		}

		Get_Stat(Stat,Tier.Formula(Level) * Stat_Multiplier[(int)Stat],true);
	}

	public void Assign_Status (GameObject Equipped_Creature)
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
			i.Assign_Status(Equipped_Creature);
		}
	}

	public void Beginning_Of_Turn (GameObject Equipped_Creature)
	{
		
		if (Status_Less_Than_Zero()) return;
		Assign_Status(Equipped_Creature);
		foreach (var i in Status) 
		{
			i.Beginning_Of_Turn();
		}
	}

	public void Attack_Status (Phase Which_Phase)
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
			i.Attack_Status(Which_Phase);
		}
	}

	public void Counter_Attack_Status (Phase Which_Phase, Creature Advisory, Attack Advisory_Attack)
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
			i.Counter_Attack_Status(Which_Phase, Advisory, Advisory_Attack);
		}
	}

	public void End_Of_Turn ()
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
			i.End_Of_Turn();
		}
	}


	public virtual void Terminate ()
	{
		Terminate_Status ();
		Destroy(this);
	}

	private void Terminate_Status ()
	{
		foreach (var i in Status)
		{
			i.Terminate_Status();
		}
	}
	
	private bool Status_Less_Than_Zero () 
	{
		if (Status.Count > 0) return false;
		return true;
	}
}