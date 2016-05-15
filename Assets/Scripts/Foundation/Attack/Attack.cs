using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System.Linq;
using System_Control.Extensions;

//Make it so you can jump on top of enemies and Nuwas has an active that if you jump on top she will take you and curb stomp you to the ground. 

//	Defects //Figure out whether or not you want to change the value of defects to a drag and drop or have an if statement in the code... that looks at each defect. DEFECTS effects WILL NEVER CHANGE BY ANYONE 
//For defects make them seperate components and then have the weapon_editor read the enum of defects if one exists add it and then attach it to the passive that adds a defect on attack. 
//In the attack code read the weapons defect and then add component.

//	AOE (For Actives: The aoe will happen in the attack and re attack but with reduced damage.)


//GO OVER AMMO AND BOLTS
//Make sure arrows take your weapon stat as the tier multiplier. In the attack code accuracy and damage is added.
//Accuracy make it a multiplier



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
	public float Number_Of_Attacks {get;set;}
	public float Attack_Count {get;private set;}
	public bool Dont_Negate_Energy {get;set;}

  //**************************************//
 //***************Modify*****************//
//**************************************//
	public List<float> Damage_Bonus_Multiplier = new List<float>(){1};   	 //No Additive support, is on purpose. This is not allowed because if you do have additive support it makes duel wielding confusing.
	public List<float> Accuracy_Bonus_Multiplier = new List<float>(){1}; 	//No Additive support, is on purpose. This is not allowed because if you do have additive support it makes duel wielding confusing.
	public List<float> Resistance_Bonus_Multiplier = new List<float>(){1};
	public List<float> Critical_Chance_Bonus_Multiplier = new List<float>(){1};
	public List<float> Critical_Damage_Bonus_Multiplier = new List<float>(){1};
	public List<float> Energy_Bonus_Multiplier = new List<float>(){1};

	public List<float> Resistance_Bonus_Additive = new List<float>(){0};
	public List<float> Area_Of_Effect_Bonus_Additive = new List<float>(){0};
	public List<float> Critical_Chance_Bonus_Additive = new List<float>(){0};
	public List<float> Critical_Damage_Bonus_Additive = new List<float>(){0};
	public List<float> Energy_Bonus_Additive = new List<float>(){0};

  //**************************************//
 //*************Never Modify*************//
