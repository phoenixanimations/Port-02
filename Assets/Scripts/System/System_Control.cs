using UnityEngine;
using System.Collections;
namespace System_Control
{
	public enum Assign_Hand {None, Primary, Secondary}
	public enum Assign_Class {None, Melee, Magic, Archery};
	public enum Assign_Subclass {None, One_Handed, Two_Handed, Armor, Shield, Arrow, Bolt};
	public enum Stat {
					  //Everyone
					  Hitpoints, 		    
					  Melee_Damage,         		Magic_Damage,         	   Archery_Damage,
					  Melee_Resistance,    		  	Magic_Resistance,      	   Archery_Resistance,
					  Critical_Chance,      	  	Critical_Damage, 
					  Accuracy,             		Evade,
					  Defect_Chance, 
					  Passive_Chance,

					  //Creatures
					  Hitpoints_Level,
				      Melee_Level,         		 Magic_Level,           		Archery_Level,
					  Primary_Damage, 			 Secondary_Damage,
					  Primary_Accuracy, 		 Secondary_Accuracy,
					  Primary_Defect_Chance, 	 Secondary_Defect_Chance,
					  Primary_Passive_Chance, 	 Secondary_Passive_Chance,
					  Primary_Critical_Damage, 	 Secondary_Critical_Damage,
					  Primary_Critical_Chance,   Secondary_Critical_Chance,

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

//Magic staff increases critical

//Magic staff AOE


//Sword Bow anything secondary is the ammo.
//Bow canon. It's canon.

//Bow shield shield + accuracy bow any higher % accuracy is an attack