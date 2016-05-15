using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Extensions;
using System_Control.Editor;
using System.Linq;

[CustomEditor(typeof(Status_Foundation))]
public class Status_Foundation_GUI : Editor 
{
	protected bool Show_When_To_Activate;
	
	public virtual void OnEnable()
	{
		Show_When_To_Activate = false;
	}

	public override void OnInspectorGUI ()
	{
		Status_Foundation Status_Editor = (Status_Foundation)target;
		Layout.Text("Name",ref Status_Editor.Name);
		Layout.Text("Description",ref Status_Editor.Description);
		if (Show_When_To_Activate)
		{
			Status_Editor.When_To_Activate = (State)EditorGUILayout.EnumPopup("When to Activate",Status_Editor.When_To_Activate);
		}
	} 

	protected void Notes (Status_Foundation Status_Editor)
	{
		EditorGUILayout.HelpBox("Use / to make a newline. When typing it is possible to type everything out first like: line1/line2/line3/etc and then press return.",MessageType.Info);
		Layout.Text(string.Empty,ref Status_Editor.Status_Notes,GUILayout.MaxHeight(200f));
		if (Status_Editor.Status_Notes.Contains("/") && !string.IsNullOrEmpty(Status_Editor.Status_Notes))
		{
			Status_Editor.Status_Notes = Status_Editor.Status_Notes.Replace("/","\n");
		}
	}
}
