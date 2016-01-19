﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Stats : BasicTile
{
	public string Name;
	public string Description;
	
	public int ID;

	protected Dictionary<string, float> Stat_Dictionary = new Dictionary<string, float>()
	{
		{"Hitpoints",0},
		{"Melee_Damage",0}, 	{"Magic_Damage",0}, 	{"Archery_Damage",0},
		{"Melee_Resistance",0}, {"Magic_Resistance",0}, {"Archery_Resistance",0},
		{"Accuracy",0},
		{"Evade",0},
		{"Critical_Chance",0},
		{"Critical_Damage",0}
	};	

    //****************************************//
   //****************************************//
  //*********TYPE GET_STAT_GENERIC**********//
 //****************************************//
//****************************************//


	private float Get_Stat_Generic<T> (T Change_Stat_Selected)
	{
		return Stat_Dictionary[Change_Stat_Selected.ToString()];
	}

	private void Get_Stat_Generic<T> (T Change_Stat_Selected, float Amount, bool MakeNumberEqualToAmount = false)
	{
		float TrueOrFalse;
		if (!Stat_Dictionary.TryGetValue(Change_Stat_Selected.ToString(),out TrueOrFalse)) Debug.LogError("This Class doesn't have the variable you inputed");
		if (Stat_Dictionary.TryGetValue(Change_Stat_Selected.ToString(),out TrueOrFalse))
		{
			if (MakeNumberEqualToAmount)
			{
				Stat_Dictionary[Change_Stat_Selected.ToString()] = Mathf.Floor(Amount);
				return;
			}
			Stat_Dictionary[Change_Stat_Selected.ToString()] += Mathf.Floor(Amount);
		}
	}

	private void Get_Stat_Generic<T> (T Change_Stat_Selected, float Amount, float Times_Tier_Formula_Float, bool MakeNumberEqualToAmount = false)
	{
		Amount *= Tier.Formula(Times_Tier_Formula_Float);
		Get_Stat_Generic(Change_Stat_Selected, Amount,MakeNumberEqualToAmount);
	}

	private void Get_Stat_Generic<T> (T Change_Stat_Selected, float Amount,  T Times_Tier_Formula_Stat, bool MakeNumberEqualToAmount = false)
	{
		Amount *= Tier.Formula(Get_Stat_Generic<string>(Times_Tier_Formula_Stat.ToString()));
		Get_Stat_Generic(Change_Stat_Selected, Amount,MakeNumberEqualToAmount);
	}

    //****************************************//
   //****************************************//
  //*************STRING GET_STAT************//
 //****************************************//
//****************************************//

	public float Get_Stat (string Change_Stat_Selected)
	{
		return Get_Stat_Generic<string>(Change_Stat_Selected);
	}
	
	public void Get_Stat (string Change_Stat_Selected, float Amount, bool MakeNumberEqualToAmount = false)
	{
		Get_Stat_Generic<string>(Change_Stat_Selected, Amount, MakeNumberEqualToAmount);
	}

	public void Get_Stat (string Change_Stat_Selected, float Amount, float Times_Tier_Formula_Float, bool MakeNumberEqualToAmount = false)
	{
		Get_Stat_Generic<string> (Change_Stat_Selected,Amount,Times_Tier_Formula_Float,MakeNumberEqualToAmount);
	}

	public void Get_Stat (string Change_Stat_Selected, float Amount, string Times_Tier_Formula_Stat, bool MakeNumberEqualToAmount = false)
	{
		Get_Stat_Generic<string> (Change_Stat_Selected,Amount,Times_Tier_Formula_Stat,MakeNumberEqualToAmount);
	}

    //****************************************//
   //****************************************//
  //***************STAT GET_STAT************//
 //****************************************//
//****************************************//

	public float Get_Stat (Stat Change_Stat_Selected)
	{
		return Get_Stat_Generic<Stat>(Change_Stat_Selected);
	}
	
	public void Get_Stat (Stat Change_Stat_Selected, float Amount, bool MakeNumberEqualToAmount = false)
	{
		Get_Stat_Generic<Stat>(Change_Stat_Selected, Amount, MakeNumberEqualToAmount);
	}

	public void Get_Stat (Stat Change_Stat_Selected, float Amount, float Times_Tier_Formula_Float, bool MakeNumberEqualToAmount = false)
	{
		Get_Stat_Generic<Stat> (Change_Stat_Selected,Amount,Times_Tier_Formula_Float,MakeNumberEqualToAmount);
	}

	public void Get_Stat (Stat Change_Stat_Selected, float Amount, Stat Times_Tier_Formula_Stat, bool MakeNumberEqualToAmount = false)
	{
		Get_Stat_Generic<Stat> (Change_Stat_Selected,Amount,Times_Tier_Formula_Stat,MakeNumberEqualToAmount);
	}
}