using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EffectType;

public class DefaultTile : MonoBehaviour
{
    public EffectTypes _type;

    public virtual void GetEffect(GameObject playerProjectile)
    {
        BulletCharacter bulletCharacter = playerProjectile.GetComponent<BulletCharacter>();
        if (bulletCharacter == null)
            return;

        if (EffectTypes.None == bulletCharacter.type)
        {
            Destroy(playerProjectile);
        }
    }
}
