using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClick : MonoBehaviour
{
    public Button changeColorButton;
    public GameObject cubeToChangeColor;
    public Color[] colors; // Array of colors to cycle through
    private int currentColorIndex = 0;

    private void Start()
    {
        changeColorButton.onClick.AddListener(ChangeCubeColor);
    }

    private void ChangeCubeColor()
    {
        if (cubeToChangeColor != null && colors.Length > 0)
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            cubeToChangeColor.GetComponent<Renderer>().material.color = colors[currentColorIndex];
        }
    }
}
