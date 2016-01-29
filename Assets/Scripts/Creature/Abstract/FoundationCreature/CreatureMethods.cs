using UnityEngine;
using System.Collections;
using System;
using System_Control;

public class CreatureMethods : CreatureFoundation
{
	public override void Move (Vector3 Direction)
	{
		AllowMovement(true);
		Hit = Physics2D.Raycast(transform.position,Direction,x);
		if (Hit.collider != null) AllowMovement(false);
		base.Move (Direction);
	}
	
	protected override void Start ()
	{
		base.Start ();
		
	}

	public void Status () 			   
	{
		if (Primary_Weapon != null)   Primary_Weapon.Beginning_Of_Turn();
		if (Secondary_Weapon != null) Secondary_Weapon.Beginning_Of_Turn();
		if (Helmet != null)			  Helmet.Beginning_Of_Turn();
		if (Chest != null) 			  Chest.Beginning_Of_Turn();
		if (Legs != null) 	  		  Legs.Beginning_Of_Turn();
	}	
	
	public void Clean_Up_Status ()	   
	{
		if (Primary_Weapon != null)   Primary_Weapon.End_Of_Turn();
		if (Secondary_Weapon != null) Secondary_Weapon.End_Of_Turn();
		if (Helmet != null)			  Helmet.End_Of_Turn();
		if (Chest != null) 			  Chest.End_Of_Turn();
		if (Legs != null) 	  		  Legs.End_Of_Turn();
	}
	
	public virtual void Use () 
	{
		State = "Use";
//		if (EnableState)
//		{
//			AddUse();
//		}
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

	public void Equip () 
	{
		
	}

	public void Unequip ()
	{
		
	}

	public virtual void Dead () {}

	public virtual void AI () {}
	
	private void Attack ()
	{

	}	
}