using UnityEngine;
using EffectType;

public class WaterTile : DefaultTile
{
    public override void GetEffect(GameObject playerProjectile)
    {
        BulletCharacter bulletCharacter = playerProjectile.GetComponent<BulletCharacter>();
        if (bulletCharacter == null)
            return;

        if (EffectTypes.Ice == bulletCharacter.type)
        {
            _type = EffectTypes.Ice;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(playerProjectile);
        }
    }
}
