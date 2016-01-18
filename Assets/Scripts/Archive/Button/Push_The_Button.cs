using UnityEngine;
using System.Collections;

public class Push_The_Button : MonoBehaviour {
public string stringToEdit = "Click Me";
public string Name = "Data";
public string _Name;


void OnGUI() {
GUI.TextField(new Rect(10, 30, 100, 20), Name, 20);
if(GUI.Button(new Rect(10,10,100,20), stringToEdit, "Click Me")) {
Name = "abc";
}
}
}