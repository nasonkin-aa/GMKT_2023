using UnityEngine;
using EffectType;

public class WaterTile : DefaultTile
{
    [SerializeField]
    public Sprite newSprite; 
    
    public override void GetEffect(GameObject playerProjectile)
    {
        BulletCharacter bulletCharacter = playerProjectile.GetComponent<BulletCharacter>();
        if (bulletCharacter == null)
            return;

        if (EffectTypes.Ice == bulletCharacter.type)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
            _type = EffectTypes.Ice;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(playerProjectile);
        }
    }
}
