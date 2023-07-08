using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EffectType;
public static class TypeMatching
{
    public static bool IsKilled(EffectTypes bulletType, EffectTypes enemTypes)
    {
        switch (bulletType)
        {
            
            case EffectTypes.Rock:
                if (enemTypes == EffectTypes.Rock)
                {
                    return true;
                }
                break;
            case EffectTypes.Fire:
                if (enemTypes == EffectTypes.Water)
                {
                    return true;
                }
                break;
            case EffectTypes.Water:
                if (enemTypes == EffectTypes.Fire)
                {
                    return true;
                }
                break;
            default:
                return false;
            break;
        }

        return false;
    }
}
