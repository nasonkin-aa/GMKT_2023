using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnerEnemyBullet : MonoBehaviour
{
  
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timer = 2f; 
    private float elapsedTime = 0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timer)
        {
            Shoot();
            elapsedTime = 0f;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
