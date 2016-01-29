using UnityEngine;
using System.Collections;
namespace System_Control
{
	public enum Assign_Hand {None, Primary, Secondary};
	public enum Assign_Class {None, Melee, Magic, Archery};
	public enum Phase {Attack_Begin,Attack_Miss,Attack_End};
	public enum Assign_Subclass {None, One_Handed, Two_Handed, Shield, Helmet, Chest, Legs, Arrow, Bolt};
	public enum Stat {
					  //Everyone
					  Hitpoints, 		    
					  Melee_Damage,         		Magic_Damage,         	   Archery_Damage,
					  Melee_Resistance,    		  	Magic_Resistance,      	   Archery_Resistance,
					  Critical_Chance,      	  	Critical_Damage, 
					  Accuracy,             		Evade,

					  //Creatures
					  Hitpoints_Level,
				      Melee_Level,         		 Magic_Level,           		Archery_Level,
					  Energy,

					  //Weapon and or Equipment
					  Equip_Level, Number_Of_Attacks
			};
	public enum ID
			{
					  //One_Handed
					  Melee_Vanilla_One_Handed,
					  //Two_Handed
					  Melee_Vanilla_Two_Handed,
					  //Shield
					  Melee_Vanilla_Shield,
					  //Helmet
					  Nude_Helmet,
					  //Chest
					  Nude_Chest,
					  //Legs
					  Nude_Legs

			};
		
	class Tier
	{
		public static float Formula (float Tier_Number)
		{
			return 10 * (1 + ((Tier_Number/10) - Mathf.Floor(Tier_Number/10))) * (Mathf.Pow(2, Mathf.Floor(Tier_Number/10)));
		}
	}
}

//Sword Bow anything secondary is the ammo.
//Bow canon. It's canon.

//Bow shield shield + accuracy bow any higher % accuracy is an attack