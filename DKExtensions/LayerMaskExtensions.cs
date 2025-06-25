using UnityEngine;

public static partial class LayerMaskExtensions
{
    ///<summary>
    ///Returns true if LayerMask includes passed layer
    ///</summary>
    public static bool Includes(this LayerMask mask, int layer)
    {
        return (mask.value & 1 << layer) > 0;
    }

    ///<summary>
    ///Returns true if LayerMask excludes passed layer
    ///</summary>
    public static bool Excludes(this LayerMask mask, int layer)
    {
        return !mask.Includes(layer);
    }

    ///<summary>
    ///Returns true if LayerMask includes passed GameObject's layer
    ///</summary>
    public static bool Includes(this LayerMask mask, GameObject target)
    {
        return mask.Includes(target.layer);
    }

    ///<summary>
    ///Returns true if LayerMask excludes passed GameObject's layer
    ///</summary>
    public static bool Excludes(this LayerMask mask, GameObject target)
    {
        return !mask.Includes(target);
    }

    ///<summary>
    ///Returns LayerMask extracted from layer index
    ///</summary>
    public static LayerMask ToMask(this int layer)
    {
        return 1 << layer;
    }
    
    ///<summary>
    ///Returns LayerMask extracted from GameObject
    ///</summary>
    public static LayerMask ToMask(this GameObject target)
    {
        return target.layer.ToMask();
    }
}
