using UnityEngine;
using System.Collections;
using System;
using System_Control;

public class CreatureMethods : CreatureFoundation
{
	public event Delegate Beginning_Of_Turn = delegate {};
		
	public event Delegate End_Of_Turn = delegate {};



	public event Delegate AddUse = delegate {};

	public override void Move (Vector3 Direction)
	{
		AllowMovement(true);
		Hit = Physics2D.Raycast(transform.position,Direction,x);
		if (Hit.collider != null) AllowMovement(false);
		base.Move (Direction);
	}
	
	public void Status () 			   { Beginning_Of_Turn(); }
	public void CleanUpStatus ()	   { End_Of_Turn(); }



//	public void Begin_Status () 	   { Attack_Begin(); }
//	public void Miss_Status ()  	   { Attack_Miss(); }
//	public void End_Status ()   	   { Attack_End(); }
//
//	public void Enemy_Begin_Status ()  { Enemy_Attack_Begin(); }
//    public void Enemy_Miss_Status ()   { Enemy_Attack_Miss(); }
//    public void Enemy_End_Status ()    { Enemy_Attack_End(); }
	
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

	public void Equip () 
	{
		
	}

	public void Unequip ()
	{
		
	}

	public virtual void Dead () {}

	public virtual void AI () {}
	
	private void Attack () //Make one attack that accepts Primary or Secondary. Make attack getcomponent?
	{

	}
	
}

//Activates minus the energy ***REDUCE energy cost*** activates check to make sure you have enough to minus. otherwise ignore.
//
//		Get_Stat(Stat.Critical_Damage,			Equipped.Get_Stat(Stat.Critical_Damage));


//Status
//Cleanup Status

//Inate 

//pre roll Stats

//Res calc

//crit calc

// hitpoinys