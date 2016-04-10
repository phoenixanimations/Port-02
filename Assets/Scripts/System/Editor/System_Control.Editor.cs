using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace System_Control.Editor
{
	public sealed class Layout
	{
		//*********************************//
	   //**************Label**************//
      //*********************************//
		public static void Label(string Name, params GUILayoutOption[] Options)
		{
			EditorGUILayout.LabelField(Name,Options);
		}
		public static void Label (string Name, float Width)
		{
			Label(Name,GUILayout.Width(Width));
		}
		//*********************************//
	   //***************Text**************//
      //*********************************//
		public static void Text (string Name, ref string StatusEditor, params GUILayoutOption[] Options)
		{
			StatusEditor = EditorGUILayout.TextField(Name,StatusEditor,Options);
		}

		public static void Text (string Name, ref string StatusEditor, float Width)
		{
			Text(Name,ref StatusEditor, GUILayout.Width(Width));
		} 
		//*********************************//
	   //****Enum: When To Activate*******//
      //*********************************//
		public static void WhenToActivate (string Name, ref State StatusEditor, params GUILayoutOption[] Options)
		{
			StatusEditor = (State)EditorGUILayout.EnumPopup(Name, StatusEditor,Options);
		}	

		public static void WhenToActivate (ref State StatusEditor, float Width)
		{
			WhenToActivate(string.Empty,ref StatusEditor,GUILayout.Width(Width));
		}

		public static void WhenToActivate (ref State StatusEditor)
		{
			WhenToActivate("When to Activate",ref StatusEditor);
		}
		//*********************************//
	   //***************Bool**************//
      //*********************************//
		public static void Bool (string Name, ref bool StatusEditor, params GUILayoutOption[] Options)
		{
			StatusEditor = EditorGUILayout.Toggle(Name,StatusEditor,Options);
		}
		
		public static void Bool (ref bool StatusEditor, params GUILayoutOption[] Options)
		{
			Bool(string.Empty,ref StatusEditor,Options);
		}

		public static void Bool (ref List<bool> StatusEditor,int BoolNumber, params GUILayoutOption[] Options)
		{
			StatusEditor[BoolNumber] = EditorGUILayout.Toggle(string.Empty,StatusEditor[BoolNumber],Options);
		}

		//*********************************//
	   //****************Int**************//
      //*********************************//
		public static void Int (string Name, ref int StatusEditor, params GUILayoutOption[] Options)
		{
			StatusEditor = EditorGUILayout.IntField(Name,StatusEditor,Options);
		}		

		public static void Int (ref int StatusEditor, params GUILayoutOption[] Options)
		{
			Int(string.Empty,ref StatusEditor,Options);
		}

		public static void Int (ref int StatusEditor, float Width)
		{
			Int(ref StatusEditor,GUILayout.Width(Width));
		}

		//*********************************//
	   //**************Float**************//
      //*********************************//
		public static void Float (string Name, ref float StatusEditor, params GUILayoutOption[] Options)
		{
			StatusEditor = EditorGUILayout.FloatField(Name,StatusEditor,Options);
		}

		public static void Float (ref float StatusEditor, params GUILayoutOption[] Options)
		{
			StatusEditor = EditorGUILayout.FloatField(string.Empty,StatusEditor,Options);
		}
		
		public static void Float (ref float StatusEditor, float Width)
		{
			StatusEditor = EditorGUILayout.FloatField(string.Empty,StatusEditor,GUILayout.Width(Width));
		}

		//*********************************//
	   //*****Float From List*************//
      //*********************************//
		public static void Float (string Name, ref List<float> StatusEditor,Stat ChooseStat, params GUILayoutOption[] Options)
		{
			StatusEditor[(int)ChooseStat] = EditorGUILayout.FloatField(Name,StatusEditor[(int)ChooseStat],Options);
		}

		//*********************************//
	   //************Vector 2*************//
      //*********************************//
		public static void Vector2 (string Name, ref Vector2 StatusEditor,params GUILayoutOption[] Options)
		{
			StatusEditor = EditorGUILayout.Vector2Field(Name,StatusEditor,Options);
		}

		public static void Vector2 (ref Vector2 StatusEditor,params GUILayoutOption[] Options)
		{
			Vector2(string.Empty,ref StatusEditor,Options);
		}

		public static void Vector2 (string Name, ref Vector2 StatusEditor,float Width)
		{
			Vector2(Name,ref StatusEditor,GUILayout.Width(Width));
		}

		//*********************************//
	   //***********Horizontal************//
      //*********************************//
		public static void Horizontal (System.Action Function)
		{
			EditorGUILayout.BeginHorizontal();
			Function(); 
			EditorGUILayout.EndHorizontal();
		}
	}

	public sealed class Start 
	{
		public static void Status (ref State WhenToActivate)
		{
			Layout.WhenToActivate(ref WhenToActivate);
		}
	}
}