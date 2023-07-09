using UnityEngine;

public class BulletCharacter : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet enemyProjectile = other.gameObject.GetComponent<Bullet>();
        if (enemyProjectile == null)
            return;

        enemyProjectile.GetEffect(gameObject);
    }
}
