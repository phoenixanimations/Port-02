using UnityEngine;
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
	public float  Number_Of_Attacks;
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
	public string Class {private set; get;}
	public float  Class_Level {private set; get;}
	public float  Base_Damage {private set; get;}
	public float  Damage {private set; get;}
	public float  Critical {private set; get;}
	public float  Critical_Damage_Percent {private set; get;}
	public float  Critical_Chance {private set; get;}
	public float  Accuracy {private set; get;}
	public float  Resistance {private set; get;}
	public float  Energy {private set; get;}
	
	private float Advisory_Class_Level;
	private bool Dual_Wield_Equipped ()
	{
		Equipment_Foundation Primary_Hand = Creature.Slot[(int)Assign_Slot.Primary_Hand];
		Equipment_Foundation Secondary_Hand = Creature.Slot[(int)Assign_Slot.Secondary_Hand];
		///Make it so when you equip two handed it auto equips the other hand with none. 
		if ((Primary_Hand.Subclass == Assign_Subclass.One_Handed || 
			Primary_Hand.Subclass == Assign_Subclass.Two_Handed ||
			Primary_Hand.Subclass == Assign_Subclass.Bow ||
			Primary_Hand.Subclass == Assign_Subclass.One_Handed_Crossbow ||
			Primary_Hand.Subclass == Assign_Subclass.Two_Handed_Crossbow)
			&&
			(Secondary_Hand.Subclass == Assign_Subclass.One_Handed || 
			Secondary_Hand.Subclass == Assign_Subclass.Two_Handed ||
			Secondary_Hand.Subclass == Assign_Subclass.Bow ||
			Secondary_Hand.Subclass == Assign_Subclass.One_Handed_Crossbow ||
			Secondary_Hand.Subclass == Assign_Subclass.Two_Handed_Crossbow)) 
		{
			return true;
		}
		else
		{
			return false;
		}
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
		Class_Level = 0f;
		Accuracy = 0f;
		Resistance = 0f;
		Critical = 0f;
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

  //***************************************//
 //*Send Stats to Display Character Stats*//
//***************************************//
//	private float[] Primary_Stats = new float[30];
//	private float[] Secondary_Stats = new float[30];
//	private bool Light_Switch;
//	private void Record_Attack_Stat_To_Display_Character_Stats ()
//	{
//		Light_Switch = !Light_Switch;
//		if (Light_Switch)
//		{
//			Primary_Stats[(int)Attack_Stat.Class_Level]				   = 			Class_Level;
//			Primary_Stats[(int)Attack_Stat.Base_Damage] 		       =			Base_Damage;
//			Primary_Stats[(int)Attack_Stat.Damage] 					   = 			Damage;
//			Primary_Stats[(int)Attack_Stat.Damage_Bonus]			   = 			Calculate_List(Damage_Bonus, "Multiple");
//			Primary_Stats[(int)Attack_Stat.Accuracy] 				   =			Accuracy;
//			Primary_Stats[(int)Attack_Stat.Accuracy_Bonus]			   =			Calculate_List(Accuracy_Bonus,"Multiple");
//			Primary_Stats[(int)Attack_Stat.Critical] 				   = 			Critical;
//			Primary_Stats[(int)Attack_Stat.Critical_Bonus] 		 	   = 			Calculate_List(Critical_Damage_Bonus);
//			Primary_Stats[(int)Attack_Stat.Critical_Chance] 		   =  		    Critical_Chance;
//			Primary_Stats[(int)Attack_Stat.Critical_Chance_Bonus]  	   =			Calculate_List(Critical_Chance_Bonus);
//			Primary_Stats[(int)Attack_Stat.Resistance] 			  	   = 		    Resistance;
//			Primary_Stats[(int)Attack_Stat.Resistance_Bonus]		   = 			Calculate_List(Resistance_Bonus);
//			Primary_Stats[(int)Attack_Stat.None] = 0f;
//		}
//		if (!Light_Switch)
//		{
//			Secondary_Stats[(int)Attack_Stat.Class_Level]				   = 			Class_Level;
//			Secondary_Stats[(int)Attack_Stat.Base_Damage] 		       	   =			Base_Damage;
//			Secondary_Stats[(int)Attack_Stat.Damage] 					   = 			Damage;
//			Secondary_Stats[(int)Attack_Stat.Damage_Bonus]			   	   = 			Calculate_List(Damage_Bonus, "Multiple");
//			Secondary_Stats[(int)Attack_Stat.Accuracy] 				   	   =			Accuracy;
//			Secondary_Stats[(int)Attack_Stat.Accuracy_Bonus]			   =			Calculate_List(Accuracy_Bonus,"Multiple");
//			Secondary_Stats[(int)Attack_Stat.Critical] 				   	   = 			Critical;
//			Secondary_Stats[(int)Attack_Stat.Critical_Bonus] 		 	   = 			Calculate_List(Critical_Damage_Bonus);
//			Secondary_Stats[(int)Attack_Stat.Critical_Chance] 		  	   =  		    Critical_Chance;
//			Secondary_Stats[(int)Attack_Stat.Critical_Chance_Bonus]  	   =			Calculate_List(Critical_Chance_Bonus);
//			Secondary_Stats[(int)Attack_Stat.Resistance] 			  	   = 		    Resistance;
//			Secondary_Stats[(int)Attack_Stat.Resistance_Bonus]		  	   = 			Calculate_List(Resistance_Bonus);
//			Secondary_Stats[(int)Attack_Stat.None] = 0f;
//		}
//	}
//
//	public float Attack_Stat_To_Display_Character_Stats (Assign_Hand Primary_Or_Secondary, Attack_Stat Pick_Stat)
//	{
//		if (Primary_Or_Secondary == Assign_Hand.Primary)
//			return Primary_Stats[(int)Pick_Stat];
//		if (Primary_Or_Secondary == Assign_Hand.Secondary)
//			return Primary_Stats[(int)Pick_Stat];
//		return 0f;
//	}

  //**************************************//
 //*************Start Attack*************//
//**************************************//
	public void Initiate (Equipment_Foundation Weapon)
	{	
  //**************************************//
 //*********Check For Non Weapons********//
//**************************************//
		if (Weapon.Class == Assign_Class.None) return;
		if (Weapon.Subclass == Assign_Subclass.One_Handed_Shield || 
			Weapon.Subclass == Assign_Subclass.Two_Handed_Shield ||
			Weapon.Subclass == Assign_Subclass.Armor ||
			Weapon.Subclass == Assign_Subclass.Arrow ||
			Weapon.Subclass == Assign_Subclass.Bolt)
		{
			Debug.LogError(Weapon.Name + "is not supported when classed as: " + Weapon.Class + "and Subclass: " + Weapon.Subclass);
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
 //**Calculate: Class Level and Damage***//
//**************************************//
			switch (Weapon.Class) //Find a nicer way to do this. 
			{
			case Assign_Class.Melee:
				Class_Level = Tier.Formula(Creature.Get_Stat(Stat.Melee_Level));
				Advisory_Class_Level = Tier.Formula(Advisory.Get_Stat(Stat.Melee_Level));
				Base_Damage = Weapon.Get_Stat(Stat.Melee_Damage) + Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Melee_Damage);
				break;
			case Assign_Class.Magic:
				Class_Level = Tier.Formula(Creature.Get_Stat(Stat.Magic_Level));
				Advisory_Class_Level = Tier.Formula(Advisory.Get_Stat(Stat.Magic_Level));
				Base_Damage = Weapon.Get_Stat(Stat.Magic_Damage) + Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Magic_Damage);
				break;
			case Assign_Class.Archery:
				Class_Level = Tier.Formula(Creature.Get_Stat(Stat.Archery_Level));
				Advisory_Class_Level = Tier.Formula(Advisory.Get_Stat(Stat.Archery_Level));
				Base_Damage = Weapon.Get_Stat(Stat.Archery_Damage) + Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Archery_Damage);
				break;
			default:
				Debug.LogError(Weapon.Class.ToString() + ": Not supported");
				break;
			}
  //**************************************//
 //*********Calculate: Accuracy**********//
