using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Editor;
using System.Linq;

[CustomEditor(typeof(Equipment_Foundation))]
public class Equipment_Foundation_GUI : Equipment_Foundation_Stats_Warning_GUI 
{
	public static bool Damage_Foldout;
	public static bool Config_Foldout;
	public static bool AOE_Foldout;
	public static bool Note_Foldout;
	SerializedProperty Class;
	SerializedProperty Subclass;
	SerializedProperty Passives;
	SerializedProperty Defect;
	enum Menu {Default, AOE};
	Menu Select;

	public virtual void OnEnable()
	{
		Class = serializedObject.FindProperty("Class");
		Subclass = serializedObject.FindProperty("Subclass");
		Passives = serializedObject.FindProperty("Passives");
		Defect = serializedObject.FindProperty("Defect");
		
	}

	public override void OnInspectorGUI ()
	{
		Equipment_Foundation Weapon_Editor = (Equipment_Foundation)target;
		if (Weapon_Editor.Class == Assign_Class.xForm)
		{
			xForm_Warning(ref Weapon_Editor);		
			return;
		}
		Display_All_Stats(ref Weapon_Editor);	
		serializedObject.ApplyModifiedProperties();			
    }

	private void xForm_Warning (ref Equipment_Foundation Weapon_Editor)
	{
		Layout.Text("Name", ref Weapon_Editor.Name);		
		Layout.Text("Description", ref Weapon_Editor.Description);
		EditorGUILayout.PropertyField(Class,true);
		EditorGUILayout.HelpBox("Please use Create -> xForm 1 or Create -> xForm 2. Equipment_Foundation (this class) does not support xForms",MessageType.Warning);
		serializedObject.ApplyModifiedProperties();
	}

