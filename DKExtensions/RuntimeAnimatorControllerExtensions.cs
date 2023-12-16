using UnityEngine;

public static partial class RuntimeAnimatorControllerExtension
{
    ///<summary>
    ///Returns AnimatorOverrideController
    ///</summary>
    public static AnimatorOverrideController CreateOverride(this RuntimeAnimatorController animatorController, string overrideName = "")
    {
        AnimatorOverrideController animatorOverrideController= new AnimatorOverrideController();
        animatorOverrideController.runtimeAnimatorController= animatorController;
        animatorOverrideController.name = overrideName;
        return animatorOverrideController;
    }
}
