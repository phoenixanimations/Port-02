using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System_Control.Extensions;

public class Grid_Pattern : Basic_Tile
{
	private void Spawn_Tile (GameObject Select_Tile, Vector2 Position)
	{
		GameObject Tile = Instantiate (Select_Tile);
		Tile.transform.parent = transform;
		Tile.transform.position = transform.position;
		Tile.transform.position += (Vector3)Position;
	}

	protected void Spawn_Diamond (GameObject Tile, float Movement)
	{
		Spawn_Tile (Tile, Vector2.zero);
		for (int i = 0; i <= Movement; i++)
 		{
			Vector2 Spawn_Position = Vector.Up * i;
			for (int iSpawn = 0; iSpawn < i; iSpawn++) 
			{
				Spawn_Position += Vector.Right;
				Spawn_Position += Vector.Down;
				Spawn_Tile(Tile, Spawn_Position);
			}

			for (int iSpawn = 0; iSpawn < i; iSpawn++) 
			{
				Spawn_Position += Vector.Down;
				Spawn_Position += Vector.Left;
				Spawn_Tile(Tile, Spawn_Position);
			}

			for (int iSpawn = 0; iSpawn < i; iSpawn++) 
			{
				Spawn_Position += Vector.Left;
				Spawn_Position += Vector.Up;
				Spawn_Tile(Tile, Spawn_Position);
			}

			for (int iSpawn = 0; iSpawn < i; iSpawn++) 
			{
				Spawn_Position += Vector.Up;
				Spawn_Position += Vector.Right;
				Spawn_Tile(Tile, Spawn_Position);
			}
		}
	}
}