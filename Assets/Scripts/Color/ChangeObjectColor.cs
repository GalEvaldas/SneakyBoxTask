using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeObjectColor : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public Button colorButton1;
    public Button colorButton2;
    public Button colorButton3;
    public Color[] colors;

    private int currentColorIndex1 = 0;
    private int currentColorIndex2 = 0;
    private int currentColorIndex3 = 0;

    private void Start()
    {
        // Attach button click events to the respective ChangeColor methods
        colorButton1.onClick.AddListener(ChangeColor1);
        colorButton2.onClick.AddListener(ChangeColor2);
        colorButton3.onClick.AddListener(ChangeColor3);

        // Load the saved color indices from PlayerPrefs
        currentColorIndex1 = PlayerPrefs.GetInt("Object1ColorIndex", 0);
        currentColorIndex2 = PlayerPrefs.GetInt("Object2ColorIndex", 0);
        currentColorIndex3 = PlayerPrefs.GetInt("Object3ColorIndex", 0);

        // Set the initial colors of the objects
        SetObjectColor(object1, colors[currentColorIndex1]);
        SetObjectColor(object2, colors[currentColorIndex2]);
        SetObjectColor(object3, colors[currentColorIndex2]);
    }

    private void ChangeColor1()
    {
        // Increment the color index and wrap it around if it exceeds the array length
        currentColorIndex1 = (currentColorIndex1 + 1) % colors.Length;

        // Set the new color for object 1
        SetObjectColor(object1, colors[currentColorIndex1]);

        // Save the current color index for object 1 to PlayerPrefs
        PlayerPrefs.SetInt("Object1ColorIndex", currentColorIndex1);
        PlayerPrefs.Save();
    }

    private void ChangeColor2()
    {
        // Increment the color index and wrap it around if it exceeds the array length
        currentColorIndex2 = (currentColorIndex2 + 1) % colors.Length;

        // Set the new color for object 2
        SetObjectColor(object2, colors[currentColorIndex2]);

        // Save the current color index for object 2 to PlayerPrefs
        PlayerPrefs.SetInt("Object2ColorIndex", currentColorIndex2);
        PlayerPrefs.Save();
    }
    private void ChangeColor3()
    {
        // Increment the color index and wrap it around if it exceeds the array length
        currentColorIndex3 = (currentColorIndex3 + 1) % colors.Length;

        // Set the new color for object 2
        SetObjectColor(object3, colors[currentColorIndex3]);

        // Save the current color index for object 2 to PlayerPrefs
        PlayerPrefs.SetInt("Object3ColorIndex", currentColorIndex3);
        PlayerPrefs.Save();
    }

    private void SetObjectColor(GameObject obj, Color color)
    {
        // Set the color of the object's material
        obj.GetComponent<Renderer>().material.color = color;
    }
}
