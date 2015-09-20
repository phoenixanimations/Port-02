using UnityEngine;
using System.Collections;

public class Movement : Stats
{
	private bool GoUp, GoDown, GoLeft, GoRight, GoUpRight, GoDownRight, GoDownLeft, GoUpLeft;
	protected float x;
	protected float y;
	
	protected override void Start ()
	{
		x = GetComponent<SpriteRenderer> ().bounds.size.x;
		y = GetComponent<SpriteRenderer> ().bounds.size.y;
	}

	protected void AllowMovement()
	{
		GoUp = true;
		GoDown = true;
		GoLeft = true;
		GoRight = true;
		GoUpLeft = true;
		GoUpRight = true;
		GoDownLeft = true;
		GoDownRight = true;
	}

	public virtual void Move (string Direction)
	{
		if (Direction == "Up" && GoUp)
			transform.position += new Vector3 (0, y, 0);
		if (Direction == "Down" && GoDown)
			transform.position += new Vector3 (0, -y, 0);
		if (Direction == "Left" && GoLeft)
			transform.position += new Vector3 (-x, 0, 0);
		if (Direction == "Right" && GoRight)
			transform.position += new Vector3 (x, 0, 0);
		if ((Direction == "UpRight" || Direction == "RightUp") && GoUpRight)
			transform.position += new Vector3 (x, y, 0);
		if ((Direction == "DownRight" || Direction == "RightDown") && GoDownRight)
			transform.position += new Vector3 (x, -y, 0);
		if ((Direction == "DownLeft" || Direction == "LeftDown") && GoDownLeft)
			transform.position += new Vector3 (-x, -y, 0);
		if ((Direction == "UpLeft" || Direction == "LeftUp") && GoUpLeft)
			transform.position += new Vector3 (-x, y, 0);
	}

	public void Stop (string Direction)
	{
		if (Direction == "Up")
			GoUp = false;
		if (Direction == "Down")
			GoDown = false;
		if (Direction == "Left")
			GoLeft = false;
		if (Direction == "Right")
			GoRight = false;
		if (Direction == "UpRight" || Direction == "RightUp")
			GoUpRight = false;
		if (Direction == "DownRight" || Direction == "RightDown")
			GoDownRight = false;
		if (Direction == "DownLeft" || Direction == "LeftDown")
			GoDownLeft = false;
		if (Direction == "UpLeft" || Direction == "LeftUp")
			GoUpLeft = false;
	}
}
