using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System_Control;
using System_Control.Extensions;
using System_Control.Editor;
using System.Linq;

[CustomEditor(typeof(Siphon))]
public class Siphon_GUI : Status_Foundation_GUI
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		Siphon Siphon_Editor = (Siphon)target;
		Layout.Float("Siphon Energy Percent",ref Siphon_Editor.Siphon_Energy);
		if (Siphon_Editor.Siphon_Energy == 0)
		{
			Siphon_Editor.Siphon_Energy = 5f;
		}
	}
}