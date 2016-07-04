using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class xForm_Limited : xForm_Foundation 
{
	public Assign_Class Class_A_Side;
	public Assign_Class Class_B_Side;
	public Assign_Subclass Subclass_A_Side;
	public Assign_Subclass Subclass_B_Side;
	public List<Status_Foundation> Passive_A_Side = new List<Status_Foundation>();
	public List<Status_Foundation> Passive_B_Side = new List<Status_Foundation>();
}