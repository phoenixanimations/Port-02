using UnityEngine;
using System.Collections;

public class TickingBomb : StatusFoundation 
{
	private int Timer = 3;
	protected override void Start ()
	{
		base.Start ();
		Damage = 100;
	}

	protected override void Status ()
	{
		base.Status ();
		if (Timer <= 0)
		{
			Cache.RemoveHealth(Damage);
			Deactivate();
			HitDirection(Vector3.up);
			HitDirection(Vector3.down);
			HitDirection(Vector3.left);
			HitDirection(Vector3.right);
			HitDirection(Vector3.up + Vector3.right);
			HitDirection(Vector3.up + Vector3.left);
			HitDirection(Vector3.down + Vector3.left);
			HitDirection(Vector3.down + Vector3.right);
			return;
		}
		Timer--;
	}

	private void HitDirection (Vector3 Direction)
	{
		HitArray = Physics2D.RaycastAll(transform.position,Direction,x * 2f);
		if (HitArray.Length > 0)
		{
			for (int i = 0; i < HitArray.Length; i++)
			{
				HitArray[i].collider.GetComponent<Creature>().RemoveHealth(Damage);
			}
		}
		HitArray = Physics2D.RaycastAll(transform.position,Direction,x * 3f);
		if (HitArray.Length > 0)
		{
			for (int i = 0; i < HitArray.Length; i++)
			{
				HitArray[i].collider.GetComponent<Creature>().Move(Direction);
			}
		}
	}

}
