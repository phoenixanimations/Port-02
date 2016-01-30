using UnityEngine;
using System.Collections;
namespace System_Control
{
	public enum Assign_Hand {None, Primary, Secondary};
	public enum Assign_Class {None, Melee, Magic, Archery};
	public enum Phase {Attack_Begin,	     Attack_Hit,	     Attack_Miss,		  Attack_End, 
					   Counter_Attack_Begin, Counter_Attack_Hit, Counter_Attack_Miss, Counter_Attack_End};
	public enum Assign_Subclass {None, One_Handed, Two_Handed, Shield, Helmet, Chest, Legs, Arrow, Bolt};
	public enum Stat {
					  //Everyone
					  Hitpoints, 		    
					  Melee_Damage,         		Magic_Damage,         	   Archery_Damage,
					  Melee_Resistance,    		  	Magic_Resistance,      	   Archery_Resistance,
					  Critical_Chance,      	  	Critical_Damage, 
					  Accuracy,             		Evade,					   Distance,

					  //Creatures
					  Hitpoints_Level,
				      Melee_Level,         		 Magic_Level,           		Archery_Level,
					  Energy,

					  //Weapon and or Equipment
					  Item_Tier, Number_Of_Attacks
			};
		
	class Tier
	{
		public static float Formula (float Tier_Number)
		{
			return 10 * (1 + ((Tier_Number/10) - Mathf.Floor(Tier_Number/10))) * (Mathf.Pow(2, Mathf.Floor(Tier_Number/10)));
		}
	}
}