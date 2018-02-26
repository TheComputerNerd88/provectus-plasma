using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PartSwitcher))]
public class PartSwitcherEditor : Editor 
{
	#region Variables and References
	int partNumber;
	#endregion

	#region Methods
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		PartSwitcher partSwitcher = (PartSwitcher)target;

		EditorGUILayout.LabelField("Editor Controls", EditorStyles.boldLabel);

		partNumber = EditorGUILayout.IntSlider("Part to switch to", partNumber, 1, partSwitcher.parts.Length);
		partSwitcher.PartSwitch(partNumber);
	}
	#endregion
}
