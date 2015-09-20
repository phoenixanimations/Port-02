using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {
	private characterMovement test;

	void Start () {
		Physics2D.raycastsStartInColliders = false;
	} 

	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right, .5f);

			if (hit){
				test = hit.collider.GetComponent<characterMovement>();
				test.Stop();
			}
		Debug.DrawRay(transform.position,transform.right * .5f);
	}
}
