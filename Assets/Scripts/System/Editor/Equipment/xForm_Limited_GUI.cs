using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Editor;

[CustomEditor(typeof(xForm_Limited))]
public class xForm_Limited_GUI : Equipment_Foundation_GUI 
{
	SerializedProperty Passive_A_Side;
	SerializedProperty Passive_B_Side;

	public override void OnEnable ()
	{
		base.OnEnable ();
		Passive_A_Side = serializedObject.FindProperty("Passive_A_Side");
		Passive_B_Side = serializedObject.FindProperty("Passive_B_Side");
	}

	public override void OnInspectorGUI ()
	{
		xForm_Limited Weapon_Editor = (xForm_Limited)target;
		Equipment_Foundation Foundation = Weapon_Editor as Equipment_Foundation;
		Display_All_Stats(ref Foundation);
	}

	private void xForm_Class_Stats ()
	{
		xForm_Limited Weapon_Editor = (xForm_Limited)target;
		Layout.Label("Class");
		Weapon_Editor.Class_A_Side = (Assign_Class)EditorGUILayout.EnumPopup(Weapon_Editor.Class_A_Side);
		Weapon_Editor.Class_B_Side = (Assign_Class)EditorGUILayout.EnumPopup(Weapon_Editor.Class_B_Side);
		if (Weapon_Editor.Class_A_Side == Assign_Class.xForm || Weapon_Editor.Class_B_Side == Assign_Class.xForm)
		{
			Layout.Label("Don't assign an xForm an xForm class. It's already an xForm");
			Layout.Label("In the next version this option will be taken out.");
		}
	}

	private void xForm_Subclass_Stats ()
	{
		xForm_Limited Weapon_Editor = (xForm_Limited)target;
		Layout.Label("Subclass");
		Weapon_Editor.Subclass_A_Side = (Assign_Subclass)EditorGUILayout.EnumPopup(Weapon_Editor.Subclass_A_Side);
		Weapon_Editor.Subclass = Weapon_Editor.Subclass_A_Side;
		Weapon_Editor.Subclass_B_Side = (Assign_Subclass)EditorGUILayout.EnumPopup(Weapon_Editor.Subclass_B_Side);
	}

	protected override void Display_Class_Stats ()
	{
		Layout.Horizontal(xForm_Class_Stats);
		Layout.Horizontal(xForm_Subclass_Stats);
	}

	private void xForm_Passives ()
	{
		xForm_Limited Weapon_Editor = (xForm_Limited)target;
		EditorGUILayout.PropertyField(Passive_A_Side,true);
		Weapon_Editor.Passives = Weapon_Editor.Passive_A_Side;
		EditorGUILayout.PropertyField(Passive_B_Side,true);
	}

	protected override void Display_Passive ()
	{
		Layout.Horizontal(xForm_Passives);
		serializedObject.ApplyModifiedProperties();
	}
}