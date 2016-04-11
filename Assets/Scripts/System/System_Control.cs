using UnityEngine;
using System.Collections;

namespace System_Control
{
	  //************************//
	 //*********State**********//
    //************************//
	public enum State {
					   Idle,Use,Equip,MoveAttack,Jump,RequestInteraction,
					   BeginningOfTurn,EndOfTurn,
					   Move,Interact,
				       CounterAttack,Attack,
					   MurderedCreature, Heal, LevelUp
					  };

	  //************************//
	 //******Weapon Kind*******//
    //************************//
	public enum Assign_Slot {
							    Primary_Hand,Secondary_Hand,Armor, Arrow
							};

	public enum Assign_Class {
								None, Melee, Magic, Archery, xForm
							 };

	public enum Assign_Subclass {
								 None, One_Handed, Two_Handed, One_Handed_Shield, Two_Handed_Shield, Bow, One_Handed_Crossbow, Two_Handed_Crossbow, Armor, Arrow, Bolt
								};
	public enum Defect {
						None, Burn, Poison, Slow, Stun, Shock, Bleed, Bind, Numb, Corruption, Drunk
					   };

	  //************************//
	 //*****Creature Kind******//
    //************************//
	public enum Catagory {Creature, Vehicle};

	  //************************//
	 //****Creature Stats******//
    //************************//
	public enum Stat {
					  //Everyone
					  Hitpoints, 		    
					  Melee_Damage,         		Magic_Damage,         	   Archery_Damage,
					  Melee_Resistance,    		  	Magic_Resistance,      	   Archery_Resistance,
					  Critical_Chance,      	  	Critical_Damage, 
					  Accuracy,             		Evade,
					  Maximum_Distance, Minimum_Distance,
					  Movement, Knockback, Jump,
					 
					  //Creatures
					  Hitpoints_Level,
				      Melee_Level,         		 Magic_Level,           		Archery_Level,
					  Energy,
					 
					  //Weapon and or Equipment
					  Number_Of_Attacks, Area_Of_Effect
					};

	  //************************//
	 //**SYSTEM TIER Formula***//
    //************************//
	class Tier
	{
		public static float Formula (float Tier_Number)
		{
			return 10 * (1 + ((Tier_Number/10) - Mathf.Floor(Tier_Number/10))) * (Mathf.Pow(2, Mathf.Floor(Tier_Number/10)));
		}
	}

	  //************************//
	 //******SYSTEM LAYERS*****//
    //************************//
	public enum Mask {Default = 1,UI};

	  //************************//
	 //*****SYSTEM VECTORS*****//
    //************************//
	public sealed class Vector
	{
		public static Vector2 Up =    new Vector2(1.14f,0.87f);   
		public static Vector2 Down =  new Vector2(-1.14f,-0.87f);
		public static Vector2 Left =  new Vector2(-2f,0f);        
		public static Vector2 Right = new Vector2(2f,0f);      
   		
	  //************************//
	 //******DEBUG ONLY********//
	//************************//
		public static string ConvertVectorToText (Vector2 VectorToConvert)
		{
			if (VectorToConvert == Vector.Up)
				return "Up";
			if (VectorToConvert == Vector.Down)
				return "Down";
			if (VectorToConvert == Vector.Left)
				return "Left";
			if (VectorToConvert == Vector.Right)
				return "Right";
			return "None";
		}
	}
}