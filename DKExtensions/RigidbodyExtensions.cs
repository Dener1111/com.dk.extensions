using UnityEngine;
/// <summary>
/// Extension methods for UnityEngine.Rigidbody.
/// </summary>
public static partial class RigidbodyExtensions
{
    /// <summary>
    /// Changes the direction of a rigidbody without changing its speed.
    /// </summary>
    /// <param name="rigidbody">Rigidbody.</param>
    /// <param name="direction">New direction.</param>
    public static void ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
    {
        rigidbody.linearVelocity = direction * rigidbody.linearVelocity.magnitude;
    }

    public static void TogglePhysics(this Rigidbody rigidbody, bool physics = true)
    {
        rigidbody.useGravity = physics;
        rigidbody.isKinematic = !physics;
    }
}
