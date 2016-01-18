using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Display_Character_Stats : MonoBehaviour 
{

	private Creature Cache;
	[Header("Hitpoints")]
	public float Hitpoints;
	[Header("Class Damage")]
	public float Melee_Damage;
	public float Magic_Damage;
	public float Archery_Damage;
	[Header("Class Resistance")]
	public float Melee_Resistance;
	public float Magic_Resistance;
	public float Archery_Resistance;

	protected void Start ()
	{
		Cache = GetComponent<Creature>();
	}

	protected void Update ()
	{
 		
		Hitpoints = Cache.Get_Stat(Stat.Hitpoints);
		Melee_Damage = Cache.Get_Stat(Stat.Melee_Damage);
		
		
		
	}



// ID,
//					  Hitpoints, 		    
//					  Melee_Damage,         Magic_Damage,          Archery_Damage,
//					  Melee_Resistance,     Magic_Resistance,      Archery_Resistance,
//					  Critical_Chance,      Critical_Damage, 
//					  Accuracy,             Evade,
//					  Defect_Chance, 
//					  Passive_Chance,
//
//					  //Creatures
//					  Hitpoints_Level,
//				      Melee_Level,          Magic_Level,           Archery_Level,
//					  PrimaryDamage, 		SecondaryDamage,
//					  PrimaryAccuracy, 		SecondaryAccuracy,
//
//					  //Weapons
//					  Equip_Level

}