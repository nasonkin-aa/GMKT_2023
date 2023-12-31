using UnityEngine;

public class BulletCharacter : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet enemyProjectile = other.gameObject.GetComponent<Bullet>();
        if (enemyProjectile == null)
        {
            DefaultTile tile = other.gameObject.GetComponent<DefaultTile>();
            if (tile == null)
                return;
            SoundManager.PlaySound(SoundManager.Sound.BulletTouch);

            tile.GetEffect(gameObject);
            return;
        }


        enemyProjectile.GetEffect(gameObject);
    }
}


