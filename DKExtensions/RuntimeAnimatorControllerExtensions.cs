using UnityEngine;

public static partial class RuntimeAnimatorControllerExtension
{
    ///<summary>
    ///Returns AnimatorOverrideController
    ///</summary>
    public static AnimatorOverrideController CreateOverride(this RuntimeAnimatorController animatorController)
    {
        AnimatorOverrideController animatorOverrideController= new AnimatorOverrideController();
        animatorOverrideController.runtimeAnimatorController= animatorController;
        return animatorOverrideController;
    }
}
