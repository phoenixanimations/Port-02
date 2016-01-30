using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

// Unity can't serialize Dictionaries, so this works around it by using Lists instead.
// Details here: http://answers.unity3d.com/questions/460727/how-to-serialize-dictionary-with-unity-serializati.html
// NOTE: The TKey and TValue types you pass in MUST be seriliable themselves. If they aren't
//       try using the generic derived class technique found at the same link.

[System.Serializable]
public class SerializableDictionary<TKey,TValue> : 
	Dictionary<TKey, TValue>, ISerializationCallbackReceiver {
	
	// We save the keys and values in two lists because Unity does understand those.
	[SerializeField, HideInInspector]
	private List<TKey> _keys;
	[SerializeField, HideInInspector]
	private List<TValue> _values;
	
	// Before the serialization we fill these lists
	public void OnBeforeSerialize() {
		_keys = new List<TKey>(this.Count);
		_values = new List<TValue>(this.Count);
		foreach(var kvp in this) {
			_keys.Add(kvp.Key);
			_values.Add(kvp.Value);
		}
	}
	
	// After the serialization we create the dictionary from the two lists
	public void OnAfterDeserialize() {
		this.Clear();
		for (int i=0; i!= Mathf.Min(_keys.Count,_values.Count); i++) {
			this.Add(_keys[i],_values[i]);
		}
	}
}