using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ToggleButton))]
public class ToggleButtonReset : Editor 
{
	#region Variables and References
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

        ToggleButton toggleButton = (ToggleButton)target;

		EditorGUILayout.LabelField("Editor Controls", EditorStyles.boldLabel);

		EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Initialise"))
        {
            toggleButton.Initialise();
        }

        if (GUILayout.Button("Reset Colours"))
        {
            toggleButton.ResetValues(ResetType.Colours);
        }

        if (GUILayout.Button("Reset Size"))
        {
            toggleButton.ResetValues(ResetType.Size);
        }

        if (GUILayout.Button("Reset Delay"))
        {
            toggleButton.ResetValues(ResetType.Delay);
        }
        EditorGUILayout.EndHorizontal();

        toggleButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, toggleButton.size);
        toggleButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, toggleButton.size);
    }
    #endregion
}
