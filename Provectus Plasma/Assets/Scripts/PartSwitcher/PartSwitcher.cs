using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSwitcher : MonoBehaviour 
{
    #region Variables and References
    public GameObject[] parts;
	#endregion
	
	#region Methods
	// Use this for initialization
	void Start () 
	{
		PartSwitch(1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public void PartSwitch(int partNumber)
    {
        foreach (GameObject part in parts)
        {
            if ((part == parts[partNumber - 1]))
                part.SetActive(true);
            else
				part.SetActive(false);
        }
    }
	#endregion
}
