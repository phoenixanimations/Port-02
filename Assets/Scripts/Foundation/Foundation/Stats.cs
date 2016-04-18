using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Stats : Basic_Tile
{
	public string Name;
	public string Description;

	public List <float> Stat_Dictionary = new List<float>(new float[200]);
	public List <float> Stat_Multiplier = new List<float>(new float[200]);
	public List<float> Heal_Bonus = new List<float>(new float[200]);
	
    //****************************************//
   //****************************************//
  //****************GET_STAT****************//
 //****************************************//
//****************************************//
	public void Get_Stat (Stat Change_Stat_Selected, float Amount, bool Make_Number_Equal_To_Amount = false, bool Dont_Floor = false)
	{
		if (Make_Number_Equal_To_Amount)
		{
			Stat_Dictionary[(int)Change_Stat_Selected] = Mathf.Floor(Amount);
			if (Dont_Floor)
			{
				Stat_Dictionary[(int)Change_Stat_Selected] = Amount;
			}
		}
		else
		{
			Stat_Dictionary[(int)Change_Stat_Selected] += Mathf.Floor(Amount);
			if (Dont_Floor)
			{
				Stat_Dictionary[(int)Change_Stat_Selected] += Amount;
			}
		} 
	}

	public float Get_Stat (Stat Change_Stat_Selected)
	{
		return Stat_Dictionary[(int)Change_Stat_Selected];
	}
	
	

    //****************************************//
   //****************************************//
  //*****************LEVEL UP***************//
 //****************************************//
//****************************************//

	public virtual void Level_Up(Stat Stat, float Amount = 1, bool SetLevel = false)
	{			
	}
}