//**************************************//
				float Weapon_Accuracy = Weapon.Get_Stat(Stat.Accuracy);
				float Armor_Accuracy = Creature.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Accuracy);
				float Creature_Accuracy = Class_Level + Weapon_Accuracy + Armor_Accuracy;	
				
				float Advisory_Primary_Evade = Advisory.Slot[(int)Assign_Slot.Primary_Hand].Get_Stat(Stat.Evade); 
				float Advisory_Secondary_Evade = Advisory.Slot[(int)Assign_Slot.Secondary_Hand].Get_Stat(Stat.Evade); 
				float Advisory_Weapon_Evade = Advisory_Primary_Evade + Advisory_Secondary_Evade;
				float Advisory_Armor_Evade =  Advisory.Slot[(int)Assign_Slot.Armor].Get_Stat(Stat.Evade);
				float Advisory_Arrow_Evade =  Advisory.Slot[(int)Assign_Slot.Arrow].Get_Stat(Stat.Evade);
				float Advisory_Evade = Advisory_Weapon_Evade + Advisory_Armor_Evade + Advisory_Arrow_Evade + Advisory_Class_Level;			

				Accuracy += 50f * (Creature_Accuracy/Advisory_Evade) * Accuracy_Bonus.Multiple();  //Where do you apply double accuracy. 
  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//
				if (Dual_Wield_Equipped ())
				{
//					Base_Damage += Equipped_Weapon_Damage + (Equipped_Class_Plus_Equipped_Armor_Damage * 0.5f); <<<<<<<<think about this.
				}
