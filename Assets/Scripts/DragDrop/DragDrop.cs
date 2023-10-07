using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    private string playerPrefsKey = "ObjectPosition"; // Unique key for PlayerPrefs

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
        }
        transform.GetComponent<Collider>().enabled = true;

        // Save the object's position to PlayerPrefs
        PlayerPrefs.SetString(playerPrefsKey, PositionToString(transform.position));
        PlayerPrefs.Save();
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void Awake()
    {
        // Load the object's position from PlayerPrefs if available
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            string positionString = PlayerPrefs.GetString(playerPrefsKey);
            Vector3 savedPosition = StringToPosition(positionString);
            transform.position = savedPosition;
        }
    }

    // Custom method to convert Vector3 to a string
    private string PositionToString(Vector3 position)
    {
        return position.x + "," + position.y + "," + position.z;
    }

    // Custom method to convert string back to Vector3
    private Vector3 StringToPosition(string positionString)
    {
        string[] components = positionString.Split(',');
        if (components.Length == 3)
        {
            float x, y, z;
            if (float.TryParse(components[0], out x) && float.TryParse(components[1], out y) && float.TryParse(components[2], out z))
            {
                return new Vector3(x, y, z);
            }
        }
        return Vector3.zero;
    }
}