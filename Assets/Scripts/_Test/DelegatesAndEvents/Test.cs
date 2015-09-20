using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {


	//YAY IT FUCKING WORKED!?!?!?!?!?!?!?!?!?!?#1HAShTAG



	public void Start()
	{
		Metronome m = new Metronome();

		Listener l = new Listener();
		l.Subscribe(m);
		m.Starting();	

	}









}