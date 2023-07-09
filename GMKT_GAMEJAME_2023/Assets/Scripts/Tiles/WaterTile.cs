using UnityEngine;
using EffectType;

public class WaterTile : DefaultTile
{
    
    public Sprite newSprite; 

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void GetEffect(GameObject playerProjectile)
    {
        BulletCharacter bulletCharacter = playerProjectile.GetComponent<BulletCharacter>();
        if (bulletCharacter == null)
            return;

        if (EffectTypes.Ice == bulletCharacter.type)
        {
            spriteRenderer.sprite = newSprite;
            _type = EffectTypes.Ice;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(playerProjectile);
        }
    }
}
