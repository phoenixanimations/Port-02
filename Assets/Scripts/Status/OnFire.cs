using UnityEngine;
using System.Collections;

public class OnFire : StatusFoundation 
{
	protected override void Status ()
	{
		base.Status ();
		Damage++;
		Cache.RemoveHealth(Damage);
		findCreature(Vector3.up,x);
		findCreature(Vector3.left,x);
		findCreature(Vector3.right,x);
		findCreature(Vector3.down,x);
	}
	
	private void findCreature (Vector3 Direction,float Distance)
	{
		RaycastHit2D creature = Physics2D.Raycast(transform.position,Direction,Distance);
		if (creature.collider != null && creature.collider.GetComponent<OnFire>() == null)
			creature.collider.gameObject.AddComponent<OnFire>().AddDamage(Damage);
		if (creature.collider != null && creature.collider.GetComponent<OnFire>() != null)
			creature.collider.gameObject.GetComponent<OnFire>().AddDamage(Damage);
	}
}
