using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System_Control;

[System.Serializable]
public class Serialize_Dictionary : SerializableDictionary<string, float> {}

public class Stats : Raycast
{
	public string Name;
	public string Description;
	
	[HideInInspector]
	[SerializeField]	
	public Serialize_Dictionary Stat_Dictionary = new Serialize_Dictionary()
	{
		{"Hitpoints",0},
		{"Melee_Damage",0f}, 	{"Magic_Damage",0}, 	{"Archery_Damage",0},
		{"Melee_Resistance",0}, {"Magic_Resistance",0}, {"Archery_Resistance",0},
		{"Accuracy",0},
		{"Evade",0},
		{"Critical_Chance",0},
		{"Critical_Damage",0}, 
		{"Energy", 0f}, 
		{"Distance", 1f},

		{"Hitpoints_Level", 1f}, {"Melee_Level",1f},{"Magic_Level",1f},{"Archery_Level",1f}, 

		{"Item_Tier",1f}, {"Number_Of_Attacks", 1f}
	};	

	public virtual void Assign_Stats() 
	{
		Raycast_Stats();
	}

	protected override void Start ()
	{
		base.Start ();
		Assign_Stats();
	}

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