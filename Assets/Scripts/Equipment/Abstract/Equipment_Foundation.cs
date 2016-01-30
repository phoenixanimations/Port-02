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

	public void Assign_Status (Creature Equipped_Creature)
	{
		if (Status_Less_Than_Zero()) return;
		foreach (var i in Status) 
		{
			i.Assign_Status(Equipped_Creature);
		}
	}

	public void Beginning_Of_Turn (Creature Equipped_Creature)
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