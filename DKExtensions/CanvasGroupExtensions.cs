using UnityEngine;
using Cysharp.Threading.Tasks;

public static partial class CanvasGroupExtensions
{
    /// <summary>Animate CanvasGroup's alpha</summary>
    /// <param name="endValue">Value of CanvasGroup.alpha at the end of animation.</param>
    /// <param name="animTime">Animation time.</param>
    /// <param name="adjustAnimTime">Reduce animation time if it was in between 0 and 1.</param>
    public static async void AnimateAlpha(this CanvasGroup target, float endValue, float animTime, bool adjustAnimTime = true)
    {
        //if target.alpha was between 0 and 1 lowering the time it takes to animate 
        if (adjustAnimTime)
            animTime *= Mathf.InverseLerp(0, animTime, Mathf.Abs(endValue - target.alpha));

        float elapsed = 0;
        float elapsedNormal = 0;

        while (elapsed < animTime)
        {
            elapsedNormal = Mathf.InverseLerp(0, animTime, elapsed);
            target.alpha = Mathf.Lerp(target.alpha, endValue, elapsedNormal);
            await UniTask.NextFrame(cancellationToken: target.GetCancellationTokenOnDestroy());
            elapsed += Time.deltaTime;
        }
        target.alpha = endValue;
    }
    
    /// <summary>Set CanvasGroup's alpha to 1f</summary>
    public static void Show(this CanvasGroup canvasGroup, bool interactable = true, bool blocksRaycasts = true)
    {
        const float showValue = 1f;
        
        canvasGroup.alpha = showValue;
        canvasGroup.interactable = interactable;
        canvasGroup.blocksRaycasts = blocksRaycasts;
    }
        
    /// <summary>Set CanvasGroup's alpha to 0f</summary>
    public static void Hide(this CanvasGroup canvasGroup, bool interactable = false, bool blocksRaycasts = false)
    {
        const float hideValue = 0f;
        
        canvasGroup.alpha = hideValue;
        canvasGroup.interactable = interactable;
        canvasGroup.blocksRaycasts = blocksRaycasts;
    }
        
    /// <summary>Toggle CanvasGroup's visibility</summary>
    public static void Toggle(this CanvasGroup canvasGroup, bool value)
    {
        if(value) canvasGroup.Show();
        else canvasGroup.Hide();
    }
}
