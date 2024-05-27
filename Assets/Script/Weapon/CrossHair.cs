using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public Texture2D crosshair;
    void Start()
    {
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
    }
    void Update()
    {
        
    }
}
