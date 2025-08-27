using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static partial class SkinnedMeshRendererExtensions
{
    /// <summary>
    /// Animates blend shape to endValue 
    /// </summary>
    public static async UniTask AnimateBlendShape(this SkinnedMeshRenderer rend, int id, float beginValue = 0f, float endValue = 100f, float time = 1f)
    {
        await rend.AnimateBlendShape(id, rend.GetCancellationTokenOnDestroy(), beginValue, endValue, time);
    }

    /// <summary>
    /// Animates blend shape to endValue 
    /// </summary>
    public static async UniTask AnimateBlendShape(this SkinnedMeshRenderer rend, int id, CancellationToken token, float beginValue = 0f, float endValue = 100f, float time = 1f)
    {
        float elapsed = 0;
        while (elapsed < time)
        {
            await UniTask.WaitForEndOfFrame(token);

            elapsed += Time.deltaTime;
            rend.SetBlendShapeWeight(id, Mathf.Lerp(beginValue, endValue, Mathf.InverseLerp(0, time, elapsed)));
        }

        rend.SetBlendShapeWeight(id, endValue);
    }
    
    /// <summary>
    /// Animates blend shape to endValue and then back
    /// </summary>
    public static async UniTask AnimateBlendShapePunch(this SkinnedMeshRenderer rend, int id, float beginValue = 0f, float endValue = 100f, float time = 1f)
    {
        await rend.AnimateBlendShapePunch(id, rend.GetCancellationTokenOnDestroy(), beginValue, endValue, time);
    }

    /// <summary>
    /// Animates blend shape to endValue and then back
    /// </summary>
    public static async UniTask AnimateBlendShapePunch(this SkinnedMeshRenderer rend, int id, CancellationToken token, float beginValue = 0f, float endValue = 100f, float time = 1f)
    {
        time *= .5f;
        await AnimateBlendShape(rend, id, token, beginValue, endValue, time);
        await AnimateBlendShape(rend, id, token, endValue, beginValue, time);
    }
}
