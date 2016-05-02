using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Editor;

[CustomEditor(typeof(Creature))]
public class Creature_GUI : Editor 
{
	SerializedProperty AI;
	SerializedProperty Passives;
	SerializedProperty Actives;
	SerializedProperty Defects;

	enum Menu {Stats,Equipment,Debug};
	Menu Creature_Menu;

	Equipment_Foundation Equipped;

	public  void OnEnable()
	{
		 AI = serializedObject.FindProperty("Assign_AI");
		 Passives = serializedObject.FindProperty("Passives");
		 Actives = serializedObject.FindProperty("Actives");
		 Defects = serializedObject.FindProperty("Defects");
	}

	public override void OnInspectorGUI ()
	{
		Creature Creature_Editor = (Creature)target;
		Creature_Menu = (Menu)EditorGUILayout.EnumPopup(Creature_Menu,GUILayout.Width(70f));

		if (Creature_Menu == Menu.Stats)
		{
			Stats(ref Creature_Editor);
		}

		if (Creature_Menu == Menu.Equipment)
		{
			Equipment(ref Creature_Editor);
		}

		if (Creature_Menu == Menu.Debug)
		{
			Debug(ref Creature_Editor);
		}
		
		serializedObject.ApplyModifiedProperties();	
	}

	static bool Level_Foldout;
	private void Stats (ref Creature Creature_Editor)
	{
		Layout.Text("Name",ref Creature_Editor.Name);	
		Layout.Text("Description",ref Creature_Editor.Description);	
		Level_Foldout = EditorGUILayout.Foldout(Level_Foldout, "Levels");
		if (Level_Foldout)
		{
			EditorGUILayout.BeginHorizontal();
			Layout.Float("Change All Levels", ref Creature_Editor.Change_All_Levels);
			if(GUILayout.Button("Confirm",GUILayout.Height(15f),GUILayout.Width(58f)))
			{
				Creature_Editor.Level_Up(Stat.Hitpoints_Level,Creature_Editor.Change_All_Levels,true);
				Creature_Editor.Level_Up(Stat.Melee_Level,Creature_Editor.Change_All_Levels,true);
				Creature_Editor.Level_Up(Stat.Magic_Level,Creature_Editor.Change_All_Levels,true);
				Creature_Editor.Level_Up(Stat.Archery_Level,Creature_Editor.Change_All_Levels,true);
				Level_Up_Equipment (ref Creature_Editor.Slot[(int)Assign_Slot.Primary_Hand], Creature_Editor.Change_All_Levels);
				Level_Up_Equipment (ref Creature_Editor.Slot[(int)Assign_Slot.Secondary_Hand], Creature_Editor.Change_All_Levels);
				Level_Up_Equipment (ref Creature_Editor.Slot[(int)Assign_Slot.Armor], Creature_Editor.Change_All_Levels);
			} 
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.LabelField("Combat",EditorStyles.boldLabel);
			EditorGUI.indentLevel++;
			EditorGUILayout.FloatField("Combat Level",Creature_Editor.Combat_Level());
			Layout.Float("Hitpoints Level",ref Creature_Editor.Stat_Dictionary,Stat.Hitpoints_Level);
			Layout.Float("Melee Level",ref Creature_Editor.Stat_Dictionary,Stat.Melee_Level);
			Layout.Float("Magic Level",ref Creature_Editor.Stat_Dictionary,Stat.Magic_Level);
			Layout.Float("Archery Level",ref Creature_Editor.Stat_Dictionary,Stat.Archery_Level);
			EditorGUI.indentLevel--;
			EditorGUILayout.LabelField("Equipment",EditorStyles.boldLabel);
			EditorGUI.indentLevel++;
			Layout.Float("Primary Hand",ref Creature_Editor.Slot[(int)Assign_Slot.Primary_Hand].Level);
			Layout.Float("Secondary Hand",ref Creature_Editor.Slot[(int)Assign_Slot.Secondary_Hand].Level);
			Layout.Float("Armor",ref Creature_Editor.Slot[(int)Assign_Slot.Armor].Level);
			EditorGUI.indentLevel--;
		}
		EditorGUILayout.PropertyField(Passives,true);
		EditorGUILayout.PropertyField(Actives,true);
		EditorGUILayout.PropertyField(Defects,true);
	}

	private void Level_Up_Equipment(ref Equipment_Foundation Equipment, float Change_All_Levels)
	{
		Equipment.Level = Change_All_Levels;
		Equipment.Level_Up(Stat.Hitpoints);
		Equipment.Level_Up(Stat.Melee_Damage);
		Equipment.Level_Up(Stat.Magic_Damage);
		Equipment.Level_Up(Stat.Archery_Damage);
		Equipment.Level_Up(Stat.Accuracy);
		Equipment.Level_Up(Stat.Evade);
	}	

	Assign_Slot Slot;
	private void Equipment (ref Creature Creature_Editor)
	{
		EditorGUILayout.ObjectField("Primary Hand",Creature_Editor.Slot[(int)Assign_Slot.Primary_Hand],typeof(Equipment_Foundation),true);
		EditorGUILayout.ObjectField("Secondary Hand",Creature_Editor.Slot[(int)Assign_Slot.Secondary_Hand],typeof(Equipment_Foundation),true);
		EditorGUILayout.ObjectField("Armor",Creature_Editor.Slot[(int)Assign_Slot.Armor],typeof(Equipment_Foundation),true);
		EditorGUILayout.ObjectField("Arrow",Creature_Editor.Slot[(int)Assign_Slot.Arrow],typeof(Equipment_Foundation),true);
	
		EditorGUILayout.BeginHorizontal ();
		Equipped = (Equipment_Foundation)EditorGUILayout.ObjectField("Equip",Equipped,typeof(Equipment_Foundation),true);
		Slot = (Assign_Slot)EditorGUILayout.EnumPopup(Slot);
		if(GUILayout.Button("Yield",GUILayout.Width(45f),GUILayout.Height(14f)))
		{
			Creature_Editor.Equip(Equipped,Slot);
		}
		if(GUILayout.Button("Reset",GUILayout.Width(45f),GUILayout.Height(14f)))
		{
			Creature_Editor.Slot[(int)Assign_Slot.Primary_Hand] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Hand_1H.prefab",typeof(Equipment_Foundation));
			Creature_Editor.Slot[(int)Assign_Slot.Secondary_Hand] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Hand_1H.prefab",typeof(Equipment_Foundation));
			Creature_Editor.Slot[(int)Assign_Slot.Armor] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Armor.prefab",typeof(Equipment_Foundation));
			Creature_Editor.Slot[(int)Assign_Slot.Arrow] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Arrow.prefab",typeof(Equipment_Foundation));
		}
		EditorGUILayout.EndHorizontal ();
	}

	private void Debug (ref Creature Creature_Editor)
	{
		Layout.Bool("Player", ref Creature_Editor.Player);
		Layout.Float("Storey", ref Creature_Editor.Storey);
		Layout.Float("Height", ref Creature_Editor.Height);
		EditorGUILayout.PropertyField(AI,true);
	}
}