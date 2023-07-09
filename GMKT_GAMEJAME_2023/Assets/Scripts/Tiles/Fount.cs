using UnityEngine;
using EffectType;

public class Fount : DefaultTile
{
    public override void GetEffect(GameObject playerProjectile)
    {
        BulletCharacter bulletCharacter = playerProjectile.GetComponent<BulletCharacter>();
        if (bulletCharacter == null)
            return;

        if (EffectTypes.None == bulletCharacter.type)
        {
            bulletCharacter.type = EffectTypes.Water;
            playerProjectile.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
