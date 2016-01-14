using UnityEngine;
using System.Collections;
using System;

public class CreatureMethods : CreatureFoundation
{
	public event Delegate AddStatus = delegate {};
	public event Delegate AddCleanUpStatus = delegate {};
	public event Delegate AddUse = delegate {};

	public override void Move (Vector3 Direction)
	{
		AllowMovement(true);
		Hit = Physics2D.Raycast(transform.position,Direction,x);
		if (Hit.collider != null) AllowMovement(false);
		base.Move (Direction);
	}
	
	public void Status ()
	{
		AddStatus();
	}

	public void CleanUpStatus ()
	{
		AddCleanUpStatus();
	}

	public virtual void Use () 
	{
		State = "Use";
		if (EnableState)
		{
			AddUse();
		}
	}
	
	public void MoveAttack (Vector3 Direction) //change to attackmove
	{
		State = "MoveAttack";
		ModifyFront(Direction);
		if (EnableState)
		{
			Attack();
			Move (Direction);
		}
	}

	public virtual void VehicleRequest ()
	{
		State = "VehicleRequest";
		if (EnableState)
		{
			Hit = Physics2D.Raycast(transform.position,Front,x);
			if (Hit.collider != null && Hit.collider.gameObject.GetComponent<Creature>().CreatureType == "Vehicle")
				Hit.collider.SendMessage("VehicleMessage", gameObject); //Possibly Cache.
		}
	}

	public void Idle ()
	{
		State = "Idle";
	}

	public void ModifyState (bool TrueFalse)
	{
		EnableState = TrueFalse;
	}

	public void Equip (Type Equipment) 
	{
		gameObject.AddComponent(Equipment);
	}

	public virtual void Dead () {}

	public virtual void AI () {}
	
	private void Attack () 
	{
		Hit = Physics2D.Raycast(transform.position, Front, x);
		if (Hit.collider != null)
			{
				//Global Passives vs Attack Passives 
				
				
//Change this!!!!!!
//				Hit.collider.GetComponent<Creature>().RemoveHealth(Damage);
			}
	}
}