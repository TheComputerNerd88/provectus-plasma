using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    #region Variables and References
    [Header("Colours")]
    [SerializeField]
    Color32 offColour = new Color32(127, 127, 255, 255);
    [SerializeField]
    Color onColour = new Color32(255, 192, 76, 255);

    [Space]

    [Header("Misc. Options")]
    [SerializeField]
    bool startOn;
    [Range(1f, 1000f)]
    public float size = 60f;
    [Range(.01f, 5f)]
    [SerializeField]
    float delay = .5f;

    bool currentState;
    Button button;
    Image buttonImage;

	[Space]

	[Header("Toggled Events")]
	[SerializeField]
	UnityEvent toggleOn;
	[SerializeField]
	UnityEvent toggleOff;
	#endregion

	#region Methods
	// Use this for initialization
	void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();

        Initialise();
        currentState = startOn;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    public void Initialise()
    {
        button = gameObject.GetComponent<Button>();
        button.transition = Selectable.Transition.None;

        Text buttonText = button.GetComponentInChildren<Text>();
        buttonImage = gameObject.GetComponent<Image>();

        if (buttonText != null)
            Destroy(buttonText);

        buttonImage.color = Color.white;

        if (startOn)
            buttonImage.CrossFadeColor(onColour, 0f, false, false);
        else
            buttonImage.CrossFadeColor(offColour, 0f, false, false);
    }

	public void ResetValues(ResetType resetType)
	{
		if (resetType == ResetType.Colours)
		{
			offColour = new Color32(127, 127, 255, 255);
			onColour = new Color32(255, 192, 76, 255);
		}
		else if (resetType == ResetType.Size)
		{
			size = 60f;
		}
		else if (resetType == ResetType.Delay)
		{
			delay = .5f;
		}
	}

	public IEnumerator Toggle()
	{
		currentState = !currentState;

		if (currentState)
		{
			buttonImage.CrossFadeColor(onColour, delay, false, false);
		}
		else
		{
			buttonImage.CrossFadeColor(offColour, delay, false, false);
		}

		yield return new WaitForSeconds(delay);

		CheckEvents();
	}
	
	void CheckEvents()
	{
		if (currentState)
			toggleOn.Invoke();
		else
		{
			toggleOff.Invoke();
		}
	}
    #endregion
}

public enum ResetType
{
    Colours, Size, Delay
}
