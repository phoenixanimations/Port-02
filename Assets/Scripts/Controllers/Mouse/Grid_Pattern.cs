using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System_Control.Extensions;
using System_Control.Math;

public class Grid_Pattern : MonoBehaviour 
{
	public GameObject Tile;

	public void Start ()
	{
		if (Tile == null)
		{
			Debug.LogError("Tile is null");
		}

		Spawn(3);
	}

	public void Spawn (float Movement)
	{
		Tile.transform.position = transform.position;

//		float Tile_Number = 0f;
//		for (float i = Movement; i >= 1f; i--)
//		{
//			Tile_Number = 1f + (i - 1f) * 2f;
		Spawn_Formula(Tile,Movement);
//		}
	}

//	private void Spawn_Formula (GameObject Tile, float Movement)//GameObject Tile_Copy
//	{
//		Vector2 Game_Object_Position = transform.position;
//		Tile.transform.position = Game_Object_Position;
//		Instantiate(Tile);
//		for (float i = 1; i <= Movement; i++)
//		{
//			Spawn_Tile (Tile,Game_Object_Position + Vector.Up * i);
//			Spawn_Tile (Tile,Game_Object_Position + Vector.Down * i);
//			Spawn_Tile (Tile,Game_Object_Position + Vector.Left * i);
//			Spawn_Tile (Tile,Game_Object_Position + Vector.Right * i);
//			
////			if (i < Movement)
////			{
////				Spawn_Tile (Tile,Game_Object_Position + (Vector.Right + Vector.Up) * (i));
////				Spawn_Tile (Tile,Game_Object_Position + (Vector.Left + Vector.Up) * (i));
////				Spawn_Tile (Tile,Game_Object_Position + (Vector.Right + Vector.Down) * (i));
////				Spawn_Tile (Tile,Game_Object_Position + (Vector.Left + Vector.Down) * (i));
////
////			}
//
//
//		}
//	}

	private void Spawn_Formula (GameObject Tile, float Movement)
	{

		Spawn_Tile(Tile,Vector.Up);

	}

	private void Spawn_Tile (GameObject Tile,Vector2 Position)
	{
		Tile = Instantiate (Tile);
		Tile.transform.parent = this.transform;
		Tile.transform.position += (Vector3)Position;
	}
}
