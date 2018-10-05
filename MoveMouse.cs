using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
/*
public struct FIXED
{
    public short fract;
    public short value;
}*/

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;
    public static implicit operator Vector2(POINT p)
    {
        return new Vector2(p.X, p.Y);
    }
}

public class MoveMouse : MonoBehaviour
{

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT pos);
    int X, Y;
    [DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy,
                      int dwData, int dwExtraInfo);

   public enum MouseEventFlags
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
    }

    public static void LeftClick()
    {
        mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
    }

    void Update()
    {
        POINT cursorPos = new POINT();
        GetCursorPos(out cursorPos); 
        int newX = (int)(Input.GetAxis("Mouse X") * 5);
        int newY = (int)(Input.GetAxis("Mouse Y") * 5);
        if (Input.GetButtonDown("Click")) {
            LeftClick();
        }

        SetCursorPos(cursorPos.X + newX , cursorPos.Y + newY);
    }

}