//				if (!Dual_Wield_Equipped ()) 
//				{
//					Base_Damage += Equipped_Weapon_Damage + Equipped_Class_Plus_Equipped_Armor_Damage;
//				}
//
  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//
//				if ((Primary_Or_Secondary.Get_Stat(Stat.Critical_Chance) + Calculate_List(Critical_Chance_Bonus)) >= UnityEngine.Random.Range(0f,100f))
//					Critical_Damage_Percent = (Primary_Or_Secondary.Get_Stat(Stat.Critical_Damage) + Calculate_List(Critical_Damage_Bonus)) / 100;
//				Critical += Base_Damage * Critical_Damage_Percent; 
//
  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
//				float Resistance_Percent = (Creature.Get_Stat(Class + "_Resistance") + Calculate_List(Resistance_Bonus)) / 100;
//				Resistance += Base_Damage * Resistance_Percent;
//
  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
//				Damage += (Critical + Base_Damage - Resistance) * Calculate_List(Damage_Bonus, "Multiple"); //Damage bonus multiplied
//
  //**************************************//
 //**************Dice Roll***************//
//**************************************//	
//				if (Accuracy >= UnityEngine.Random.Range(0f,100f))
//				{	
  //**************************************//
 //*******Passive Attack Hit 2/4*********//
//**************************************//
//					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Hit);
//					Creature.Attack_Status(Phase.Attack_Hit);
//					Adversary.Counter_Attack(Phase.Counter_Attack_Hit,Creature,this);
//
  //**************************************//
 //******Calculate: Adversary - Damage***//
//**************************************//
//					Damage = Mathf.Floor(Damage);
//					Adversary.Get_Stat(Stat.Hitpoints,-Damage);	
//
  //**************************************//
 //***********Calculate: Energy**********//
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
//				}
//
//				else
//				{
  //**************************************//
 //********Passive Attack Miss 3/4*******//
//**************************************//
//					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Miss);
//					Creature.Attack_Status(Phase.Attack_Miss);
//					Adversary.Counter_Attack(Phase.Counter_Attack_Miss,Creature,this);	
//					Debug.Log("You missed!");			
//				}
  //**************************************//
 //********Passive Attack End 4/4********//
//**************************************//
//				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_End);
//				Creature.Attack_Status(Phase.Attack_End);
//				Adversary.Counter_Attack(Phase.Counter_Attack_End,Creature,this);				
//
//				Attack_Count++;
//			}
  //**************************************//
 //**************End Loop****************//
//**************************************//
		}
//		Record_Attack_Stat_To_Display_Character_Stats();
	}
  //**************************************//
 //*************End Attack***************//
//**************************************//
}