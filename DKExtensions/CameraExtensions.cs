using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class CameraExtensions
{
    public static Vector3 WorldToUISpace(this Camera cam, Canvas canvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos,
            canvas.worldCamera, out movePos);
        //Convert the local point to world point
        return canvas.transform.TransformPoint(movePos);
    }
}