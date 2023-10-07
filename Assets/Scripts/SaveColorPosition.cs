using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveColorPosition : MonoBehaviour
{
    public GameObject cubeToSaveColor;

    private void Start()
    {
        LoadSavedColor();
    }

    public void SaveColor()
    {
        if (cubeToSaveColor != null)
        {
            Color cubeColor = cubeToSaveColor.GetComponent<Renderer>().material.color;
            PlayerPrefs.SetFloat("CubeColorR", cubeColor.r);
            PlayerPrefs.SetFloat("CubeColorG", cubeColor.g);
            PlayerPrefs.SetFloat("CubeColorB", cubeColor.b);
            PlayerPrefs.Save();
        }
    }

    public void LoadSavedColor()
    {
        if (cubeToSaveColor != null)
        {
            float r = PlayerPrefs.GetFloat("CubeColorR");
            float g = PlayerPrefs.GetFloat("CubeColorG");
            float b = PlayerPrefs.GetFloat("CubeColorB");
            Color savedColor = new Color(r, g, b);
            cubeToSaveColor.GetComponent<Renderer>().material.color = savedColor;
        }
    }
}
