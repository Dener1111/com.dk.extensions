#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using Cysharp.Threading.Tasks;

public partial struct UniTask
{
    public static UniTask WaitForSeconds(float secondsDelay, bool ignoreTimeScale = false, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
    {
        var delayTimeSpan = System.TimeSpan.FromSeconds(secondsDelay);
        return Cysharp.Threading.Tasks.Internal.Delay(delayTimeSpan, ignoreTimeScale, delayTiming, cancellationToken);
    }

    public static UniTask WaitForSeconds(float secondsDelay, DelayType delayType, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
    {
        var delayTimeSpan = System.TimeSpan.FromSeconds(secondsDelay);
        return Cysharp.Threading.Tasks.Internal.Delay(delayTimeSpan, delayType, delayTiming, cancellationToken);
    }

}
