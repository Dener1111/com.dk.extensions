using UnityEngine;
using Cysharp.Threading.Tasks;

public static class ComponentExtensions
{
    /// <summary>
    /// Attaches a component to the given component's game object.
    /// </summary>
    /// <param name="component">Component.</param>
    /// <returns>Newly attached component.</returns>
    public static T AddComponent<T>(this Component component) where T : Component
    {
        return component.gameObject.AddComponent<T>();
    }

    /// <summary>
    /// Gets a component attached to the given component's game object.
    /// If one isn't found, a new one is attached and returned.
    /// </summary>
    /// <param name="component">Component.</param>
    /// <returns>Previously or newly attached component.</returns>
    public static T GetOrAddComponent<T>(this Component component) where T : Component
    {
        return component.GetComponent<T>() ?? component.AddComponent<T>();
    }

    /// <summary>
    /// Checks whether a component's game object has a component of type T attached.
    /// </summary>
    /// <param name="component">Component.</param>
    /// <returns>True when component is attached.</returns>
    public static bool HasComponent<T>(this Component component) where T : Component
    {
        return component.GetComponent<T>() != null;
    }

    /// <summary>Inactivates gameobject</summary>
	public static void SetInactive(this Component component)
    {
        component.gameObject.SetActive(false);
    }

    /// <summary>Activates gameobject</summary>
    public static void SetActive(this Component component)
    {
        component.gameObject.SetActive(true);
    }

    /// <summary>Activates gameobject</summary>
	public static void SetActive(this Component component, bool value)
    {
        component.gameObject.SetActive(value);
    }

    /// <summary>Inactivates gameObject</summary>
    /// <param name="delay">Time after which gameObject will be Inactivated.</param>
	public static async void SetInactive(this Component component, float delay)
    {
	await UniTask.WaitForSeconds(delay);
        component.gameObject.SetActive(false);
    }

    /// <summary>Activates gameObject</summary>
    /// <param name="delay">Time after which gameObject will be Activated.</param>
    public static async void SetActive(this Component component, float delay)
    {
	await UniTask.WaitForSeconds(delay);
        component.gameObject.SetActive(true);
    }

    /// <summary>Inactivates gameObject</summary>
    /// <param name="frames">Frames after which gameObject will be Deactivated.</param>
	public static async void SetInactive(this Component component, int frames)
    {
        await UniTask.DelayFrame(frames);
        component.gameObject.SetActive(false);
    }

    /// <summary>Activates gameObject</summary>
    /// <param name="frames">Frames after which gameObject will be Activated.</param>
    public static async void SetActive(this Component component, int frames)
    {
        await UniTask.DelayFrame(frames);
        component.gameObject.SetActive(true);
    }
}
