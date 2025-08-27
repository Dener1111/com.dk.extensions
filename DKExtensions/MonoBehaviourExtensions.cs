using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public static partial class MonoBehaviourExtensions
{
    ///<summary>
    ///Sets MonoBehaviour dirty
    ///</summary>
    public static void SetSelfDirty(this MonoBehaviour monoBehaviour)
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(monoBehaviour);
#endif
    }

    #region InvokeAction
    
    ///<summary>
    ///Invokes action with delay
    ///<param name = "delay">delay in seconds before invoking Action </param>
    ///<param name = "action">Action to invoke</param>
    ///</summary>
    public static async void Invoke(this MonoBehaviour monoBehaviour, float delay, Action action)
    {
        await UniTask.WaitForSeconds(delay, cancellationToken: monoBehaviour.destroyCancellationToken);
        action.Invoke();
    }

    ///<summary>
    ///Invokes action with delay
    ///<param name = "frames">delay in frames before invoking Action </param>
    ///<param name = "action">Action to invoke</param>
    ///</summary>
    public static async void Invoke(this MonoBehaviour monoBehaviour, int frames, Action action)
    {
        await UniTask.DelayFrame(frames, cancellationToken: monoBehaviour.destroyCancellationToken);
        action.Invoke();
    }
    
    #endregion

    #region UniTaskWait
    
    public static UniTask WaitSeconds(this MonoBehaviour monoBehaviour, float secondsDelay, bool ignoreTimeScale = false, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
    {
        return UniTask.WaitForSeconds(secondsDelay, ignoreTimeScale, delayTiming, monoBehaviour.destroyCancellationToken);
    }

    public static UniTask WaitFrame(this MonoBehaviour monoBehaviour, int framesDelay = 1, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
    {
        return UniTask.DelayFrame(framesDelay, delayTiming, monoBehaviour.destroyCancellationToken);
    }
    
    public static UniTask WaitSeconds(this MonoBehaviour monoBehaviour, float secondsDelay, CancellationToken cancellationToken, bool ignoreTimeScale = false, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
    {
        return UniTask.WaitForSeconds(secondsDelay, ignoreTimeScale, delayTiming, cancellationToken);
    }

    public static UniTask WaitFrame(this MonoBehaviour monoBehaviour, CancellationToken cancellationToken, int framesDelay = 1, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
    {
        return UniTask.DelayFrame(framesDelay, delayTiming, cancellationToken);
    }

    #endregion

    #region Enable/Disable
    
    /// <summary>Enables MonoBehaviour</summary>
    public static void SetEnabled(this MonoBehaviour monoBehaviour)
    {
        monoBehaviour.enabled = true;
    }
    
    /// <summary>Enables or disables MonoBehaviour</summary>
    public static void SetEnabled(this MonoBehaviour monoBehaviour, bool enabled)
    {
        monoBehaviour.enabled = enabled;
    }
    
    /// <summary>Enables MonoBehaviour</summary>
    /// <param name="delay">Time after which MonoBehaviour will be enabled or disabled.</param>
    public static void SetEnabled(this MonoBehaviour monoBehaviour, float delay)
    {
        monoBehaviour.SetEnabled(true, delay);
    }
    
    /// <summary>Enables or disables MonoBehaviour</summary>
    /// <param name="delay">Time after which MonoBehaviour will be enabled or disabled.</param>
    public static async void SetEnabled(this MonoBehaviour monoBehaviour, bool enabled, float delay)
    {
        await monoBehaviour.WaitSeconds(delay);
        monoBehaviour.enabled = enabled;
    }
    
    /// <summary>Enables MonoBehaviour</summary>
    /// <param name="frames">Frames after which MonoBehaviour will be enabled or disabled.</param>
    public static void SetEnabled(this MonoBehaviour monoBehaviour, int frames)
    {
        monoBehaviour.SetEnabled(true, frames);
    }
    
    /// <summary>Enables or disables MonoBehaviour</summary>
    /// <param name="frames">Frames after which MonoBehaviour will be enabled or disabled.</param>
    public static async void SetEnabled(this MonoBehaviour monoBehaviour, bool enabled, int frames)
    {
        await monoBehaviour.WaitFrame(frames);
        monoBehaviour.enabled = enabled;
    }

    /// <summary>Disables MonoBehaviour</summary>
    public static void SetDisabled(this MonoBehaviour monoBehaviour)
    {
        monoBehaviour.enabled = false;
    }

    /// <summary>Disables MonoBehaviour</summary>
    /// <param name="delay">Time after which MonoBehaviour will be enabled or disabled.</param>
    public static void SetDisabled(this MonoBehaviour monoBehaviour, float delay)
    {
        monoBehaviour.SetEnabled(false, delay);
    }

    /// <summary>Disables MonoBehaviour</summary>
    /// <param name="frames">Frames after which MonoBehaviour will be enabled or disabled.</param>
    public static void SetDisabled(this MonoBehaviour monoBehaviour, int frames)
    {
        monoBehaviour.SetEnabled(false, frames);
    }
    
    #endregion

}
