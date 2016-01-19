using UnityEngine;
using System.Collections;
using System;
using System_Control;

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

	public void Equip (Type Equipment, Assign_Hand Primary_Or_Secondary = Assign_Hand.None) 
	{
		gameObject.AddComponent(Equipment).hideFlags = HideFlags.HideInInspector;
		Equipment_Foundation Equipped = gameObject.GetComponent(Equipment) as Equipment_Foundation;
		if (Equipped.Class != Assign_Class.None && Primary_Or_Secondary != Assign_Hand.None)
		{
			Get_Stat(
				Primary_Or_Secondary.ToString() + "_Damage",
				//+//
				Equipped.Get_Stat(Equipped.Class.ToString() + "_Damage")
			);
			Get_Stat(
				Primary_Or_Secondary.ToString() + "_Critical_Chance",
				//+//
				Equipped.Get_Stat(Stat.Critical_Chance)
			);
			Get_Stat(
				Primary_Or_Secondary.ToString() + "_Accuracy",
				//+//
				Equipped.Get_Stat(Stat.Accuracy)
			);

			Get_Stat(
				Primary_Or_Secondary.ToString() + "_Defect_Chance",
				//+//
				Equipped.Get_Stat(Stat.Defect_Chance)
			);

			Get_Stat(
				Primary_Or_Secondary.ToString() + "_Passive_Chance",
				//+//
				Equipped.Get_Stat(Stat.Passive_Chance)
			);
			if (Primary_Or_Secondary == Assign_Hand.Primary) Primary_Class = Equipped.Class;
			if (Primary_Or_Secondary == Assign_Hand.Secondary) Secondary_Class = Equipped.Class;
			if (Primary_Or_Secondary == Assign_Hand.Primary) Primary_Subclass = Equipped.Subclass;
			if (Primary_Or_Secondary == Assign_Hand.Secondary) Secondary_Subclass = Equipped.Subclass;
		} 

		if (Equipped.Subclass == Assign_Subclass.Armor)
		{
			if (Secondary_Subclass != Assign_Subclass.One_Handed && Primary_Class != Assign_Class.None)
			{
				Get_Stat(Stat.Primary_Damage,
					//+//
					Equipped.Get_Stat(Primary_Class.ToString() + "_Damage")
				);
			}
			if (Secondary_Subclass == Assign_Subclass.One_Handed)
			{
				Get_Stat(Stat.Primary_Damage,
					//+//
					Equipped.Get_Stat(Equipped.Class.ToString() + "_Damage")//Divided by what?
				);
				Get_Stat(Stat.Secondary_Damage,
					//+//
					Equipped.Get_Stat(Equipped.Class.ToString() + "_Damage")//Divided by what?
				);
			}
			//Crit chance modifer?

		}

		

	}

	public virtual void Dead () {}

	public virtual void AI () {}
	
	private void Attack () 
	{
		Hit = Physics2D.Raycast(transform.position, Front, x);
 
		if (Hit.collider != null)
			{

//			Get_Stat(Stat.Primary_Accuracy,Tier.Formula())
				//Global Passives vs Attack Passives *
//				Primary_Accuracy = 50 * ((Tier[Player_Class_Level] + Primary_Accuracy + Helmet_Accuracy + Chest_Accuracy + Legs_Accuracy) / (TA[Enemy_(Player_Class)_Level] + Primary_Evade + Secondary_Evade + Helmet_Evade + Chest_Evade + Legs_Evade))
/*			    Secondary_Accuracy = 50 * (Tier[Player_Class_Level] + Secondary_Accuracy + Helmet_Accuracy + Chest_Accuracy + Legs_Accuracy) / (TA[Enemy_(Player_Class)_Level] + Primary_Evade + Secondary_Evade + Helmet_Evade + Chest_Evade + Legs_Evade))
*/		
//			Get_Stat(Stat.Primary_Accuracy) = Tier.Formula(Get_Stat.)

//			Primary Damage = Equipment/2 level/2 
//		Get_Stat(Stat.Critical_Damage,			Equipped.Get_Stat(Stat.Critical_Damage));

			}
	}
}
