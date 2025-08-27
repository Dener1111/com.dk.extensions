using UnityEngine;

public static partial class LODGroupExtensions
{
    public static int GetCurrentLODIndex(this LODGroup lodGroup)
    {
        LOD[] lods = lodGroup.GetLODs();
        for (int i = 0; i < lods.Length; i++)
        {
            LOD lod = lods[i];

            if (lod.renderers.Length == 0)
                continue;

            for (int j = 0; j < lod.renderers.Length; j++)
                if (lod.renderers[j].isVisible)
                    return i;
        }

        return -1;
    }
}