	private void Display_Stat (string Name, ref Equipment_Foundation Weapon_Editor, Stat Choose_Stat) 
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.FloatField(Name,Weapon_Editor.Get_Stat(Choose_Stat));
		Weapon_Editor.Stat_Multiplier[(int)Choose_Stat] = EditorGUILayout.FloatField(Weapon_Editor.Stat_Multiplier[(int)Choose_Stat],GUILayout.Width(50f));
		EditorGUILayout.EndHorizontal ();
		Weapon_Editor.Level_Up(Choose_Stat);
	}
 
	private void Display_Config_Foldout (ref Equipment_Foundation Weapon_Editor)
	{
		Config_Foldout = EditorGUILayout.Foldout(Config_Foldout, "Config");

		if (Config_Foldout)
		{
			if (Weapon_Editor.Class == Assign_Class.Melee || Weapon_Editor.Class == Assign_Class.Magic || Weapon_Editor.Class == Assign_Class.Archery)
			{
				Layout.Float("Energy",ref Weapon_Editor.Stat_Dictionary,Stat.Energy);
			}
			Layout.Float("Number of Attacks",ref Weapon_Editor.Stat_Dictionary,Stat.Number_Of_Attacks);
			Layout.Float("Minimum Distance",ref Weapon_Editor.Stat_Dictionary,Stat.Minimum_Distance);
			Layout.Float("Maximum Distance",ref Weapon_Editor.Stat_Dictionary,Stat.Maximum_Distance);
			Layout.Float("Movement", ref Weapon_Editor.Stat_Dictionary, Stat.Movement);
			Layout.Float("Jump", ref Weapon_Editor.Stat_Dictionary, Stat.Jump);
			Layout.Float("Knockback", ref Weapon_Editor.Stat_Dictionary, Stat.Knockback);
		}
	}

	private void Display_AOE_Foldout (ref Equipment_Foundation Weapon_Editor)
	{
		AOE_Foldout = EditorGUILayout.Foldout(AOE_Foldout, "Area of Effect");
		if (AOE_Foldout)
		{
			EditorGUILayout.BeginHorizontal();
			Layout.Float("Area of Effect",ref Weapon_Editor.Stat_Dictionary,Stat.Area_Of_Effect);
			if(GUILayout.Button("Show",GUILayout.Height(14f)))
		  	{
				float Number_Of_Booleans = Mathf.Pow(Weapon_Editor.Get_Stat(Stat.Area_Of_Effect),2f);
				Weapon_Editor.AOE_Pattern = new List<bool>(new bool[(int)Number_Of_Booleans]);
			} 	
			EditorGUILayout.EndHorizontal();
			if (Weapon_Editor.Get_Stat(Stat.Area_Of_Effect) > 0)
			{
				EditorGUILayout.HelpBox("The center represents the enemy you clicked on to attack. If the center isn't 'checked' then when you click on someone you will not hit them. Anything checked off around the center is considered AOE damage.",MessageType.Warning);
			}
	
			if (Weapon_Editor.Get_Stat(Stat.Area_Of_Effect) > 15)
			{
				Layout.Label("AOE is too high for the editor contact me if you want to");
				Layout.Label("do something nuts.");
				return;
			}
	
			if (Mathf.Sqrt((float)Weapon_Editor.AOE_Pattern.Count) != Weapon_Editor.Get_Stat(Stat.Area_Of_Effect)) return;
			
			EditorGUILayout.BeginHorizontal();
			for (float i = 0; i < Weapon_Editor.AOE_Pattern.Count; i++) 
			{
				if (i/Weapon_Editor.Get_Stat(Stat.Area_Of_Effect) == Mathf.Floor(i/Weapon_Editor.Get_Stat(Stat.Area_Of_Effect)) && i != 0)
				{
				   EditorGUILayout.EndHorizontal();
				   EditorGUILayout.BeginHorizontal();
				}
				Weapon_Editor.AOE_Pattern[(int)i] = EditorGUILayout.Toggle(Weapon_Editor.AOE_Pattern[(int)i],GUILayout.Width(10f));
			}
			EditorGUILayout.EndHorizontal();
		}
	}	

	private void Display_Damage_Foldout (ref Equipment_Foundation Weapon_Editor)
	{
			if (Weapon_Editor.Class == Assign_Class.Armor || Weapon_Editor.Class == Assign_Class.Shield || 
				Weapon_Editor.Class == Assign_Class.xForm)
			{
			    EditorGUILayout.LabelField("Hitpoints", EditorStyles.boldLabel);
				EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
				EditorGUILayout.BeginHorizontal ();
				EditorGUILayout.FloatField("Hitpoints",Weapon_Editor.Get_Stat(Stat.Hitpoints));
				EditorGUILayout.LabelField("x" + Weapon_Editor.Level.ToString(),GUILayout.Width(48f));
				Weapon_Editor.Stat_Multiplier[(int)Stat.Hitpoints] = EditorGUILayout.FloatField(Weapon_Editor.Stat_Multiplier[(int)Stat.Hitpoints],GUILayout.Width(50f));
				EditorGUILayout.EndHorizontal ();
				Weapon_Editor.Level_Up(Stat.Hitpoints);
				EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
			}
			else 
			{
				Check_For_Wrong_Stats(ref Weapon_Editor,Stat.Hitpoints);
			}
			
 			EditorGUILayout.LabelField("Damage", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Display_Stat("Melee Damage",ref Weapon_Editor,Stat.Melee_Damage);
			Display_Stat("Magic Damage",ref Weapon_Editor,Stat.Magic_Damage);
			Display_Stat("Archery Damage",ref Weapon_Editor,Stat.Archery_Damage);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
				
			EditorGUILayout.LabelField("Accuracy", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Display_Stat("Accuracy",ref Weapon_Editor,Stat.Accuracy);
			Display_Stat("Evade",ref Weapon_Editor,Stat.Evade);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;

			EditorGUILayout.LabelField("Critical", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Layout.Float("Critical Damage", ref Weapon_Editor.Stat_Dictionary,Stat.Critical_Damage);
			Layout.Float("Critical Chance", ref Weapon_Editor.Stat_Dictionary,Stat.Critical_Chance);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
			
			EditorGUILayout.LabelField("Resistance", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Layout.Float("Melee Resistance", ref Weapon_Editor.Stat_Dictionary,Stat.Melee_Resistance);
			Layout.Float("Magic Resistance", ref Weapon_Editor.Stat_Dictionary,Stat.Magic_Resistance);
			Layout.Float("Archery Resistance", ref Weapon_Editor.Stat_Dictionary,Stat.Archery_Resistance);
		    EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
	}

	protected virtual void Display_Class_Stats (ref Equipment_Foundation Weapon_Editor)
	{
		EditorGUILayout.PropertyField(Class,true);
		if (Weapon_Editor.Class != Assign_Class.Armor)
		{
			EditorGUILayout.PropertyField(Subclass,true);
		}

		if (Weapon_Editor.Class != Assign_Class.Ammo && (Weapon_Editor.Subclass == Assign_Subclass.Arrow || Weapon_Editor.Subclass == Assign_Subclass.Bolt))
		{
			EditorGUILayout.HelpBox(Weapon_Editor.Class + " does not support the '" + Weapon_Editor.Subclass + "' subclass",MessageType.Warning);
		}
		
		if (Weapon_Editor.Class == Assign_Class.Melee ||
			Weapon_Editor.Class == Assign_Class.Magic ||
			Weapon_Editor.Class == Assign_Class.Archery ||
			Weapon_Editor.Class == Assign_Class.Shield)
		{
			Layout.Bool("Two Handed",ref Weapon_Editor.Two_Handed);
		}
		else
		{
			if (Weapon_Editor.Two_Handed)
			{
				EditorGUILayout.HelpBox("Two Handed is true",MessageType.Warning);
			}
		}
		Default_Stats(ref Weapon_Editor);
	}

	protected virtual void Display_Passive()
	{
		EditorGUILayout.PropertyField(Passives,true);
	}
	
	private void Notes (Equipment_Foundation Weapon_Editor)
	{
		Note_Foldout = EditorGUILayout.Foldout(Note_Foldout, "Notes");
		if (Note_Foldout)
		{
			EditorGUILayout.HelpBox("Use / to make a newline. When typing it is possible to type everything out first like: line1/line2/line3/etc and then press return.",MessageType.Info);
			Layout.Text(string.Empty,ref Weapon_Editor.Equipment_Notes,GUILayout.MaxHeight(200f));
			if (Weapon_Editor.Equipment_Notes.Contains("/") && !string.IsNullOrEmpty(Weapon_Editor.Equipment_Notes))
			{
				Weapon_Editor.Equipment_Notes = Weapon_Editor.Equipment_Notes.Replace("/","\n");
			}
		}
	}

	protected void Display_All_Stats (ref Equipment_Foundation Equipment_Foundation_Editor)
	{
		Layout.Text("Name", ref Equipment_Foundation_Editor.Name);		
		Layout.Text("Description", ref Equipment_Foundation_Editor.Description);
		Display_Class_Stats(ref Equipment_Foundation_Editor);	

		if (Equipment_Foundation_Editor.Class != Assign_Class.Ammo &&
			Equipment_Foundation_Editor.Subclass != Assign_Subclass.Arrow && 
			Equipment_Foundation_Editor.Subclass != Assign_Subclass.Bolt)
		{
			Display_AOE_Foldout(ref Equipment_Foundation_Editor);
			Display_Config_Foldout(ref Equipment_Foundation_Editor);
			Damage_Foldout = EditorGUILayout.Foldout(Damage_Foldout, "Stats");
			if (Damage_Foldout)
			{
				Layout.Float("Tier",ref Equipment_Foundation_Editor.Level);
				Display_Damage_Foldout(ref Equipment_Foundation_Editor);
			}
		}
		else
		{
			Display_Stat("Archery Damage",ref Equipment_Foundation_Editor,Stat.Archery_Damage);
			Layout.Float("Accuracy",ref Equipment_Foundation_Editor.Stat_Dictionary,Stat.Accuracy);
			foreach (Stat All_Stats in System.Enum.GetValues(typeof(Stat)))
			{
				if (All_Stats != Stat.Archery_Damage && All_Stats != Stat.Accuracy)
				{
					Check_For_Wrong_Stats(ref Equipment_Foundation_Editor,All_Stats);
				}
			}
		}

		if (Equipment_Foundation_Editor.Class != Assign_Class.Archery &&
			Equipment_Foundation_Editor.Class != Assign_Class.Magic)
		{
			EditorGUILayout.PropertyField(Defect,true);
		}
		else 
		{
			if (Equipment_Foundation_Editor.Defect != System_Control.Defect.None)
			{
				EditorGUILayout.HelpBox("Defect is not set to None, if this is expected please contact me",MessageType.Warning);
			}
		}
		Display_Passive();
		Notes(Equipment_Foundation_Editor);
	}
}