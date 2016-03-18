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
		{"Hitpoints", 0f},
		{"Melee_Damage",0f}, {"Magic_Damage",0f}, {"Archery_Damage",0f},
		{"Melee_Resistance",0f}, {"Magic_Resistance",0f}, {"Archery_Resistance",0f},
		{"Accuracy",0f}, {"Evade",0f},
		{"Critical_Chance",0f}, {"Critical_Damage",0f},
		{"Energy",0f},
		{"Distance",1f},
		{"Minimum_Distance",0f},
		{"Maximum_Distance",0f},
		{"Number_Of_Attacks",1f},
		{"Hitpoints_Level",1f},{"Melee_Level",1f},{"Magic_Level",1f},{"Archery_Level",1f},
		{"Movement", 0f},
		{"Knockback",0f}
	};

	[HideInInspector]
	public List <float> Stat_Multiplier = new List<float>(new float[200]); 
																		    
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

	private float Get_Stat_Generic<T> (T Change_Stat_Selected)
	{
		return Stat_Dictionary[Change_Stat_Selected.ToString()];
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

    //****************************************//
   //****************************************//
  //*****************LEVEL UP***************//
 //****************************************//
//****************************************//

	public virtual void Level_Up(Stat Stat, float Amount = 1, bool SetLevel = false)
	{
		if (Stat == Stat.Melee_Level || Stat == Stat.Magic_Level || Stat == Stat.Archery_Level)
		{
			Get_Stat(Stat,Amount,SetLevel);
			return;
		}				
	}
}