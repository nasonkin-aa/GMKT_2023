using System;
using System.Collections.Generic;
using EffectType;
using UnityEngine;

public class Shoot
{
    protected Vector2 _direction;
    protected GameObject _projectile;
    protected Vector2 _spawnPoint;
    protected float _speed;
    public Shoot(GameObject projectile, float speed)
    {
        _projectile = projectile;
        _speed = speed;
    }

    public virtual void Fire(Vector2 spawnPoint, Vector2 direction,
        LayerMask layer, EffectTypes type = EffectTypes.None)
    {
        if (!_projectile)
            return;
        
        GameObject spawnedObject = BulletSpawner.BulletCreate(_projectile, spawnPoint, Quaternion.identity);

        if (spawnedObject.GetComponent<Rigidbody2D>())
        {
            spawnedObject.GetComponent<Rigidbody2D>().velocity = direction * _speed;
            spawnedObject.layer = layer;
            spawnedObject.GetComponent<Bullet>().type = type;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            spawnedObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
             
        }
            
    }
}

