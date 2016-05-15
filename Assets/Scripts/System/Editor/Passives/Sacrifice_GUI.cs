using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Extensions;
using System_Control.Editor;
using System.Linq;

[CustomEditor(typeof(Sacrifice))]
public class Sacrifice_GUI : Status_Foundation_GUI 
{
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		EditorGUILayout.HelpBox("I forgot what this does please write what it does",MessageType.Warning);
		Sacrifice Sacrifice_Editor = (Sacrifice)target;
		Notes((Status_Foundation)Sacrifice_Editor);
	}
}