//**************************************//
	public Assign_Class Class {private set; get;}
	public Stat Class_Level {private set; get;}
	public Stat Class_Damage {private set; get;}
	public Stat Class_Resistance {private set; get;}

	public float Shield_Damage {private set; get;}
	public float Shield_Accuracy {private set; get;}
	public float Shield_Critical_Chance {private set; get;}
	public float Shield_Critical_Damage {private set; get;}

	public float  Base_Damage {private set; get;}
	public float  Damage {private set; get;}
	public float  Critical_Damage {private set; get;}
	public float  Critical_Chance {private set; get;}
	public float  Accuracy {private set; get;}
	public float  Resistance {private set; get;}
	public float  Energy {private set; get;}

	private void Shield_Bonus (Stat Assign_Class_Damage, Stat Class_Resistance)
	{
		if (Creature.Slot[Assign_Slot.Secondary_Hand.toInt()].Class == Assign_Class.Shield)
		{
			Shield_Damage = Creature.Slot[Assign_Slot.Primary_Hand.toInt()].Get_Stat(Assign_Class_Damage);
			Shield_Accuracy = Creature.Slot[Assign_Slot.Primary_Hand.toInt()].Get_Stat(Stat.Accuracy);
			Shield_Critical_Chance = Creature.Slot[Assign_Slot.Primary_Hand.toInt()].Get_Stat(Stat.Critical_Chance);
			Shield_Critical_Chance = Creature.Slot[Assign_Slot.Primary_Hand.toInt()].Get_Stat(Stat.Critical_Damage);
		}
	}

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
		}
		return true; 
	}
	
	private bool Dual_Wield_Equipped ()
	{
		Assign_Class Primary_Hand = Creature.Slot[Assign_Slot.Primary_Hand.toInt()].Class;
		Assign_Class Secondary_Hand = Creature.Slot[Assign_Slot.Secondary_Hand.toInt()].Class;
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
		Dont_Negate_Energy = true;	

		Damage_Bonus_Multiplier.One();
		Accuracy_Bonus_Multiplier.One();
		Resistance_Bonus_Multiplier.One();
		Critical_Chance_Bonus_Multiplier.One();
		Critical_Damage_Bonus_Multiplier.One();
		Energy_Bonus_Multiplier.One();

		Area_Of_Effect_Bonus_Additive.Zero();
		Resistance_Bonus_Additive.Zero();
		Critical_Chance_Bonus_Additive.Zero();
		Critical_Damage_Bonus_Additive.Zero();
		Energy_Bonus_Additive.Zero();

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
  //****************************************//
 //*Calculate: Attack Count & Shield Bonus*//
//****************************************//		
		Number_Of_Attacks = Weapon.Get_Stat(Stat.Number_Of_Attacks);
		Shield_Bonus(Class_Damage,Class_Resistance);
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
				float Armor_Accuracy = Creature.Slot[Assign_Slot.Armor.toInt()].Get_Stat(Stat.Accuracy);
				float Creature_Accuracy = Class_Accuracy + Weapon_Accuracy + Armor_Accuracy + Shield_Accuracy;
				
				float Advisory_Primary_Evade = Advisory.Slot[Assign_Slot.Primary_Hand.toInt()].Get_Stat(Stat.Evade); 
				float Advisory_Secondary_Evade = Advisory.Slot[Assign_Slot.Secondary_Hand.toInt()].Get_Stat(Stat.Evade); 
				float Advisory_Weapon_Evade = Advisory_Primary_Evade + Advisory_Secondary_Evade;
				float Advisory_Armor_Evade =  Advisory.Slot[Assign_Slot.Armor.toInt()].Get_Stat(Stat.Evade);
				float Advisory_Class_Level_Evade = Tier.Formula(Advisory.Get_Stat(Class_Level));
				float Advisory_Evade = Advisory_Weapon_Evade + Advisory_Armor_Evade + Advisory_Class_Level_Evade;			

				Accuracy = 50f * (Creature_Accuracy/Advisory_Evade) * Accuracy_Bonus_Multiplier.Multiple(); 
  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//
				if (Dual_Wield_Equipped ())
				{
					float Armor_Damage = Creature.Slot[Assign_Slot.Armor.toInt()].Get_Stat(Class_Damage);
					float Class_Level_Damage = Tier.Formula(Creature.Get_Stat(Class_Level));
					float All_Damage = Weapon.Get_Stat(Class_Damage) + (Armor_Damage * .5f) + (Class_Level_Damage * .5f);
					Base_Damage = (All_Damage * Damage_Bonus_Multiplier.Multiple()) / Number_Of_Attacks;
				}
				else 
				{
					float Armor_Damage = Creature.Slot[Assign_Slot.Armor.toInt()].Get_Stat(Class_Damage);
					float Class_Level_Damage = Tier.Formula(Creature.Get_Stat(Class_Level));
					float All_Damage = Weapon.Get_Stat(Class_Damage) + (Armor_Damage) + (Class_Level_Damage) + Shield_Damage;
					Base_Damage = (All_Damage * Damage_Bonus_Multiplier.Multiple()) / Number_Of_Attacks;
				}
  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//
				float  Critical_Damage_Percent = 0f;
				Critical_Chance = Weapon.Get_Stat(Stat.Critical_Chance) + Critical_Chance_Bonus_Additive.Sum() + Shield_Critical_Chance;
				Critical_Chance *= Critical_Chance_Bonus_Multiplier.Multiple();
				if (Critical_Chance >= UnityEngine.Random.Range(0f,100f)) 
				{
					Critical_Damage_Percent = (Weapon.Get_Stat(Stat.Critical_Damage) + Critical_Damage_Bonus_Additive.Sum()) + Shield_Critical_Damage / 100;
					Critical_Damage_Percent *= Critical_Damage_Bonus_Multiplier.Multiple();
				}
				Critical_Damage = Base_Damage * Critical_Damage_Percent;
  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
				float Resistance_Percent = (Creature.Get_Stat(Class_Resistance) + Resistance_Bonus_Additive.Sum()) / 100 * Resistance_Bonus_Multiplier.Multiple();
				Resistance = Base_Damage * Resistance_Percent;
				
  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
				Damage = Critical_Damage + Base_Damage - Resistance;

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
 //***********Calculate: Energy**********//
//**************************************//
					Energy = (Weapon.Get_Stat(Stat.Energy) + Energy_Bonus_Additive.Sum()) * Energy_Bonus_Multiplier.Multiple();
					Energy *= Dont_Negate_Energy.toFloat();
					Creature.Get_Stat(Stat.Energy, Energy);
					
					if (Creature.Get_Stat(Stat.Energy) > 100) 
					{
						Creature.Get_Stat(Stat.Energy, 100, true); 
					}
					if (Creature.Get_Stat(Stat.Energy) < 0) 
					{
						Creature.Get_Stat(Stat.Energy, 0, true);
					}
					
					if (Weapon.Defect != Defect.None) 
					{
//						Advisory.gameObject.AddComponent()
					}

				}
				else
				{
  //**************************************//
 //********Passive Attack Miss 3/4*******//
//**************************************//
					Passives (Creature, State.Attack_Miss);
					Passives (Advisory, State.Counter_Attack_Miss);
					Debug.Log(Creature.Name + ": Missed!");			
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