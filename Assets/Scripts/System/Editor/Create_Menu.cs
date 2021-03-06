﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System_Control;

public class Create_Menu
{
	[MenuItem("Create/Generic Creature")]
	private static void Create_Generic_Creature()
    {
		GameObject Generic_Creature = new GameObject("Generic_Creature");
		var Default_Creature_Equipment = Generic_Creature.AddComponent<Creature>();
		Default_Creature_Equipment.Slot[(int)Assign_Slot.Primary_Hand] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Hand_1H.prefab",typeof(Equipment_Foundation));
		Default_Creature_Equipment.Slot[(int)Assign_Slot.Secondary_Hand] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Hand_1H.prefab",typeof(Equipment_Foundation));
		Default_Creature_Equipment.Slot[(int)Assign_Slot.Armor] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Armor.prefab",typeof(Equipment_Foundation));
		Default_Creature_Equipment.Slot[(int)Assign_Slot.Arrow] = (Equipment_Foundation)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/System/Nothing/None_Arrow.prefab",typeof(Equipment_Foundation));
		PrefabUtility.CreatePrefab(Spawn_In_Folder("Generic_Creature.prefab"),Generic_Creature);
		UnityEngine.Object.DestroyImmediate(Generic_Creature);
	}


	[MenuItem("Create/Generic Equipment")]
 	private static void Create_Generic_Equipment()
    {	
		GameObject Generic_Equipment = new GameObject("Generic_Equipment");
		PrefabUtility.CreatePrefab(Spawn_In_Folder("Generic_Equipment.prefab"),Generic_Equipment);
		UnityEngine.Object.DestroyImmediate(Generic_Equipment);
    }

	[MenuItem("Create/xForm Limited")]
	private static void Create_xForm_Limited()
    {
		GameObject Create_xForm_Limited = new GameObject("xForm_Limited");
		var Default_Stats = Create_xForm_Limited.AddComponent<xForm_Limited>();
		Default_Stats.Class = Assign_Class.xForm;
		PrefabUtility.CreatePrefab(Spawn_In_Folder("xForm_Limited.prefab"),Create_xForm_Limited);
		UnityEngine.Object.DestroyImmediate(Create_xForm_Limited);
	}

	[MenuItem("Create/xForm Unlimited")]
	private static void Create_xForm_Unlimited()
    {
		GameObject Create_xForm_Unlimited = new GameObject("xForm_Unlimited");
		var Default_Stats = Create_xForm_Unlimited.AddComponent<xForm_Unlimited>();
		var Side_A = Create_xForm_Unlimited.AddComponent<Equipment_Foundation>();
		var Side_B = Create_xForm_Unlimited.AddComponent<Equipment_Foundation>();
		Default_Stats.Class = Assign_Class.xForm;
		Default_Stats.Side_A = Side_A;
		Default_Stats.Side_B = Side_B;
		PrefabUtility.CreatePrefab(Spawn_In_Folder("xForm_Unlimited.prefab"),Create_xForm_Unlimited);
		UnityEngine.Object.DestroyImmediate(Create_xForm_Unlimited);
	}

	private static string Spawn_In_Folder (string Name)
	{
		string path = "Assets";
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
            }
            break;
        }
		return path + "/" + Name;
	}
}