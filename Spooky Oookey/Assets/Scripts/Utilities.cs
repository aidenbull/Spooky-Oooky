using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static Vector2 Rotate2D(Vector2 toRotate, float radianAngle)
    {
        float newX = toRotate.x * Mathf.Cos(radianAngle) - toRotate.y * Mathf.Sin(radianAngle);
        float newY = toRotate.x * Mathf.Sin(radianAngle) + toRotate.y * Mathf.Cos(radianAngle);
        return new Vector2(newX, newY);
    }


    public static Vector2 Project2D(Vector2 a, Vector2 b)
    {
        Vector2 projectedVector = (Vector2.Dot(a, b) / Vector2.Dot(b, b)) * b;
        return projectedVector;
    }
}
