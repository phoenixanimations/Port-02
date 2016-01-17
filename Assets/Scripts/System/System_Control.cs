using UnityEngine;
using System.Collections;
namespace System_Control
{
	public enum Assign_Class {None, Melee, Magic, Archery};
	public enum Assign_Subclass {None, One_Handed, Two_Handed, Shield, Arrow, Bolt};
	public enum Stat {
					  //Everyone
					  ID,
					  Hitpoints, 		    
					  Melee_Damage,         Magic_Damage,          Archery_Damage,
					  Melee_Resistance,     Magic_Resistance,      Archery_Resistance,
					  Critical_Chance,      Critical_Damage, 
					  Accuracy,             Evade,
					  Defect_Chance, 
					  Passive_Chance,

					  //Creatures
					  Hitpoints_Level,
				      Melee_Level,          Magic_Level,           Archery_Level,
					  PrimaryDamage, 		SecondaryDamage,
					  PrimaryAccuracy, 		SecondaryAccuracy,

					  //Weapons
					  Equip_Level
			}
		
	class Tier
	{
		public static float Formula (float Tier_Number)
		{
			return 10 * (1 + ((Tier_Number/10) - Mathf.Floor(Tier_Number/10))) * (Mathf.Pow(2, Mathf.Floor(Tier_Number/10)));
		}
	}
}

