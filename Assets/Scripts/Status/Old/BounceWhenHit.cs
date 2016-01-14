using UnityEngine;
using System.Collections;

public class BounceWhenHit : StatusFoundation 
{
	//A lot of things to consider, does it bounce when hit? When you use item? Is it item specific? 
	//If creature state == attack, and you lost health bounce that guy. 
	public int RecordHealth;
	public string RecordedCreature;

	protected override void Start ()
	{
		base.Start ();
	}

	protected override void Status ()
	{
		base.Status ();

		LookAround(Vector3.up);
		LookAround(Vector3.left);
		LookAround(Vector3.right);
		LookAround(Vector3.up + Vector3.right);
		LookAround(Vector3.up + Vector3.left);
		LookAround(Vector3.down + Vector3.right);
		LookAround(Vector3.down + Vector3.left);
	}

	private void LookAround (Vector3 Direction)
	{
		Hit = Physics2D.Raycast(transform.position,Direction,x);
		if (Hit.collider != null)
		{
			Hit.collider.GetComponent<Creature>().Move(Direction);
		}
	}

}
