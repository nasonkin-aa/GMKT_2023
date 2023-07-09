using UnityEngine;

public class BulletCharacter : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet enemyProjectile = other.gameObject.GetComponent<Bullet>();
        if (enemyProjectile == null)
            return;
        SoundManager.PlaySound(SoundManager.Sound.BulletTouch);
        enemyProjectile.GetEffect(gameObject);
    }
}


