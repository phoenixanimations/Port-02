using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System_Control;
using System_Control.Extensions;

//Figure out Turn = false. Put it in the controller.  

public class Creature_States : Creature_Movement
{
	private void Statuses_Activate(State State, Attack Attack = null)
	{
		if (Passives.Count > 0)
			foreach (var i in Passives)
				i.Activate(this,Raycast,State,Attack);
	}

 	  //************************************//
	 //**********Beginning Of Turn*********//
    //************************************//
	public virtual void Beginning_Of_Turn ()
	{
		Statuses_Activate(State.Beginning_Of_Turn);
	}

	  //************************************//
	 //**************Jumping***************//
    //************************************//
	public virtual void Jumping()
	{
		Statuses_Activate(State.Jump);
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
			Statuses_Activate(State.Move);
		}
	}

	  //************************************//
	 //****************Attack**************//
    //************************************//
	public void Attack (Vector2 Direction, float Length_Times_Amount, float Which_Storey)
	{
		if (Raycast.SearchForCreature(Direction,Length_Times_Amount,Which_Storey))
		{
			Attack Creature_Attacks_Advisory = new Attack(this,Raycast,Raycast.TargetCreature); 

			Statuses_Activate(State.Attack,Creature_Attacks_Advisory);	
			Creature_Attacks_Advisory.Initiate(Slot[(int)Assign_Slot.Primary_Hand]);	
			Creature_Attacks_Advisory.Initiate(Slot[(int)Assign_Slot.Secondary_Hand]);	

			if (Raycast.TargetCreature.Get_Stat(Stat.Hitpoints) < 1)
			{
				Statuses_Activate(State.MurderedCreature);
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
	public void Move_Attack (Vector2 Direction)
	{
		Statuses_Activate(State.MoveAttack);
		ModifyFront(Direction);
		Attack(Direction);
		Move (Direction);
		Turn = false;
	}

	  //************************************//
	 //****************Equip***************//
    //************************************//
	public virtual void Equip (Equipment_Foundation Equipment, Assign_Slot Equip_Slot)
	{	
		Statuses_Activate(State.Equip);
		Slot[Equip_Slot.toInt()].Passives.ForEach(p => Passives.Remove(p));
		Slot[Equip_Slot.toInt()] = Equipment;
		if (Equipment.Passives.Count > 0)
		{
			Equipment.Passives.ForEach(p => Passives.Add(p));
		}
		
		Turn = false;
	}

	  //************************************//
	 //****************Use*****************//
    //************************************//
	public void Use () 
	{
		Statuses_Activate(State.Use);
		Turn = false;
	}

	  //************************************//
	 //**************Interact**************//
    //************************************//
	public void Interact () 
	{
		Statuses_Activate(State.Interact);
	}

	  //************************************//
	 //********Request Interaction*********//
    //************************************//
	public void Request_Interaction ()
	{
		Statuses_Activate(State.Request_Interaction);
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
		Statuses_Activate(State.Idle);
		Turn = false;
	}

	  //************************************//
	 //****************Heal****************//
    //************************************//
	public virtual void Heal (float Amount)
	{
		Statuses_Activate(State.Heal);
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
	public override void Level_Up (Stat Which_Level, float Amount = 1, bool SetLevel = false)
	{
		Statuses_Activate(State.LevelUp);
		if (Which_Level == Stat.Hitpoints_Level || 
			Which_Level == Stat.Melee_Level ||
			Which_Level == Stat.Magic_Level ||
			Which_Level == Stat.Archery_Level)
		{
			Get_Stat(Which_Level, Amount, SetLevel);
		}
	}

	  //************************************//
	 //*************End Of Turn************//
    //************************************//
	public virtual void End_Of_Turn ()
	{
		Statuses_Activate(State.End_Of_Turn);
	}
}