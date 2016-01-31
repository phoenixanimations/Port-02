﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Attack : Raycast
{
	public Equipment_Foundation Primary;
	public Equipment_Foundation Secondary;
	public Equipment_Foundation Helmet;
	public Equipment_Foundation Chest;
	public Equipment_Foundation Legs;

	private Creature Adversary;
	private Creature Creature;

	private float  How_Many_Times = 0f;
	private float  One_More_Time = 0f;

	private string Class;
	private float  Class_Level = 0f;
	private float  Accuracy = 0f;
	private float  Resistance = 0f;
	private float  Critical = 0f;
	private float  Damage = 0f;

	private bool Dual_Wield_Equipped ()
	{
		if (Secondary.Subclass == Assign_Subclass.One_Handed || Secondary.Subclass == Assign_Subclass.Two_Handed) return true;
		return false;
	}

	private void Start_Hitting_Me_Baby ()
	{	
		Primary = Creature.Primary_Weapon;
		Secondary = Creature.Secondary_Weapon;
		Helmet = Creature.Helmet;
		Chest = Creature.Chest;
		Legs = Creature.Legs;
	}
	
	private void Passives (Equipment_Foundation Primary_Or_Secondary, Creature Adversary, Phase Attack_Phase)
	{
		Primary_Or_Secondary.Attack_Status(Attack_Phase);
		Helmet.Attack_Status(Attack_Phase);
		Chest.Attack_Status(Attack_Phase);
		Legs.Attack_Status(Attack_Phase);
		Adversary.Counter_Attack(Attack_Phase);
	}

	protected override void Start ()
	{
		base.Start ();
		Creature = gameObject.GetComponent<Creature>();
	}

//	public void Get_Calculations (Equipment_Foundation Primary_Or_Secondary)
//	{
//		Dictionary<string,float> Attack_Stats = new Dictionary<string, float>()
//		{
//			{"Primary",Damage}	
//		};
//	
//	}

	public void Hit_Me_Baby (Equipment_Foundation Primary_Or_Secondary)  //Get rid of checking for null
	{
		Start_Hitting_Me_Baby ();
  //**************************************//
 //***************Check Null*************//
//**************************************//
		if (Helmet == null || Chest == null || Legs == null) { Debug.LogError("You can go in to battle Nude but you have to EQUIP Nude Armor. Why would a character equip the concept of nothing?"); return;} 
		if (Primary_Or_Secondary == null) return;

  //**************************************//
 //********Calculate: Attack Count*******//
//**************************************//		
		How_Many_Times = Primary_Or_Secondary.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //********Calculate: Distance***********//
//**************************************//	
		Hit = Physics2D.Raycast(transform.position, Creature.Front, Creature.x * Creature.Get_Stat(Stat.Distance));
		if (Hit.collider != null)
		{
			Adversary = Hit.collider.GetComponent<Creature>();


			while (One_More_Time < How_Many_Times)
			{
  //**************************************//
 //**********Passive Attack Begin********//
//**************************************//
				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Begin);
 
  //**************************************//
 //******Calculate: Number of Attacks****//
//**************************************//
				How_Many_Times = Primary_Or_Secondary.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //*******Calculate: Class Level*********//
//**************************************//
				Class = Primary_Or_Secondary.Class.ToString();
				Class_Level = Creature.Get_Stat(Class + "_Level");

  //**************************************//
 //*********Calculate: Accuracy**********//
//**************************************//
				float Weapon_Accuracy = Primary_Or_Secondary.Get_Stat(Stat.Accuracy);
				float Armor_Accuracy = Helmet.Get_Stat(Stat.Accuracy) + Chest.Get_Stat(Stat.Accuracy) + Legs.Get_Stat(Stat.Accuracy);
				float Creature_Accuracy = Tier.Formula(Class_Level) + Weapon_Accuracy + Armor_Accuracy;	
			
				float Adversary_Class_Accuracy = Tier.Formula(Adversary.Get_Stat(Primary_Or_Secondary.Class.ToString() + "_Level"));
				float Adversary_Weapon_Accuracy = Adversary.Primary_Weapon.Get_Stat(Stat.Evade) + Adversary.Secondary_Weapon.Get_Stat(Stat.Evade);
				float Adversary_Armor_Accuracy =  Adversary.Helmet.Get_Stat(Stat.Accuracy) + Adversary.Chest.Get_Stat(Stat.Accuracy) + Adversary.Legs.Get_Stat(Stat.Accuracy);
				float Adversary_Accuracy = Adversary_Class_Accuracy + Adversary_Weapon_Accuracy + Adversary_Armor_Accuracy;			

				Accuracy += 50f * (Creature_Accuracy/Adversary_Accuracy);

  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//
				string Class_Damage = Class + "_Damage";
				float Equipped_Weapon_Damage = Primary_Or_Secondary.Get_Stat(Class_Damage);
				float Equipped_Class_Damage = Tier.Formula(Class_Level);
				float Equipped_Armor_Damage = Helmet.Get_Stat(Class_Damage) + Chest.Get_Stat(Class_Damage) + Legs.Get_Stat(Class_Damage);
				float Equipped_Class_Plus_Equipped_Armor_Damage = Equipped_Class_Damage + Equipped_Armor_Damage;
			
				if (Dual_Wield_Equipped ())
				{
					Damage += Equipped_Weapon_Damage + (Equipped_Class_Plus_Equipped_Armor_Damage * 0.5f);
				}
				if (!Dual_Wield_Equipped ()) 
				{
					Damage += Equipped_Weapon_Damage + Equipped_Class_Plus_Equipped_Armor_Damage;
				}

  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//
				float Critical_Percent = Creature.Get_Stat(Stat.Critical_Damage) / 100;
				Critical += Damage * Critical_Percent;

  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
				float Resistance_Percent = Creature.Get_Stat(Class + "_Resistance") / 100;
				Resistance += Damage * Resistance_Percent;

  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
				Damage += -Resistance + Critical;

  //**************************************//
 //**************Dice Roll***************//
//**************************************//	
				if (Accuracy >= UnityEngine.Random.Range(0f,100f))
				{	

  //**************************************//
 //**********Passive Attack Hit**********//
//**************************************//
					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Hit);

  //**************************************//
 //******Calculate: Adversary - Damage***//
//**************************************//
					Adversary.Get_Stat(Stat.Hitpoints,-Damage);	

  //**************************************//
 //***********Calculate: Energy**********//
//**************************************//
					if (Primary_Or_Secondary.Class == Assign_Class.Melee) Creature.Get_Stat(Stat.Energy,15f);
					if (Primary_Or_Secondary.Class == Assign_Class.Magic) Creature.Get_Stat(Stat.Energy,25f);
					if (Primary_Or_Secondary.Class == Assign_Class.Archery) Creature.Get_Stat(Stat.Energy,5f);
				}
				else
				{
  //**************************************//
 //**********Passive Attack Miss*********//
//**************************************//
					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Miss);				
				}
  //**************************************//
 //**********Passive Attack End**********//
//**************************************//
				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_End);
				One_More_Time++;
			}
		}
		One_More_Time = 0;
	}
}