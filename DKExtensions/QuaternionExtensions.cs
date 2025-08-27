using UnityEngine;

public static partial class QuaternionExtensions
{
    public static Quaternion FromEulerAngles(this Vector3 eulerAngles)
    {
        return Quaternion.Euler(eulerAngles);
    }
    
    public static Quaternion FromDirection(this Vector3 direction)
    {
        return Quaternion.LookRotation(direction);
    }
    
    public static Vector3 ToDirection(this Quaternion rotation)
    {
        return rotation * Vector3.forward;
    }
}