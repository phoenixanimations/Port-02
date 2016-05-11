using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Equipment_Foundation : Stats 
{
	 //******************//
	//***Level or Tier**//
   //******************//
	public float Level;
	 //******************//
	//*******Class******//
   //******************//
	public Assign_Class Class;
	public Assign_Subclass Subclass;
	 //******************//
	//*Check Two Handed*//
   //******************//
	public bool Two_Handed;
	 //******************//
	//**Area of Effect**//
   //******************//
	public List<bool> AOE_Pattern;
	public List<float> AOE_Damage;
	public enum AOE_Knockback_Direction_Enum {Left,Up,Right,Down,Left_Up,Right_Up,Right_Down,Left_Down};
	public List<AOE_Knockback_Direction_Enum> AOE_Knockback_Direction;
	public List<float> AOE_Hit_Order;
	 //******************//
	//******Defects*****//
   //******************//
	public Defect Defect;
	 //******************//
	//*****Passives*****//
   //******************//
	public List <Status_Foundation> Passives = new List<Status_Foundation>();	
	 //******************//
	//**Equipment Notes*//
   //******************//
	public string Equipment_Notes;
	public void Level_Up (Stat Stat)
	{
		if (Stat == Stat.Hitpoints)
		{
			Get_Stat(Stat,Tier.Formula(Level) * Level * Stat_Multiplier[(int)Stat],true);
			return;
		}

		Get_Stat(Stat,Tier.Formula(Level) * Stat_Multiplier[(int)Stat],true);
	}
}