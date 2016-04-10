using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Editor;

[CustomEditor(typeof(xForm_Unlimited))]
public class xForm_Unlimited_GUI : Editor 
{
	public void OnEnable()
	{

	}	

	public override void OnInspectorGUI ()
	{
		
		Layout.Horizontal(Sentence_1);
		Layout.Horizontal(Sentence_2);
		Layout.Label("");
		Layout.Label("When you equip this weapon you will by default equip Side_A");
		Layout.Label("Only when the weapon is equipped can you switch to Side_B");
	}

	private void Sentence_1()
	{
		Layout.Label("There are two classes, both named",188f);
		EditorGUILayout.LabelField("Equipment_Foundation.",EditorStyles.boldLabel);
	}
	
	private void Sentence_2()
	{
		Layout.Label("The first is ",60f);
		EditorGUILayout.LabelField("Side_A.",EditorStyles.boldLabel,GUILayout.Width(45f));
		Layout.Label("The second is ",78f);
		EditorGUILayout.LabelField("Side_B.",EditorStyles.boldLabel);
	}
}
