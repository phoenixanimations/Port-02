using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System_Control;

public class Creature_States : Creature_Movement
{
	private void StatusesActivate(State State)
	{
		if (Passives.Count > 0)
			foreach (var i in Passives) 
				i.Activate(this,Raycast,State);
	}

 	  //************************************//
	 //**********Beginning Of Turn*********//
    //************************************//
	public virtual void BeginningOfTurn ()
	{
		StatusesActivate(State.BeginningOfTurn);
	}

	  //************************************//
	 //**************Jumping***************//
    //************************************//
	public virtual void Jumping()
	{
		StatusesActivate(State.Jump);
		Turn = false;
	}

	  //************************************//
	 //***************Move*****************//
    //************************************//
	public override void Move (Vector2 Direction)
	{
		base.Move (Direction);
		if (AllowMove)
		{
			StatusesActivate(State.Move);
		}
	}

	  //************************************//
	 //****************Attack**************//
    //************************************//
	public void Attack (Vector2 Direction, float LengthTimesAmount, float WhichStorey)
	{
		StatusesActivate(State.Attack);
		if (Raycast.SearchForCreature(Direction,LengthTimesAmount,WhichStorey))
		{
			if (Raycast.TargetCreature.Get_Stat(Stat.Hitpoints) < 1)
			{
				StatusesActivate(State.MurderedCreature);
			}
		}
	}

	public void Attack (Vector2 Direction, float LengthTimesAmount)
	{
		Attack(Direction,LengthTimesAmount,Storey);
	}

	public void Attack (Vector2 Direction)
	{
		Attack(Direction,1f,Storey);
	}

	  //************************************//
	 //*************Move Attack************//
    //************************************//
	public void MoveAttack (Vector2 Direction)
	{
		StatusesActivate(State.MoveAttack);
		ModifyFront(Direction);
		Attack(Direction);
		Move (Direction);
		Turn = false;
	}

	  //************************************//
	 //****************Equip***************//
    //************************************//
	public virtual void Equip (Equipment_Foundation Equipment)
	{	
		switch (Equipment.Slot) 
		{
		case Assign_Slot.Primary_Hand:
			PrimaryHand.Passives.ForEach(p => Passives.Remove(p));
			PrimaryHand = Equipment;
			break;
		
		case Assign_Slot.Secondary_Hand:
			SecondaryHand.Passives.ForEach(p => Passives.Remove(p));
			SecondaryHand = Equipment;
			break;
		
		case Assign_Slot.Armor:
			Armor.Passives.ForEach(p => Passives.Remove(p));
			Armor = Equipment;
			break;
		
		case Assign_Slot.Arrow:
			Arrow.Passives.ForEach(p => Passives.Remove(p));
			Arrow = Equipment;
			break;

		default:
			Debug.LogError("No slots meet, bad weapon");
			break;
		}
			
		if (Equipment.Passives.Count > 0)
		{
			Equipment.Passives.ForEach(s => Passives.Add(s));
		}
		Turn = false;
	}

	  //************************************//
	 //****************Use*****************//
    //************************************//
	public void Use () 
	{
		StatusesActivate(State.Use);
		Turn = false;
	}

	  //************************************//
	 //**************Interact**************//
    //************************************//
	public void Interact () 
	{
		StatusesActivate(State.Interact);
	}

	  //************************************//
	 //********Request Interaction*********//
    //************************************//
	public void RequestInteraction ()
	{
		StatusesActivate(State.RequestInteraction);
		if (Raycast.SearchForCreature(Front,Storey))
		{
			Raycast.TargetCreature.Interact();
		}
		
		Turn = false;
	}

	  //************************************//
	 //*****************Idle***************//
    //************************************//
	public void Idle ()
	{
		StatusesActivate(State.Idle);
		Turn = false;
	}

	  //************************************//
	 //****************Heal****************//
    //************************************//
	public virtual void Heal (float Amount)
	{
		StatusesActivate(State.Heal);
		if ((Get_Stat(Stat.Hitpoints) + Amount * Heal_Bonus.Sum()) < Max_Hitpoints())
		{
			Get_Stat(Stat.Hitpoints,Amount);
		}
		else
		{
			Get_Stat(Stat.Hitpoints,Max_Hitpoints(),true);
		}
	}

	  //************************************//
	 //*************Level Up***************//
    //************************************//
	public override void Level_Up (Stat WhichLevel, float Amount = 1, bool SetLevel = false)
	{
		StatusesActivate(State.LevelUp);
		if (WhichLevel == Stat.Hitpoints_Level || 
			WhichLevel == Stat.Melee_Level ||
			WhichLevel == Stat.Magic_Level ||
			WhichLevel == Stat.Archery_Level)
		{
			Get_Stat(WhichLevel, Amount, SetLevel);
		}
	}

	  //************************************//
	 //*************End Of Turn************//
    //************************************//
	public virtual void EndOfTurn ()
	{
		StatusesActivate(State.EndOfTurn);
	}
}