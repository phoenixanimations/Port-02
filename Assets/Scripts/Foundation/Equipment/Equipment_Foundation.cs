using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Equipment_Foundation : Stats 
{
	public Assign_Class Class;
	public Assign_Subclass Subclass;
	public List <Status_Foundation> Passives = new List<Status_Foundation>();	
	public enum Select_AOE_Pattern_Enum {Square, Diamond, Cross};
	public Select_AOE_Pattern_Enum Select_AOE_Pattern;
	public List<bool> AOE_Pattern = new List<bool>();
	public float Level;
	public Defect Defect;
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