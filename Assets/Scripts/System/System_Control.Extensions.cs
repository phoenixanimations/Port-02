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

//		public static int Enum (this System.Type Cast_Enum)
//		{
//			return (int)Cast_Enum;
////			try 
////			{
////				return Current_List[(int)Enum];
////			} 
////			catch (System.Exception ex) 
////			{
////				Debug.LogError("Cannot convert Type to Enum");
////			}
//		}
	}
}



/*


public static TEnum ToEnum<TInput, TEnum>(this TInput value)
{
    Type type = typeof(TEnum);

    if (value == null)
    {
        throw new ArgumentException("Value is null or empty.", "value");
    }

    if (!type.IsEnum)
    {
        throw new ArgumentException("Enum expected.", "TEnum");
    }

    return (TEnum)Enum.Parse(type, value.ToString(), true);
}


*/