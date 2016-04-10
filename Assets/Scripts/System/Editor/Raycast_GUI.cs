using UnityEngine;
using System.Collections;
using UnityEditor;
using System_Control;

[CustomEditor(typeof(Raycast))]
public class Raycast_GUI : Editor 
{
	bool RaycastLineOnandOff;

	public override void OnInspectorGUI ()
	{
		Raycast RaycastEditor = (Raycast)target;
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Location",GUILayout.Width(60f));

		EditorGUILayout.LabelField("x",GUILayout.Width(10f));
		RaycastEditor.x = EditorGUILayout.FloatField(RaycastEditor.x,GUILayout.Width(45f));

		EditorGUILayout.LabelField("y",GUILayout.Width(10f));
		RaycastEditor.y = EditorGUILayout.FloatField(RaycastEditor.y,GUILayout.Width(45f));

		RaycastLineOnandOff = EditorGUILayout.Toggle(RaycastLineOnandOff,GUILayout.Width(11f));
		EditorGUILayout.LabelField("Show",GUILayout.Width(40f));
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField("Length",GUILayout.Width(74f));
		RaycastEditor.Length = EditorGUILayout.FloatField(RaycastEditor.Length,GUILayout.Width(45f));
		EditorGUILayout.EndHorizontal ();
	}

	public void OnSceneGUI() 
	{
		Raycast RaycastEditor = (Raycast)target;
		if (RaycastLineOnandOff)
		{
			DrawLine(RaycastEditor,RaycastEditor.Length);
		}
		SceneView.RepaintAll(); 
	}

	void DrawLine(Raycast RaycastEditor, float Length)
	{
		Vector2 Position = RaycastEditor.Position();
		float x = Length;
		float y = 0f;
		Handles.color = Color.red;
		Handles.DrawLine(Position,new Vector2(Position.x + x,Position.y + y));
	}
}