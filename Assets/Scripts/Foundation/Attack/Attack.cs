﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System.Linq;
using System_Control.Extensions;
////For Actives:
////Value = (100 + 5 * ((ScaleValue * 0.1 * Energy) + (0.5 * Mathf.Pow((0.1 * Energy),2) - 0.5 * (0.1 * Energy))));
	//The aoe will happen in the attack and re attack but with reduced damage.
public class Attack
{
	private Creature_States Creature;
	private Raycast Creature_Raycast;
	public Creature_States Advisory {private set;get;}

	public Attack (Creature_States Assign_Creature, Raycast Assign_Creature_Raycast, Creature_States Assign_Advisory)
	{
		Creature = Assign_Creature;
		Creature_Raycast = Assign_Creature_Raycast;
		Advisory = Assign_Advisory;
	}
  //**************************************//
 //***********Global Modify*************//
//*************************************//
	public float  Number_Of_Attacks {get;set;}
	public float  Attack_Count {get;private set;}
  //**************************************//
 //***************Modify*****************//
//**************************************//
	public List<float> Damage_Bonus = new List<float>(){1};
	public List<float> Accuracy_Bonus = new List<float>(){1};
	public List<float> Resistance_Bonus = new List<float>(){0};
	public List<float> Area_Of_Effect_Bonus = new List<float>(){0};
	public List<float> Critical_Chance_Bonus = new List<float>(){0};
	public List<float> Critical_Damage_Bonus = new List<float>(){0};
	public List<float> Energy_Bonus = new List<float>(){0};
	
  //**************************************//
 //*************Never Modify*************//
//**************************************//
	public Assign_Class Class {private set; get;}
	public Stat Class_Level {private set; get;}
	public Stat Class_Damage {private set; get;}
	public Stat Class_Resistance {private set; get;}
	public float  Base_Damage {private set; get;}
	public float  Damage {private set; get;}
	public float  Critical_Damage {private set; get;}
	public float  Critical_Chance {private set; get;}
	public float  Accuracy {private set; get;}
	public float  Resistance {private set; get;}
	public float  Energy {private set; get;}

	private bool Is_Level_Damage_Resistance_Statable (Assign_Class Class)
	{
		switch (Class)
		{
			case Assign_Class.Melee:
			Class_Level = Stat.Melee_Level;
			Class_Damage = Stat.Melee_Damage;
			Class_Resistance = Stat.Melee_Resistance;
			break;

			case Assign_Class.Magic:
			Class_Level = Stat.Magic_Level;
			Class_Damage = Stat.Magic_Damage;
			Class_Resistance = Stat.Magic_Resistance;
			break;

			case Assign_Class.Archery:
			Class_Level = Stat.Archery_Level;
			Class_Damage = Stat.Archery_Damage;
			Class_Resistance = Stat.Archery_Resistance;
			break;
			
			case Assign_Class.xForm:
			Debug.LogError("xForm not yet supported");
			break;

			default:
				return false;
			break;
		}
		return true; 
	}
	
	private bool Dual_Wield_Equipped ()
	{
		Assign_Class Primary_Hand = Creature.Slot[(int)Assign_Slot.Primary_Hand].Class;
		Assign_Class Secondary_Hand = Creature.Slot[(int)Assign_Slot.Secondary_Hand].Class;
		return (Is_Level_Damage_Resistance_Statable(Primary_Hand) && Is_Level_Damage_Resistance_Statable(Secondary_Hand));
	}

  //**************************************//
 //**************Set Stats***************//
//**************************************//
	private void Reset_Stats ()
	{
  //**************************************//
 //******Modified Stats Reset************//
//**************************************//
		Damage_Bonus.One();
		Accuracy_Bonus.One();
		Resistance_Bonus.Zero();
		Area_Of_Effect_Bonus.Zero();
		Critical_Chance_Bonus.Zero();
		Critical_Damage_Bonus.Zero();
		Energy_Bonus.Zero();

  //**************************************//
 //*****Never Modify Stats Reset*********//
//**************************************//
		Attack_Count = 0f;
		Number_Of_Attacks = 0f;
		Accuracy = 0f;
		Resistance = 0f;
		Critical_Damage = 0f;
		Base_Damage = 0f;
		Damage = 0f;
	}

  //**************************************//
 //****************Passives**************//
//**************************************//
	private void Passives (Creature_States Creature, State Assign_State)
	{
		Creature.Passives.ForEach(p => p.Activate(Creature,Creature_Raycast,Assign_State,this));
	}

