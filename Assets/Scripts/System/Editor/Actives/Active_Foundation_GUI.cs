using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System_Control.Extensions;
using System_Control.Editor;

[CustomEditor (typeof(Active_Foundation))]
public class Active_Foundation_GUI : Editor
{
	SerializedProperty Passives;

	public  void OnEnable()
	{
		 Passives = serializedObject.FindProperty("Passives");
	}

	public override void OnInspectorGUI ()
	{
		Active_Foundation Active_Editor = (Active_Foundation)target;
		Stats (ref Active_Editor);
	}

	private void Stats (ref Active_Foundation Active_Editor)
	{
		Layout.Text ("Name", ref Active_Editor.Name);	
		Layout.Text ("Description", ref Active_Editor.Description);
		Active_Formula (ref Active_Editor);
		EditorGUILayout.PropertyField(Passives,true);
		serializedObject.ApplyModifiedProperties();	
	}

	private void Active_Formula (ref Active_Foundation Active_Editor)
	{
		Layout.Float ("Energy", ref Active_Editor.Stat_Dictionary, Stat.Energy);
		Layout.Float ("Scale Value", ref Active_Editor.Scale_Value);
		string Formula = "Formula: 100 + 5 • ((" + Active_Editor.Scale_Value + " • 0.1 • " + Active_Editor.Get_Stat (Stat.Energy) + ") + (0.5 • " + Active_Editor.Get_Stat (Stat.Energy) + ")^2 - 0.5 • (0.1 • " + Active_Editor.Get_Stat (Stat.Energy) + ")) = " + Active_Editor.Damage_Bonus_Multiplier;  
		Active_Editor.Damage_Bonus_Multiplier = Active_Editor.Calculate_Bonus_Multipler();
		EditorGUILayout.HelpBox (Formula, MessageType.Info);
	}
}