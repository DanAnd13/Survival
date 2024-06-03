using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public Texture2D crosshair;
    void Start()
    {
        CustomCursor();
    }
    void Update()
    {
        
    }
    public void CustomCursor()
    {
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
    }
    public static void StandartCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
