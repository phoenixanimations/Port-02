using UnityEngine;
using System.Collections;
namespace System_Control
{
	public enum Assign_Class {None, Melee, Magic, Archery};
	public enum Assign_Subclass {None, One_Handed, Two_Handed, Shield, Arrow, Bolt};
		
	class Tier
	{
		public static float Formula (float Tier_Number)
		{
			return 10 * (1 + ((Tier_Number/10) - Mathf.Floor(Tier_Number/10))) * (Mathf.Pow(2, Mathf.Floor(Tier_Number/10)));
		}
	}
}

