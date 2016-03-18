using UnityEngine;
using System.Collections;
namespace System_Control
{
	public enum Assign_Hand {None, Primary, Secondary};
	public enum Assign_Class {None, Melee, Magic, Archery};
	public enum Defect {Bleed};
	public enum Phase {Move, Pre_Attack,
					   Attack_Begin,	     Attack_Hit,	     Attack_Miss,		  Attack_End, 
					   Counter_Attack_Begin, Counter_Attack_Hit, Counter_Attack_Miss, Counter_Attack_End};
	public enum Assign_Subclass {None, One_Handed, Two_Handed, Shield, Bow, Crossbow, Armor, Arrow, Bolt};
	public enum Attack_Stat {Class_Level,
							 Base_Damage,	Damage,Damage_Bonus,
							 Critical,	 	Critical_Bonus,	  	 Critical_Chance, 	Critical_Chance_Bonus,
							 Accuracy,		Accuracy_Bonus,
							 Resistance,	Resistance_Bonus,
							 None}

	public enum Stat {
					  //Everyone
					  Hitpoints, 		    
					  Melee_Damage,         		Magic_Damage,         	   Archery_Damage,
					  Melee_Resistance,    		  	Magic_Resistance,      	   Archery_Resistance,
					  Critical_Chance,      	  	Critical_Damage, 
					  Accuracy,             		Evade,					   Distance,//Delete Later
					  Maximum_Distance, Minimum_Distance,
					  Movement, Knockback,

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

// ((x-1)^2 * (x-1)^((x-1)/100))