using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;

[CustomEditor(typeof(Equipment_Foundation))]
public class Weapon_GUI : Editor 
{
	private enum Limit_Stats {Hitpoints, Melee_Damage,Magic_Damage,Archery_Damage,Accuracy,Evade};
	Limit_Stats Limiting_Stats;
	static bool Damage_Foldout = false;
//	static bool Assign_Stats_Foldout = false;
	static bool Config_Foldout = false;
	
	float Amount;
//	bool Set_Stat = true;
	bool Left, Upper_Left, Up,   Upper_Right, Right,
		 	   Lower_Left, Down, Lower_Right, Center;
	bool Diamond, Plus_Shaped, Square;

	Stat Add_Assign_Stat;
	float Add_Amount;
	
	bool Not_Armor = true;

 	SerializedProperty 	Status;

	public void OnEnable()
    {
		Status = serializedObject.FindProperty("Status");
    }

	public override void OnInspectorGUI()
    {
		GUI.changed = false;
		serializedObject.Update();
		Equipment_Foundation Weapon_Editor = (Equipment_Foundation)target;
     	Weapon_Editor.Name = EditorGUILayout.TextField("Name", Weapon_Editor.Name);
		Weapon_Editor.Description = EditorGUILayout.TextField("Description", Weapon_Editor.Description);
		
		Weapon_Editor.Class = (Assign_Class)EditorGUILayout.EnumPopup("Class",Weapon_Editor.Class);
		Weapon_Editor.Subclass = (Assign_Subclass)EditorGUILayout.EnumPopup("Subclass",Weapon_Editor.Subclass);
		
		if (Weapon_Editor.Subclass == Assign_Subclass.Armor)
		{
			Not_Armor = false;
		}		

		if (Not_Armor)
		{
			Config_Foldout = EditorGUILayout.Foldout(Config_Foldout, "Config");
	
			if (Config_Foldout)
			{ 
				Weapon_Editor.Stats_Dictionary[Stat.Number_Of_Attacks.ToString()] = EditorGUILayout.FloatField("Number Of Attacks", Weapon_Editor.Get_Stat(Stat.Number_Of_Attacks));
				Weapon_Editor.Stats_Dictionary[Stat.Minimum_Distance.ToString()] = EditorGUILayout.FloatField("Minimum Distance", Weapon_Editor.Get_Stat(Stat.Number_Of_Attacks));
				Weapon_Editor.Stats_Dictionary[Stat.Maximum_Distance.ToString()] = EditorGUILayout.FloatField("Maximum Distance", Weapon_Editor.Get_Stat(Stat.Number_Of_Attacks));

//				EditorGUILayout.BeginHorizontal ();
//				Upper_Left = EditorGUILayout.Toggle(Upper_Left,GUILayout.Width(15f));
//				Up = EditorGUILayout.Toggle(Up,GUILayout.Width(15f));
//				Upper_Right = EditorGUILayout.Toggle(Upper_Right,GUILayout.Width(124f));
//				Diamond = EditorGUILayout.Toggle(Diamond,GUILayout.Width(15f));
//				EditorGUILayout.LabelField("Diamond", GUILayout.Width(60f));
//				EditorGUILayout.EndHorizontal ();
//	
//				EditorGUILayout.BeginHorizontal ();
//				Left = EditorGUILayout.Toggle(Left,GUILayout.Width(15f));
//				Center = EditorGUILayout.Toggle(Center,GUILayout.Width(15f));
//				Right = EditorGUILayout.Toggle(Right,GUILayout.Width(124f));
//				Square = EditorGUILayout.Toggle(Square,GUILayout.Width(15f));			
//				EditorGUILayout.LabelField("Square");
//				EditorGUILayout.EndHorizontal ();
//	
//				EditorGUILayout.BeginHorizontal ();
//				Lower_Left = EditorGUILayout.Toggle(Lower_Left,GUILayout.Width(15f));
//				Down = EditorGUILayout.Toggle(Down,GUILayout.Width(15f));
//				Lower_Right = EditorGUILayout.Toggle(Lower_Right,GUILayout.Width(124f));
//				Plus_Shaped = EditorGUILayout.Toggle(Plus_Shaped,GUILayout.Width(15f));
//				EditorGUILayout.LabelField("Plus");
//				EditorGUILayout.EndHorizontal ();
			}
		}

		Damage_Foldout = EditorGUILayout.Foldout(Damage_Foldout, "Stats");

		if (Damage_Foldout)
		{
			Weapon_Editor.Level = EditorGUILayout.FloatField("Tier", Weapon_Editor.Level);

		    EditorGUILayout.LabelField("Hitpoints", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Display_Stat("Hitpoints",Weapon_Editor,Stat.Hitpoints);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;

		    EditorGUILayout.LabelField("Damage", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Display_Stat("Melee Damage",Weapon_Editor,Stat.Melee_Damage);
			Display_Stat("Magic Damage",Weapon_Editor,Stat.Magic_Damage);
			Display_Stat("Archery Damage",Weapon_Editor,Stat.Archery_Damage);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
				
			EditorGUILayout.LabelField("Accuracy", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Display_Stat("Accuracy",Weapon_Editor,Stat.Accuracy);
			Display_Stat("Evade",Weapon_Editor,Stat.Evade);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;

			EditorGUILayout.LabelField("Critical", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Weapon_Editor.Stats_Dictionary[Stat.Critical_Damage.ToString()] = EditorGUILayout.FloatField("Critical Damage", Weapon_Editor.Get_Stat(Stat.Critical_Damage));
			Weapon_Editor.Stats_Dictionary[Stat.Critical_Chance.ToString()] = EditorGUILayout.FloatField("Critical Chance", Weapon_Editor.Get_Stat(Stat.Critical_Chance));
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
			
			EditorGUILayout.LabelField("Resistance", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Weapon_Editor.Stats_Dictionary[Stat.Melee_Resistance.ToString()] = EditorGUILayout.FloatField("Melee Resistance", Weapon_Editor.Get_Stat(Stat.Melee_Resistance));
			Weapon_Editor.Stats_Dictionary[Stat.Magic_Resistance.ToString()] = EditorGUILayout.FloatField("Magic Resistance", Weapon_Editor.Get_Stat(Stat.Magic_Resistance));
			Weapon_Editor.Stats_Dictionary[Stat.Archery_Resistance.ToString()] = EditorGUILayout.FloatField("Archery Resistance", Weapon_Editor.Get_Stat(Stat.Archery_Resistance));
		    EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		}
		EditorGUILayout.PropertyField(Status,true);
		serializedObject.ApplyModifiedProperties();			
    }
	
	private void Display_Stat (string Name, Equipment_Foundation Weapon_Editor, Stat Choose_Stat) 
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.FloatField(Name,Weapon_Editor.Get_Stat(Choose_Stat));
		Weapon_Editor.Stat_Multiplier[(int)Choose_Stat] = EditorGUILayout.FloatField(Weapon_Editor.Stat_Multiplier[(int)Choose_Stat],GUILayout.Width(50f));
		EditorGUILayout.EndHorizontal ();
		Weapon_Editor.Level_Up(Choose_Stat);
	}
}