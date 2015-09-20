using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {






	public void Start()
	{
		Metronome m = new Metronome();

		Listener l = new Listener();
		l.Subscribe(m);
		m.Starting();	

	}









}