namespace System_Control.Extensions
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	public static class More_Linq
	{
		public static float Multiple (this List<float> Current_List)
		{
			return Current_List.Aggregate((current,total) => current * total);
		}

		public static List <float> Zero (this List<float> Current_List)
		{
			return Current_List.Select(z => z = 0).ToList();
		}

		public static List <float> One (this List<float> Current_List)
		{
			return Current_List.Select(z => z = 1).ToList();
		}
		
		public static int toInt (this System.Enum Cast_Enum)
		{
			return System.Convert.ToInt32(Cast_Enum);
		}
	}
}