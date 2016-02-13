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
	
	public void Clean_Up_Status ()	   
	{
		if (Primary_Weapon != null)   Primary_Weapon.End_Of_Turn();
		if (Secondary_Weapon != null) Secondary_Weapon.End_Of_Turn();
		if (Armor != null)			  Armor.End_Of_Turn();
				if (Defects.Count > 0)
			foreach (var i in Defects) { i.End_Of_Turn(); }
	}
	
	public void Attack_Status (Phase Which_Phase)
	{
		if (Defects.Count > 0) return;
		foreach (var i in Defects) 
		{
			i.Attack_Status(Which_Phase);
		}
	}

	
	public virtual void Use () 
	{
		State = "Use";
		Attack ();
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
	
	public void Attack ()
	{
		State = "Attack";
		Attack_Cache.Hit_Me_Baby(Primary_Weapon);
		Attack_Cache.Hit_Me_Baby(Secondary_Weapon);
	}	

	public float Max_Hitpoints ()
	{
		float Level_Hitpoints = 50f * Tier.Formula(Get_Stat(Stat.Hitpoints_Level));
		float Primary_Secondary_Hitpoints = Primary_Weapon.Get_Stat(Stat.Hitpoints) + 
								 			Secondary_Weapon.Get_Stat(Stat.Hitpoints);
		float Helmet_Chest_Legs_Hitpoints = Armor.Get_Stat(Stat.Hitpoints);
		float Max_Hitpoints = Level_Hitpoints + Primary_Secondary_Hitpoints + Helmet_Chest_Legs_Hitpoints;
		return Max_Hitpoints;
	}

	public void Heal (float Amount)
	{
		if ((Get_Stat(Stat.Hitpoints) + Amount) < Max_Hitpoints())
		{
			Get_Stat(Stat.Hitpoints,Amount);
		}
		else
		{
			Get_Stat(Stat.Hitpoints,Max_Hitpoints(),true);
		}	
	}

	public void Counter_Attack(Phase During_Which_Phase, Creature Advisory, Attack Advisory_Attack)
	{	
		if (Primary_Weapon != null)   Primary_Weapon.Counter_Attack_Status(During_Which_Phase,Advisory,Advisory_Attack);
		if (Secondary_Weapon != null) Secondary_Weapon.Counter_Attack_Status(During_Which_Phase,Advisory,Advisory_Attack);
		if (Armor != null)			  Armor.Counter_Attack_Status(During_Which_Phase,Advisory,Advisory_Attack);
	}
}