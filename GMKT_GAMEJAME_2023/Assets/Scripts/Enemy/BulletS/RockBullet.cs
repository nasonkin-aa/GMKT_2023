using UnityEngine;

public class RockBullet : Bullet
{
    public override void GetEffect(GameObject playerProjectile)
    {
        base.GetEffect(playerProjectile);
        Destroy(gameObject);
    }
}
