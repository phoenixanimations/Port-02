//using UnityEditor;
//using UnityEngine;
//using System_Control;
//
//[CustomPropertyDrawer(typeof(Equipment_Foundation))]
//public class ColorPointDrawer : PropertyDrawer 
//{
//	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
//	{
//		return Screen.width < 333 ? (16f + 18f) : 16f;
//	}
//
//	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
//	{
//		label = EditorGUI.BeginProperty(position, label, property);
//		Rect contentPosition = EditorGUI.PrefixLabel(position, label);
//		if (position.height > 16f) {
//			position.height = 16f;
//			EditorGUI.indentLevel += 1;
//			contentPosition = EditorGUI.IndentedRect(position);
//			contentPosition.y += 18f;
//		}
//		contentPosition.width *= 0.75f;
//		EditorGUI.indentLevel = 0;
//		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("Assign_Stat"), GUIContent.none);
//		contentPosition.x += contentPosition.width;
//		contentPosition.width /= 3f;
//		EditorGUIUtility.labelWidth = 14f;
//		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("Amount"), GUIContent.none);
//		EditorGUI.EndProperty();
//	}
//}