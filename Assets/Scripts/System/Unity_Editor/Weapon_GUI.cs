using UnityEngine;
using System.Collections;
using UnityEditor;
using System_Control;

[CustomEditor(typeof(Weapon_Foundation))]

public class Weapon_GUI : Editor 
{
	static bool Resistance_Foldout = false;
	static bool Random_Foldout = false;
	static bool Assign_Stats_Foldout = false;
	static bool Class_Foldout = false;

 	SerializedProperty Serialized_Status;


	public void OnEnable()
    {
 		Serialized_Status = serializedObject.FindProperty("Status");
    }

	public override void OnInspectorGUI()
    {
		Weapon_Foundation Weapon_Editor = (Weapon_Foundation)target;
		Weapon_Foundation Get_Stats_Button = (Weapon_Foundation)target;

     	Weapon_Editor.Name = EditorGUILayout.TextField("Name", Weapon_Editor.Name);
		Weapon_Editor.Description = EditorGUILayout.TextField("Description", Weapon_Editor.Description);

		Class_Foldout = EditorGUILayout.Foldout(Class_Foldout, "Class");

		if (Class_Foldout)
		{      
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			Weapon_Editor.Class = (Assign_Class)EditorGUILayout.EnumPopup("Class",Weapon_Editor.Class);
			Weapon_Editor.Subclass = (Assign_Subclass)EditorGUILayout.EnumPopup("Subclass",Weapon_Editor.Subclass);
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		}
		
	    EditorGUILayout.LabelField("Damage", EditorStyles.boldLabel);
		EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
		Weapon_Editor.Melee_Damage = EditorGUILayout.FloatField("Melee Damage", Weapon_Editor.Melee_Damage);
		Weapon_Editor.Magic_Damage = EditorGUILayout.FloatField("Magic Damage", Weapon_Editor.Magic_Damage);
		Weapon_Editor.Archery_Damage = EditorGUILayout.FloatField("Archery Damage", Weapon_Editor.Archery_Damage);
		EditorGUI.indentLevel = EditorGUI.indentLevel - 1;

		EditorGUILayout.LabelField("Critical", EditorStyles.boldLabel);
		EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
		Weapon_Editor.Critical_Damage = EditorGUILayout.FloatField("Critical Damage", Weapon_Editor.Critical_Damage);
		Weapon_Editor.Critical_Chance = EditorGUILayout.FloatField("Critical Chance", Weapon_Editor.Critical_Chance);
		EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		
		EditorGUILayout.LabelField("Accuracy", EditorStyles.boldLabel);
		EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
		Weapon_Editor.Accuracy = EditorGUILayout.FloatField("Accuracy", Weapon_Editor.Accuracy);
		Weapon_Editor.Evade = EditorGUILayout.FloatField("Evade", Weapon_Editor.Evade);
		EditorGUI.indentLevel = EditorGUI.indentLevel - 1;

		Resistance_Foldout = EditorGUILayout.Foldout( Resistance_Foldout, "Resistance" );
			
		if (Resistance_Foldout)
		{
			 EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			 Weapon_Editor.Melee_Resistance = EditorGUILayout.FloatField("Melee_Resistance", Weapon_Editor.Melee_Resistance);
			 Weapon_Editor.Magic_Resistance = EditorGUILayout.FloatField("Magic_Resistance", Weapon_Editor.Magic_Resistance);
			 Weapon_Editor.Archery_Resistance = EditorGUILayout.FloatField("Archery_Resistance", Weapon_Editor.Archery_Resistance);
		     EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		}

		Random_Foldout = EditorGUILayout.Foldout( Random_Foldout, "Random" );

		if (Random_Foldout)
		{
			 EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			 Weapon_Editor.Critical_Chance = EditorGUILayout.FloatField("Critical_Chance", Weapon_Editor.Critical_Chance);
			 Weapon_Editor.Defect_Chance = EditorGUILayout.FloatField("Defect_Chance", Weapon_Editor.Defect_Chance);
			 Weapon_Editor.Passive_Chance = EditorGUILayout.FloatField("Passive_Chance", Weapon_Editor.Passive_Chance);
        	 EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		}

		Assign_Stats_Foldout = EditorGUILayout.Foldout(Assign_Stats_Foldout, "Change Stats");
		if (Assign_Stats_Foldout)
		{
			EditorGUILayout.BeginHorizontal ();


			if(GUILayout.Button("DO IT"))
	        {
	
	            Get_Stats_Button.Get_Stat(Get_Stats_Button.Assign_Stat,Get_Stats_Button.Amount,Get_Stats_Button.Set_Stat);
	        }
			
				
			EditorGUILayout.EndHorizontal ();
		}

		serializedObject.Update();
		EditorGUILayout.PropertyField(Serialized_Status);
		serializedObject.ApplyModifiedProperties();
//		Weapon_Editor.Status = EditorGUILayout.ObjectField("Status", Weapon_Editor.Status, typeof(Status_Foundation), true) as Status_Foundation ;
		

	

    }
}



//		DrawDefaultInspector();'
