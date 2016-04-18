using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Editor;

[CustomEditor(typeof(xForm_Unlimited))]
public class xForm_Unlimited_GUI : Editor 
{
	public override void OnInspectorGUI ()
	{
		EditorGUILayout.HelpBox("When you equip this weapon you will by default equip Side_A. Only when the weapon is equipped can you switch to Side_B. There are two classes, both named Equipment_Foundation. The first is Side_A, the second Side_B.",MessageType.Info);
	}
}
