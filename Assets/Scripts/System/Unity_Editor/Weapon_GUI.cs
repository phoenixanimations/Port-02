using UnityEngine;
using System.Collections;
using UnityEditor;
using System_Control;

[CustomEditor(typeof(Equipment_Foundation))]

public class Weapon_GUI : Editor 
{
	static bool Damage_Foldout = false;
	static bool Resistance_Foldout = false;
	static bool Assign_Stats_Foldout = false;
	static bool Class_Foldout = false;
	static bool Config_Foldout = false;

	Stat Assign_Stat;
	float Amount;
	bool Set_Stat;
	bool Left, Upper_Left, Up,   Upper_Right, Right,
		 	   Lower_Left, Down, Lower_Right, Center;
	bool Diamond, Plus_Shaped, Square;

	Stat Add_Assign_Stat;
	float Add_Amount;
	bool Add_Set_Stat;

 	SerializedProperty 	Status;

	public void OnEnable()
    {
		Status = serializedObject.FindProperty("Status");
    }

	public override void OnInspectorGUI()
    {
		GUI.changed = false;
		serializedObject.Update();
		Equipment_Foundation Weapon_Editor = (Equipment_Foundation)target;
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
		
		Config_Foldout = EditorGUILayout.Foldout(Config_Foldout, "Config");

		if (Config_Foldout)
		{
			EditorGUILayout.FloatField("Numer of Attacks", Weapon_Editor.Get_Stat(Stat.Number_Of_Attacks));
			EditorGUILayout.FloatField("Distance", Weapon_Editor.Get_Stat(Stat.Distance));

			EditorGUILayout.BeginHorizontal ();
			Upper_Left = EditorGUILayout.Toggle(Upper_Left,GUILayout.Width(15f));
			Up = EditorGUILayout.Toggle(Up,GUILayout.Width(15f));
			Upper_Right = EditorGUILayout.Toggle(Upper_Right,GUILayout.Width(124f));
			Diamond = EditorGUILayout.Toggle(Diamond,GUILayout.Width(15f));
			EditorGUILayout.LabelField("Diamond", GUILayout.Width(60f));
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			Left = EditorGUILayout.Toggle(Left,GUILayout.Width(15f));
			Center = EditorGUILayout.Toggle(Center,GUILayout.Width(15f));
			Right = EditorGUILayout.Toggle(Right,GUILayout.Width(124f));
			Square = EditorGUILayout.Toggle(Square,GUILayout.Width(15f));			
			EditorGUILayout.LabelField("Square");
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			Lower_Left = EditorGUILayout.Toggle(Lower_Left,GUILayout.Width(15f));
			Down = EditorGUILayout.Toggle(Down,GUILayout.Width(15f));
			Lower_Right = EditorGUILayout.Toggle(Lower_Right,GUILayout.Width(124f));
			Plus_Shaped = EditorGUILayout.Toggle(Plus_Shaped,GUILayout.Width(15f));
			EditorGUILayout.LabelField("Plus");
			EditorGUILayout.EndHorizontal ();

		}

		
		

		Damage_Foldout = EditorGUILayout.Foldout(Damage_Foldout, "Damage");

		if (Damage_Foldout)
		{
		    EditorGUILayout.LabelField("Hitpoints", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			EditorGUILayout.FloatField("Hitpoints", Weapon_Editor.Get_Stat(Stat.Hitpoints));
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		    EditorGUILayout.LabelField("Damage", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			EditorGUILayout.FloatField("Melee Damage", Weapon_Editor.Get_Stat(Stat.Melee_Damage));
			EditorGUILayout.FloatField("Magic Damage", Weapon_Editor.Get_Stat(Stat.Magic_Damage));
			EditorGUILayout.FloatField("Archery Damage", Weapon_Editor.Get_Stat(Stat.Archery_Damage));
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
	
			EditorGUILayout.LabelField("Critical", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			EditorGUILayout.FloatField("Critical Damage", Weapon_Editor.Get_Stat(Stat.Critical_Damage));
			EditorGUILayout.FloatField("Critical Chance", Weapon_Editor.Get_Stat(Stat.Critical_Chance));
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
			
			EditorGUILayout.LabelField("Accuracy", EditorStyles.boldLabel);
			EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			EditorGUILayout.FloatField("Accuracy", Weapon_Editor.Get_Stat(Stat.Accuracy));
			EditorGUILayout.FloatField("Evade", Weapon_Editor.Get_Stat(Stat.Evade));
			EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		}

		Resistance_Foldout = EditorGUILayout.Foldout( Resistance_Foldout, "Resistance" );
			
		if (Resistance_Foldout)
		{
			 EditorGUI.indentLevel = EditorGUI.indentLevel + 1;
			 EditorGUILayout.FloatField("Melee Resistance", Weapon_Editor.Get_Stat(Stat.Melee_Resistance));
			 EditorGUILayout.FloatField("Magic Resistance", Weapon_Editor.Get_Stat(Stat.Magic_Resistance));
			 EditorGUILayout.FloatField("Archery Resistance", Weapon_Editor.Get_Stat(Stat.Archery_Resistance));
		     EditorGUI.indentLevel = EditorGUI.indentLevel - 1;
		}		

		Assign_Stats_Foldout = EditorGUILayout.Foldout(Assign_Stats_Foldout, "Change Stats");

		if (Assign_Stats_Foldout)
		{

			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField("Tier:", EditorStyles.boldLabel,GUILayout.Width(30f));
			Assign_Stat = (Stat)EditorGUILayout.EnumPopup(Assign_Stat,GUILayout.Width(120f));
			Amount = EditorGUILayout.FloatField(Amount,GUILayout.Width(40f));
			Set_Stat = EditorGUILayout.Toggle(Set_Stat,GUILayout.Width(15f));
			if(GUILayout.Button("DO IT",GUILayout.Width(40f),GUILayout.Height(15f)))
	        {
				Weapon_Editor.Get_Stat(Assign_Stat,Amount,Tier.Formula(Weapon_Editor.Get_Stat(Stat.Equip_Level)),Set_Stat);
			}
			if(GUILayout.Button("Mistakes were made",GUILayout.Width(120f),GUILayout.Height(15f)))
	        {
				Weapon_Editor.Get_Stat(Assign_Stat,0,true);
	        }
			
			
			EditorGUILayout.EndHorizontal ();
			
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField("Add: ", EditorStyles.boldLabel, GUILayout.Width(30f));
			Add_Assign_Stat = (Stat)EditorGUILayout.EnumPopup(Add_Assign_Stat,GUILayout.Width(120f));
			Add_Amount = EditorGUILayout.FloatField(Add_Amount,GUILayout.Width(40f));
			Add_Set_Stat = EditorGUILayout.Toggle(Add_Set_Stat,GUILayout.Width(15f));
			if(GUILayout.Button("DO IT",GUILayout.Width(40f),GUILayout.Height(15f)))
	        {
				Weapon_Editor.Get_Stat(Add_Assign_Stat,Add_Amount,Add_Set_Stat);
	        }
			if(GUILayout.Button("Mistakes were made",GUILayout.Width(120f),GUILayout.Height(15f)))
	        {
				Weapon_Editor.Get_Stat(Add_Assign_Stat,0,true);
			}
			EditorGUILayout.EndHorizontal ();
		}

		EditorGUILayout.PropertyField(Status,true);
		serializedObject.ApplyModifiedProperties();	
		
    }
}