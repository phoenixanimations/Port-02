using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Equipment_Foundation_Stats_Warning_GUI : Equipment_Foundation_Default_Stats_GUI 
{
	public void Check_For_Wrong_Stats (ref Equipment_Foundation Weapon_Editor, Stat Select_Stat)
	{
		if (Weapon_Editor.Get_Stat(Select_Stat) != 0)
		{
			EditorGUILayout.HelpBox(Select_Stat.ToString() + " is not equal to zero, if this is okay contact me",MessageType.Warning);
		}
	}
}
