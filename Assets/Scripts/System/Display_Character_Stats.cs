using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Display_Character_Stats : MonoBehaviour 
{
	private Creature Creature;
	private Attack Creature_Attack;
	[Header("Hitpoints")]
	public float Hitpoints;
	[Header("Damage")]
	public float Max_Damage;
	public float Primary_Damage;
//	public float Primary_Damage_Bonus;
	public float Secondary_Damage;
//	public float Secondary_Damage_Bonus;
	[Header("Critical")]
	public float Primary_Critical;
	public float Primary_Critical_Chance;
	public float Secondary_Critical;
	public float Secondary_Critical_Chance;
	[Header("Accuracy")]
	public float Primary_Accuracy;
	public float Secondary_Accuracy;
	[Header("Class Resistance")]
	public float Melee_Resistance;
	public float Magic_Resistance;
	public float Archery_Resistance;
	[Header("Energy")]
	public float Energy;

	protected void Start ()
	{
		Creature = GetComponent<Creature>();
		Creature_Attack = GetComponent<Attack>();
	}

	protected void Update ()
	{	
		Hitpoints = 					Creature.Get_Stat(Stat.Hitpoints);
		
		Primary_Damage = 				Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Primary,Attack_Stat.Damage);
//		Primary_Damage_Bonus = 			Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Primary,Attack_Stat.Damage_Bonus);
		Secondary_Damage = 				Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Secondary,Attack_Stat.Damage);
//		Secondary_Damage_Bonus = 		Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Secondary,Attack_Stat.Damage_Bonus);
		Max_Damage = 					Primary_Damage + Secondary_Damage;
		Primary_Critical = 				Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Primary,Attack_Stat.Critical);
		Primary_Critical_Chance =		Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Primary,Attack_Stat.Critical_Chance);
		Secondary_Critical = 			Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Secondary,Attack_Stat.Critical);
		Secondary_Critical_Chance = 	Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Secondary,Attack_Stat.Critical_Chance);
		Primary_Accuracy = 				Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Primary,Attack_Stat.Accuracy);
		Secondary_Accuracy = 			Creature_Attack.Attack_Stat_To_Display_Character_Stats(Assign_Hand.Secondary,Attack_Stat.Accuracy);
		Melee_Resistance = 				Creature.Get_Stat(Stat.Melee_Resistance);
		Magic_Resistance = 				Creature.Get_Stat(Stat.Magic_Resistance);
		Archery_Resistance = 			Creature.Get_Stat(Stat.Archery_Resistance);
		Energy = Creature.Get_Stat(Stat.Energy);
	}
}




















/*
	[Header("Hitpoints")]

	[Header("Class Damage")]

	[Header("Critical Damage")]

	[Header("Accuracy Damage")]

	[Header("Class Resistance")]
*/