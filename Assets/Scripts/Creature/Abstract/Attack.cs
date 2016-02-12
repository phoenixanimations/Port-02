using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Attack : Raycast
{
	public Equipment_Foundation Primary;
	public Equipment_Foundation Secondary;
	public Equipment_Foundation Armor;

	public Creature Adversary;
	private Creature Creature;
 //**************************************//
 //***********Global Modify*************//
//*************************************//
	public float  Number_Of_Attacks;
	public float  Max_Attacks {get;private set;}
  //**************************************//
 //***************Modify*****************//
//**************************************//
	public List<float> Damage_Bonus = new List<float>(){1};
	public List<float> Accuracy_Bonus = new List<float>(){1};
	public List<float> Resistance_Bonus = new List<float>(){0};
	public List<float> Critical_Chance_Bonus = new List<float>(){0};
	public List<float> Critical_Damage_Bonus = new List<float>(){0};
	
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

  //**************************************//
 //**************Utilities***************//
//**************************************//
	private float Calculate_List (List<float> List_To_Calculate, string Add_Or_Multiple = "Add")
	{
		float Calculation = 0f;

		if (Add_Or_Multiple == "Add")
		{
			foreach (var i in List_To_Calculate) 
			{
				Calculation = 0f;
				Calculation += i;	
			}
		}
			
		if (Add_Or_Multiple == "Multiple")
		{
			foreach (var i in List_To_Calculate) 
			{
				Calculation = 1f;
				Calculation *= i;
			}
		}
		return Calculation;
	}

	private void Reset_List (List<float> List_To_Calculate, string Add_Or_Multiple = "Add")
	{
		List_To_Calculate.Clear();
		if (Add_Or_Multiple == "Add")
			List_To_Calculate.Add(0);
		if (Add_Or_Multiple == "Multiple")
			List_To_Calculate.Add(1);
	}

	private bool Dual_Wield_Equipped ()
	{
		if (Secondary.Subclass == Assign_Subclass.One_Handed || Secondary.Subclass == Assign_Subclass.Two_Handed) return true;
		return false;
	}

  //**************************************//
 //**************Set Stats***************//
//**************************************//
	private void Reset_Stats ()
	{
		Number_Of_Attacks = 0f;
		Class_Level = 0f;
		
	    Reset_List(Damage_Bonus,"Multiple");
		Reset_List (Accuracy_Bonus,"Multiple");
		Reset_List (Resistance_Bonus);
		Reset_List (Critical_Chance_Bonus);
		Reset_List (Critical_Damage_Bonus);

		Accuracy = 0f;
		Resistance = 0f;
		Critical = 0f;
		Base_Damage = 0f;
		Damage = 0f;
	}

	private void Start_Hitting_Me_Baby ()
	{	
		Max_Attacks = 0f;
		Reset_Stats();

		Primary = Creature.Primary_Weapon;
		Secondary = Creature.Secondary_Weapon;
		Armor = Creature.Armor;
	}

  //**************************************//
 //****************Passives**************//
//**************************************//
	private void Passives (Equipment_Foundation Primary_Or_Secondary, Creature Adversary, Phase Attack_Phase)
	{
		Primary_Or_Secondary.Attack_Status(Attack_Phase);
		Armor.Attack_Status(Attack_Phase);
	}

	protected override void Start ()
	{
		base.Start ();
		Creature = gameObject.GetComponent<Creature>();
	}

  //***************************************//
 //*Send Stats to Display Character Stats*//
//***************************************//
	private float[] Primary_Stats = new float[30];
	private float[] Secondary_Stats = new float[30];
	private bool Light_Switch;
	private void Record_Attack_Stat_To_Display_Character_Stats ()
	{
		Light_Switch = !Light_Switch;
		if (Light_Switch)
		{
			Primary_Stats[(int)Attack_Stat.Class_Level]				   = 			Class_Level;
			Primary_Stats[(int)Attack_Stat.Base_Damage] 		       =			Base_Damage;
			Primary_Stats[(int)Attack_Stat.Damage] 					   = 			Damage;
			Primary_Stats[(int)Attack_Stat.Damage_Bonus]			   = 			Calculate_List(Damage_Bonus, "Multiple");
			Primary_Stats[(int)Attack_Stat.Accuracy] 				   =			Accuracy;
			Primary_Stats[(int)Attack_Stat.Accuracy_Bonus]			   =			Calculate_List(Accuracy_Bonus,"Multiple");
			Primary_Stats[(int)Attack_Stat.Critical] 				   = 			Critical;
			Primary_Stats[(int)Attack_Stat.Critical_Bonus] 		 	   = 			Calculate_List(Critical_Damage_Bonus);
			Primary_Stats[(int)Attack_Stat.Critical_Chance] 		   =  		    Critical_Chance;
			Primary_Stats[(int)Attack_Stat.Critical_Chance_Bonus]  	   =			Calculate_List(Critical_Chance_Bonus);
			Primary_Stats[(int)Attack_Stat.Resistance] 			  	   = 		    Resistance;
			Primary_Stats[(int)Attack_Stat.Resistance_Bonus]		   = 			Calculate_List(Resistance_Bonus);
			Primary_Stats[(int)Attack_Stat.None] = 0f;
		}
		if (!Light_Switch)
		{
			Secondary_Stats[(int)Attack_Stat.Class_Level]				   = 			Class_Level;
			Secondary_Stats[(int)Attack_Stat.Base_Damage] 		       	   =			Base_Damage;
			Secondary_Stats[(int)Attack_Stat.Damage] 					   = 			Damage;
			Secondary_Stats[(int)Attack_Stat.Damage_Bonus]			   	   = 			Calculate_List(Damage_Bonus, "Multiple");
			Secondary_Stats[(int)Attack_Stat.Accuracy] 				   	   =			Accuracy;
			Secondary_Stats[(int)Attack_Stat.Accuracy_Bonus]			   =			Calculate_List(Accuracy_Bonus,"Multiple");
			Secondary_Stats[(int)Attack_Stat.Critical] 				   	   = 			Critical;
			Secondary_Stats[(int)Attack_Stat.Critical_Bonus] 		 	   = 			Calculate_List(Critical_Damage_Bonus);
			Secondary_Stats[(int)Attack_Stat.Critical_Chance] 		  	   =  		    Critical_Chance;
			Secondary_Stats[(int)Attack_Stat.Critical_Chance_Bonus]  	   =			Calculate_List(Critical_Chance_Bonus);
			Secondary_Stats[(int)Attack_Stat.Resistance] 			  	   = 		    Resistance;
			Secondary_Stats[(int)Attack_Stat.Resistance_Bonus]		  	   = 			Calculate_List(Resistance_Bonus);
			Secondary_Stats[(int)Attack_Stat.None] = 0f;
		}
	}

	public float Attack_Stat_To_Display_Character_Stats (Assign_Hand Primary_Or_Secondary, Attack_Stat Pick_Stat)
	{
		if (Primary_Or_Secondary == Assign_Hand.Primary)
			return Primary_Stats[(int)Pick_Stat];
		if (Primary_Or_Secondary == Assign_Hand.Secondary)
			return Primary_Stats[(int)Pick_Stat];
		return 0f;
	}

  //**************************************//
 //*************Start Attack*************//
//**************************************//
	public void Hit_Me_Baby (Equipment_Foundation Primary_Or_Secondary)
	{
		Start_Hitting_Me_Baby ();
  //**************************************//
 //***************Check Null*************//
//**************************************//
		if (Armor == null) { Debug.LogError("You can go in to battle Nude but you have to EQUIP Nude Armor. Why would a character equip the concept of nothing?"); return;} 
		if (Primary_Or_Secondary == null) return;

  //**************************************//
 //********Calculate: Attack Count*******//
//**************************************//		
		Number_Of_Attacks = Primary_Or_Secondary.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //********Calculate: Distance***********//
//**************************************//	
		Hit = Physics2D.Raycast(transform.position, Creature.Front, Creature.x * Creature.Get_Stat(Stat.Distance));
		if (Hit.collider != null)
		{
			Adversary = Hit.collider.GetComponent<Creature>();

			while (Max_Attacks < Number_Of_Attacks)
			{
				Reset_Stats();
  //**************************************//
 //**********Passive Attack Begin********//
//**************************************//
				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Begin);
				Creature.Attack_Status(Phase.Attack_Begin);
 				Adversary.Counter_Attack(Phase.Counter_Attack_Begin);

  //**************************************//
 //******Calculate: Number of Attacks****//
//**************************************//
				Number_Of_Attacks = Primary_Or_Secondary.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //*******Calculate: Class Level*********//
//**************************************//
				Class = Primary_Or_Secondary.Class.ToString();
				Class_Level = Creature.Get_Stat(Class + "_Level");

  //**************************************//
 //*********Calculate: Accuracy**********//
//**************************************//
				float Weapon_Accuracy = Primary_Or_Secondary.Get_Stat(Stat.Accuracy);
				float Armor_Accuracy = Armor.Get_Stat(Stat.Accuracy);
				float Creature_Accuracy = Tier.Formula(Class_Level) + Weapon_Accuracy + Armor_Accuracy;	
			
				float Adversary_Class_Evade = Tier.Formula(Adversary.Get_Stat(Primary_Or_Secondary.Class.ToString() + "_Level"));
				float Adversary_Weapon_Evade = Adversary.Primary_Weapon.Get_Stat(Stat.Evade) + Adversary.Secondary_Weapon.Get_Stat(Stat.Evade);
				float Adversary_Armor_Evade =  Adversary.Armor.Get_Stat(Stat.Accuracy);
				float Adversary_Evade = Adversary_Class_Evade + Adversary_Weapon_Evade + Adversary_Armor_Evade;			

				Accuracy += 50f * (Creature_Accuracy/Adversary_Evade) * Calculate_List(Accuracy_Bonus,"Multiple");

  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//
				string Class_Damage = Class + "_Damage";
				float Equipped_Weapon_Damage = Primary_Or_Secondary.Get_Stat(Class_Damage);
				float Equipped_Class_Damage = Tier.Formula(Class_Level);
				float Equipped_Armor_Damage = Armor.Get_Stat(Class_Damage);
				float Equipped_Class_Plus_Equipped_Armor_Damage = Equipped_Class_Damage + Equipped_Armor_Damage;
			

				if (Dual_Wield_Equipped ())
				{

					Base_Damage += Equipped_Weapon_Damage + (Equipped_Class_Plus_Equipped_Armor_Damage * 0.5f);
				}
				if (!Dual_Wield_Equipped ()) 
				{
					Base_Damage += Equipped_Weapon_Damage + Equipped_Class_Plus_Equipped_Armor_Damage;
				}

  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//
				if ((Primary_Or_Secondary.Get_Stat(Stat.Critical_Chance) + Calculate_List(Critical_Chance_Bonus)) >= UnityEngine.Random.Range(0f,100f))
					Critical_Damage_Percent = (Primary_Or_Secondary.Get_Stat(Stat.Critical_Damage) + Calculate_List(Critical_Damage_Bonus)) / 100;
				Critical += Base_Damage * Critical_Damage_Percent; 

  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
				float Resistance_Percent = (Creature.Get_Stat(Class + "_Resistance") + Calculate_List(Resistance_Bonus)) / 100;
				Resistance += Base_Damage * Resistance_Percent;

  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
				Damage += (Critical + Base_Damage - Resistance) * Calculate_List(Damage_Bonus, "Multiple"); //Damage bonus multiplied

  //**************************************//
 //**************Dice Roll***************//
//**************************************//	
				if (Accuracy >= UnityEngine.Random.Range(0f,100f))
				{	
  //**************************************//
 //**********Passive Attack Hit**********//
//**************************************//
					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Hit);
					Creature.Attack_Status(Phase.Attack_Hit);
					Adversary.Counter_Attack(Phase.Counter_Attack_Hit);

  //**************************************//
 //******Calculate: Adversary - Damage***//
//**************************************//
					Damage = Mathf.Floor(Damage);
					Adversary.Get_Stat(Stat.Hitpoints,-Damage);	

  //**************************************//
 //***********Calculate: Energy**********//
//**************************************//
					if (Primary_Or_Secondary.Class == Assign_Class.Melee) Creature.Get_Stat(Stat.Energy,15f);
					if (Primary_Or_Secondary.Class == Assign_Class.Magic) Creature.Get_Stat(Stat.Energy,25f);
					if (Primary_Or_Secondary.Class == Assign_Class.Archery) Creature.Get_Stat(Stat.Energy,5f);
					
					if (Creature.Get_Stat(Stat.Energy) > 100) 
						Creature.Get_Stat(Stat.Energy, 100, true); 
					if (Creature.Get_Stat(Stat.Energy) < 0) 
						Creature.Get_Stat(Stat.Energy, 0, true); 

				}

				else
				{
  //**************************************//
 //**********Passive Attack Miss*********//
//**************************************//
					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Miss);
					Creature.Attack_Status(Phase.Attack_Miss);
					Adversary.Counter_Attack(Phase.Counter_Attack_Miss);				
				}
  //**************************************//
 //**********Passive Attack End**********//
//**************************************//
				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_End);
				Creature.Attack_Status(Phase.Attack_End);
				Adversary.Counter_Attack(Phase.Counter_Attack_End);				

				Max_Attacks++;
			}
  //**************************************//
 //**************End Loop****************//
//**************************************//
		}
		Record_Attack_Stat_To_Display_Character_Stats();
	}
  //**************************************//
 //*************End Attack***************//
//**************************************//
}