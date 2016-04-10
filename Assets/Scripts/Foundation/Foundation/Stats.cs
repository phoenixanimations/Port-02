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
	public void Get_Stat (Stat Change_Stat_Selected, float Amount, bool MakeNumberEqualToAmount = false)
	{
		if (MakeNumberEqualToAmount)
		{
			Stat_Dictionary[(int)Change_Stat_Selected] = Mathf.Floor(Amount);
		}
		else
		{
			Stat_Dictionary[(int)Change_Stat_Selected] += Mathf.Floor(Amount);
		} 
	}

	public float Get_Stat (Stat Change_Stat_Selected)
	{
		return Stat_Dictionary[(int)Change_Stat_Selected];
	}

	public void Get_Stat (Stat Change_Stat_Selected, float Amount, float Times_Tier_Formula_Float, bool MakeNumberEqualToAmount = false)
	{
		Amount *= Tier.Formula(Times_Tier_Formula_Float);
		Get_Stat(Change_Stat_Selected, Amount,MakeNumberEqualToAmount);
	}

	public void Get_Stat (Stat Change_Stat_Selected, float Amount,  Stat Times_Tier_Formula_Stat, bool MakeNumberEqualToAmount = false)
	{
		Amount *= Tier.Formula(Get_Stat(Times_Tier_Formula_Stat));
		Get_Stat(Change_Stat_Selected, Amount,MakeNumberEqualToAmount);
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