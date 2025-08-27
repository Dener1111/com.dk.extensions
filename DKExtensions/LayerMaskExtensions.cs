using UnityEngine;

public static partial class LayerMaskExtensions
{
    ///<summary>
    ///Returns true if LayerMask includes passed layer
    ///</summary>
    public static bool Includes(this LayerMask mask, int layer) => (mask.value & 1 << layer) > 0;

    ///<summary>
    ///Returns true if LayerMask excludes passed layer
    ///</summary>
    public static bool Excludes(this LayerMask mask, int layer) => !mask.Includes(layer);

    ///<summary>
    ///Returns true if LayerMask includes passed GameObject's layer
    ///</summary>
    public static bool Includes(this LayerMask mask, GameObject target) => mask.Includes(target.layer);

    ///<summary>
    ///Returns true if LayerMask excludes passed GameObject's layer
    ///</summary>
    public static bool Excludes(this LayerMask mask, GameObject target) => !mask.Includes(target);

    ///<summary>
    ///Returns true if LayerMask includes passed Component's layer
    ///</summary>
    public static bool Includes(this LayerMask mask, Component target) => mask.Includes(target.gameObject.layer);

    ///<summary>
    ///Returns true if LayerMask excludes passed Component's layer
    ///</summary>
    public static bool Excludes(this LayerMask mask, Component target) => !mask.Includes(target);

    ///<summary>
    ///Returns LayerMask extracted from layer index
    ///</summary>
    public static LayerMask ToMask(this int layer) => 1 << layer;

    ///<summary>
    ///Returns LayerMask extracted from GameObject
    ///</summary>
    public static LayerMask ToMask(this GameObject target) => target.layer.ToMask();
    
    ///<summary>
    ///Returns LayerMask extracted from Component
    ///</summary>
    public static LayerMask ToMask(this Component target) => target.gameObject.layer.ToMask();

    ///<summary>
    ///Returns Layer index
    ///</summary>
    public static int ToLayer(this LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while(layer > 0) {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }
}
