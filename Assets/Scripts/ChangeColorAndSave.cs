using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorAndSave : MonoBehaviour
{
    public Button changeColorButton;
    public GameObject cubeToChangeColor;
    public GameObject cubeToSaveColor;

    private Color[] colors;
    private int currentColorIndex = 0;

    private void Start()
    {
        changeColorButton.onClick.AddListener(ChangeCubeColor);
        LoadSavedColor();
    }

    private void ChangeCubeColor()
    {
        if (cubeToChangeColor != null && colors != null && colors.Length > 0)
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            cubeToChangeColor.GetComponent<Renderer>().material.color = colors[currentColorIndex];
            SaveColor();
        }
    }

    private void SaveColor()
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

    private void LoadSavedColor()
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