  //**************************************//
 //*************Start Attack*************//
//**************************************//
	public void Initiate (Equipment_Foundation Weapon)
	{	
  //**************************************//
 //*********Check For Non Weapons********//
//**************************************//
		if (Is_Level_Damage_Resistance_Statable(Weapon.Class) == false)
		{
			Debug.Log(Weapon.Name + " was not run threw the attack code");
			return;
		}
  //**************************************//
 //********Calculate: Attack Count*******//
//**************************************//		
		Number_Of_Attacks = Weapon.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //***********Start Attack Loop**********//
//**************************************//	
			while (Attack_Count < Number_Of_Attacks)
			{
				Reset_Stats();
  //**************************************//
 //*******Passive Attack Begin 1/4*******//
//**************************************//
				Passives (Creature, State.Attack_Begin);
				Passives (Advisory, State.Attack_Begin);

  //**************************************//
 //******Calculate: Number of Attacks****//
//**************************************//
				Number_Of_Attacks = Weapon.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //*********Calculate: Accuracy**********//
//**************************************//
				//Enforce a primary or secondary system or have some way where shields commincate to the weapon or something??????? Maybe shields have a passive that's run or something?????
				float Class_Accuracy = Tier.Formula(Creature.Get_Stat(Class_Level));
				float Weapon_Accuracy = Weapon.Get_Stat(Stat.Accuracy);
				float Armor_Accuracy = Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Accuracy);
				float Creature_Accuracy = Class_Accuracy + Weapon_Accuracy + Armor_Accuracy;	
				
				float Advisory_Primary_Evade = Advisory.Slot[(int)Assign_Slot.Primary_Hand].Get_Stat(Stat.Evade); 
				float Advisory_Secondary_Evade = Advisory.Slot[(int)Assign_Slot.Secondary_Hand].Get_Stat(Stat.Evade); 
				float Advisory_Weapon_Evade = Advisory_Primary_Evade + Advisory_Secondary_Evade;
				float Advisory_Armor_Evade =  Advisory.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Evade);
				float Advisory_Class_Level_Evade = Tier.Formula(Advisory.Get_Stat(Class_Level));
				float Advisory_Evade = Advisory_Weapon_Evade + Advisory_Armor_Evade + Advisory_Class_Level_Evade;			

				Accuracy += 50f * (Creature_Accuracy/Advisory_Evade) * Accuracy_Bonus.Multiple(); 
  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//
				if (Dual_Wield_Equipped ())
				{
					float Armor_Damage = Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Class_Damage);
					float Class_Level_Damage = Tier.Formula(Creature.Get_Stat(Class_Level));
					float All_Damage = Weapon.Get_Stat(Class_Damage) + (Armor_Damage * .5f) + (Class_Level_Damage * .5f);
					Base_Damage = (All_Damage * Damage_Bonus.Multiple()) / Number_Of_Attacks;
				}
				else 
				{
					float Armor_Damage = Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Class_Damage);
					float Class_Level_Damage = Tier.Formula(Creature.Get_Stat(Class_Level));
					float All_Damage = Weapon.Get_Stat(Class_Damage) + (Armor_Damage) + (Class_Level_Damage);
					Base_Damage = (All_Damage * Damage_Bonus.Multiple()) / Number_Of_Attacks;
				}
//
  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//
				float  Critical_Damage_Percent = 0f;
				Critical_Chance = Weapon.Get_Stat(Stat.Critical_Chance) + Critical_Chance_Bonus.Sum();
				if (Critical_Chance >= UnityEngine.Random.Range(0f,100f)) 
				{
					Critical_Damage_Percent = (Weapon.Get_Stat(Stat.Critical_Damage) + Critical_Damage_Bonus.Sum()) / 100;
				}

				Critical_Damage = Base_Damage * Critical_Damage_Percent;
  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
				float Resistance_Percent = (Creature.Get_Stat(Class_Resistance) + Resistance_Bonus.Sum()) / 100;
				Resistance = Base_Damage * Resistance_Percent;

  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
				Damage = Critical_Damage + Base_Damage - Resistance; //Damage bonus multiplied

  //**************************************//
 //**************Dice Roll***************//
//**************************************//	
				if (Accuracy >= UnityEngine.Random.Range(0f,100f))
				{	
  //**************************************//
 //*******Passive Attack Hit 2/4*********//
//**************************************//
					Passives (Creature, State.Attack_Roll);
					Passives (Advisory, State.Counter_Attack_Roll);

  //**************************************//
 //******Calculate: Adversary - Damage***//
//**************************************//
					Damage = Mathf.Floor(Damage);
					Advisory.Get_Stat(Stat.Hitpoints,-Damage);	

  //**************************************//
 //***********Calculate: Energy**********//	 //ENERGY LATER 
//**************************************//
//					if (Primary_Or_Secondary.Class == Assign_Class.Melee) Creature.Get_Stat(Stat.Energy,15f);
//					if (Primary_Or_Secondary.Class == Assign_Class.Magic) Creature.Get_Stat(Stat.Energy,25f);
//					if (Primary_Or_Secondary.Class == Assign_Class.Archery) Creature.Get_Stat(Stat.Energy,5f);
//					
//					if (Creature.Get_Stat(Stat.Energy) > 100) 
//						Creature.Get_Stat(Stat.Energy, 100, true); 
//					if (Creature.Get_Stat(Stat.Energy) < 0) 
//						Creature.Get_Stat(Stat.Energy, 0, true); 
//
				}
				else
				{
  //**************************************//
 //********Passive Attack Miss 3/4*******//
//**************************************//
					Passives (Creature, State.Attack_Miss);
					Passives (Advisory, State.Counter_Attack_Miss);
					Debug.Log("You missed!");			
				}
  //**************************************//
 //********Passive Attack End 4/4********//
//**************************************//
				Passives (Creature, State.Attack_End);
				Passives (Advisory, State.Counter_Attack_End);
				Attack_Count++;
			}
  //**************************************//
 //**************End Loop****************//
//**************************************//
		}
  //**************************************//
 //*************End Attack***************//
//**************************************//
}