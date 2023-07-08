using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : Shoot
{
    private float _angleBetweenShots = 45f;
    private int _numberOfShots = 7;
    public ShotgunShoot(GameObject projectile, float speed, float angleBetweenShots, int numberOfShots) : base(projectile, speed)
    {
        _angleBetweenShots = angleBetweenShots;
        _numberOfShots = numberOfShots;
    }

    public ShotgunShoot(GameObject projectile, float speed) : base(projectile, speed)
    {
        _angleBetweenShots = 15;
        _numberOfShots = 5;
    }

    public override void Fire(Vector2 spawnPoint, Vector2 direction)
    {
        base.Fire(spawnPoint, direction);
        for (int i = 1; i <= ((_numberOfShots - 1) / 2); i++)
        {
            Vector2 newDerection = CreateNewDerection(direction, i * _angleBetweenShots);
            base.Fire(spawnPoint, newDerection);

            newDerection = CreateNewDerection(direction, -i * _angleBetweenShots);
            base.Fire(spawnPoint, newDerection);
        }
    }

    private Vector2 CreateNewDerection(Vector2 direction, float angle)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        return rotation * direction;
    }
}
