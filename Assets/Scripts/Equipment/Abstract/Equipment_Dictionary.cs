using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Equipment_Dictionary : MonoBehaviour  
{
	public GameObject[] ID_List = new GameObject[6];

	public Dictionary<ID, GameObject> Find;
	
	protected void Start ()
	{
		Find = new Dictionary<ID, GameObject>()
		{
			{ID.Melee_Vanilla_One_Handed, ID_List[0]}, 
			{ID.Melee_Vanilla_Two_Handed, ID_List[1]},
			{ID.Melee_Vanilla_Shield, ID_List[2]},
			{ID.Nude_Helmet, ID_List[3]}, 
			{ID.Nude_Chest, ID_List[4]},
			{ID.Nude_Legs, ID_List[5]}
		};
	}

}
