using UnityEngine;
using UnityEditor;

public class Create_Menu
{
	[MenuItem("Create/Generic Weapon")]

 	private static void Generic_Weapon()
    {	
		PrefabUtility.CreatePrefab("Assets/Scripts/Equipment/Weapons/Generic_Weapon.prefab",new GameObject("Generic_Weapon",typeof(Equipment_Foundation)));
    }

	[MenuItem("Create/Generic Armor")]
 	private static void Generic_Armor()
    {
		PrefabUtility.CreatePrefab("Assets/Scripts/Equipment/Armor/Generic_Armor.prefab",new GameObject("Generic_Armor",typeof(Equipment_Foundation)));
    }


}

