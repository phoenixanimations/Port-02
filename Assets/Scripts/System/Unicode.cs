using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Unicode
{
	public sealed class Arrow 
	{
		static public string Left		     = '\u2190'.ToString();
		static public string Up				 = '\u2191'.ToString();
		static public string Right			 = '\u2192'.ToString();
		static public string Down			 = '\u2193'.ToString();
		static public string Left_Up		 = '\u2196'.ToString();
		static public string Right_Up		 = '\u2197'.ToString();
		static public string Right_Down 	 = '\u2198'.ToString();
		static public string Left_Down		 = '\u2199'.ToString();
		static public string[] Array = {Left,Up,Right,Down,Left_Up,Right_Up,Right_Down,Left_Down};
	}
}
