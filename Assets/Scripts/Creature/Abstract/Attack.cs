using UnityEngine;
using System.Collections;
using System;
using System_Control;

public class Attack : Raycast
{
	public Weapon_Foundation Primary;
	public Weapon_Foundation Secondary;
	public Equipment_Foundation Helmet;
	public Equipment_Foundation Chest;
	public Equipment_Foundation Legs;
	private Creature Creature;
	
	protected override void Start ()
	{
		base.Start ();
		Creature = GetComponent<Creature>();
		Primary = Creature.Primary_Weapon;
		Secondary = Creature.Secondary_Weapon;
		Helmet = Creature.Helmet;
		Chest = Creature.Chest;
		Legs = Creature.Legs;
	}


	public void Hit_Me_Baby (Weapon_Foundation Primary_Or_Secondary) //Assign Weapon; Look into prefabs.
	{
		Creature Adversary;
//		float Class_Level = Creature.Get_Stat(Primary_Or_Secondary.Class + "_Level");
		float Accuracy = 0f;
//		float Resistance = 0f;
//		float Critical = 0f;
		float Damage = 0f;
		float How_Many_Times = 0f;
		float One_More_Time = 0f;
//AOE
//Distance
//***
//***
//***

		Adversary = Hit.collider.GetComponent<Creature>();
		Hit = Physics2D.Raycast(transform.position, Creature.Front, Creature.x * Creature.Get_Stat(Stat.Distance));
		if (Hit.collider != null)
		{
			while (One_More_Time < How_Many_Times)
			{
				Primary_Or_Secondary.Attack_Status(Phase.Attack_Begin);
				Helmet.Attack_Status(Phase.Attack_Begin);
				Chest.Attack_Status(Phase.Attack_Begin);
				Legs.Attack_Status(Phase.Attack_Begin);
				Adversary.Counter_Attack(Phase.Attack_Begin);

				How_Many_Times = Primary_Or_Secondary.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //*********Calculate: Accuracy**********//
//**************************************//
//				Accuracy += (
//								50f 
//								* 
//								(
//									Tier.Formula(Class_Level) 
//									+ 
//									Creature.Get_Stat(Stat.Primary_Accuracy)
//								)
//								/ 
//								(
//									(Adversary.Get_Stat(Cache.Get_Stat(Primary_Or_Secondary_String + "_Class") + "_Level")) 
//									+ 
//									Cache.Get_Stat(Stat.Evade)
//								)
//							);
	
  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//
	
//				Damage += Tier.Formula(Cache.Get_Stat(Primary_Or_Secondary_String + "_Level")) 
//						  + 
//						  Cache.Get_Stat(Primary_Or_Secondary_String + "_Damage");
	
  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//

//				Critical += (
//								Damage 
//								* 
//								Cache.Get_Stat(Primary_Or_Secondary_String + "_Critical_Damage")
//							);

  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
	
//				Resistance += (
//								Damage
//								*
//								(Cache.Get_Stat(Cache.Get_Stat(Primary_Or_Secondary_String + "_Class") + "_Resistance") / 100)
//							  );

  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
	
//				Damage += -Resistance + Critical;

  //**************************************//
 //**************Dice Roll***************//
//**************************************//	
	
				if (UnityEngine.Random.Range(0f,100f) >= Accuracy)
				{					
					Adversary.Get_Stat(Stat.Hitpoints,-Damage);	
					
//					if (Primary_Or_Secondary == Assign_Hand.Primary)
//					{
////						if (Cache.Primary_Class == Assign_Class.Melee) Cache.Get_Stat(Stat.Energy,15);
////						if (Cache.Primary_Class == Assign_Class.Magic) Cache.Get_Stat(Stat.Energy,20);
////						if (Cache.Primary_Class == Assign_Class.Archery) Cache.Get_Stat(Stat.Energy,5);
//					}
					
//					if (Primary_Or_Secondary == Assign_Hand.Secondary)
//					{
////						if (Cache.Secondary_Class == Assign_Class.Melee) Cache.Get_Stat(Stat.Energy,15);
////						if (Cache.Secondary_Class == Assign_Class.Magic) Cache.Get_Stat(Stat.Energy,20);
////						if (Cache.Secondary_Class == Assign_Class.Archery) Cache.Get_Stat(Stat.Energy,5);
//					}
				}
				else
				{
//					Cache.Miss_Status();
//					Passive (Primary_Or_Secondary, "Miss");
//					Adversary.Enemy_Miss_Status();
				}
				One_More_Time++;
			}
		}
//		Cache.End_Status();
//		Passive (Primary_Or_Secondary, "End");
//		Adversary.Enemy_End_Status();
	}

	

}

//passive active player/enemy
//Modify_Stats_Pre_Hit
//Modify_Stats_Post_Hit



//TO OPTIMIZE THIS CODE::::::
//Make it so you can attach weapons on to attack, called primary and secondary and this will make it so you can have infinity amount of hands. Additionally get rid of Primary and secondary all together. 

//		gameObject.AddComponent(Equipment).hideFlags = HideFlags.HideInInspector;
//		Equipment_Foundation Equipped = gameObject.GetComponent(Equipment) as Equipment_Foundation;
//		if (Equipped.Class != Assign_Class.None && Primary_Or_Secondary != Assign_Hand.None)
//		{
//			Get_Stat(
//				Primary_Or_Secondary.ToString() + "_Damage",
//				//+//
//				Equipped.Get_Stat(Equipped.Class.ToString() + "_Damage")
//			);
//			Get_Stat(
//				Primary_Or_Secondary.ToString() + "_Critical_Chance",
//				//+//
//				Equipped.Get_Stat(Stat.Critical_Chance)
//			);
//			Get_Stat(
//				Primary_Or_Secondary.ToString() + "_Accuracy",
//				//+//
//				Equipped.Get_Stat(Stat.Accuracy)
//			);
//
//			Get_Stat(
//				Primary_Or_Secondary.ToString() + "_Number_Of_Attacks",
//				//+//
//				Equipped.Get_Stat(Stat.Number_Of_Attacks), true
//			);
//
//			if (Primary_Or_Secondary == Assign_Hand.Primary) Primary_Class = Equipped.Class; DELETE
//			if (Primary_Or_Secondary == Assign_Hand.Secondary) Secondary_Class = Equipped.Class; DELETE
//			if (Primary_Or_Secondary == Assign_Hand.Primary) Primary_Subclass = Equipped.Subclass; DELETE 
//			if (Primary_Or_Secondary == Assign_Hand.Secondary) Secondary_Subclass = Equipped.Subclass;	 DELETE
//		} 
//
//		if (Equipped.Subclass == Assign_Subclass.Armor)
//		{
//			if (Secondary_Subclass != Assign_Subclass.One_Handed && Primary_Class != Assign_Class.None)
//			{
//				Get_Stat(Stat.Primary_Damage,
//					//+//
//					Equipped.Get_Stat(Primary_Class.ToString() + "_Damage")
//				);
//			}
//
//			if (Secondary_Subclass == Assign_Subclass.One_Handed)
//			{
//				Get_Stat(Stat.Primary_Damage,
//					//+//
//					Equipped.Get_Stat(Equipped.Class.ToString() + "_Damage" ) * 0.5f
//				);
//				Get_Stat(Stat.Secondary_Damage,
//					//+//
//					Equipped.Get_Stat(Equipped.Class.ToString() + "_Damage" ) * 0.5f
//				);
//			}
//		}