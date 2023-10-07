using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject objectToToggle;

    private bool isObjectVisible = true;

    private void Start()
    {
        // Initialize the object's visibility based on the saved toggle position (if available).
        isObjectVisible = PlayerPrefs.GetInt("ObjectVisibility", 1) == 1;
        UpdateObjectVisibility();
    }

    public void ToggleVisibility()
    {
        // Toggle the visibility state of the object.
        isObjectVisible = !isObjectVisible;
        UpdateObjectVisibility();

        // Save the toggle position to PlayerPrefs.
        PlayerPrefs.SetInt("ObjectVisibility", isObjectVisible ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateObjectVisibility()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(isObjectVisible);
        }
    }
}
