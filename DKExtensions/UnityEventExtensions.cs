using UnityEngine.Events;

public static partial class UnityEventExtensions
{
    ///<summary>
    ///Invoke event only if has Persistent Listeners
    ///</summary>
    public static void TryInvoke(this UnityEvent unityEvent)
    {
        if (unityEvent.GetPersistentEventCount() > 0)
            unityEvent.Invoke();
    }

    ///<summary>
    ///Invoke event only if has Persistent Listeners
    ///</summary>
    public static void TryInvoke<T0>(this UnityEvent<T0> unityEvent, T0 arg0)
    {
        if (unityEvent.GetPersistentEventCount() > 0)
            unityEvent.Invoke(arg0);
    }

    ///<summary>
    ///Invoke event only if has Persistent Listeners
    ///</summary>
    public static void TryInvoke<T0, T1>(this UnityEvent<T0, T1> unityEvent, T0 arg0, T1 arg1)
    {
        if (unityEvent.GetPersistentEventCount() > 0)
            unityEvent.Invoke(arg0, arg1);
    }

    ///<summary>
    ///Invoke event only if has Persistent Listeners
    ///</summary>
    public static void TryInvoke<T0, T1, T2>(this UnityEvent<T0, T1, T2> unityEvent, T0 arg0, T1 arg1, T2 arg2)
    {
        if (unityEvent.GetPersistentEventCount() > 0)
            unityEvent.Invoke(arg0, arg1, arg2);
    }

    ///<summary>
    ///Invoke event only if has Persistent Listeners
    ///</summary>
    public static void TryInvoke<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> unityEvent, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
    {
        if (unityEvent.GetPersistentEventCount() > 0)
            unityEvent.Invoke(arg0, arg1, arg2, arg3);
    }
}