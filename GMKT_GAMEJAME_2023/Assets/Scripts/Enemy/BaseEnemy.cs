using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyType;

public class BaseEnemy : Entity
{
    private Character _character = Character.Instance;
    GameObject _bulletPrefab;
    public EnemyTypes _type;
    public float cooldown = 2;
    private float cooldownTime;

    private void Awake()
    {
        _bulletPrefab = Resources.Load<GameObject>("Bullet");
        _bulletPrefab.GetComponent<Bullet>().type = _type;
    }
    void Start()
    {
        cooldownTime = cooldown;
        _character = Character.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        RotateToCharacter();
        Shoot();
    }

    private void Shoot()
    {
        if (cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
            return;
        }
        else
            cooldownTime = cooldown;

        if (!_bulletPrefab)
            return;

        GameObject spawnedObject = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

        float angleRadians = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float x = Mathf.Cos(angleRadians);
        float y = Mathf.Sin(angleRadians);

        spawnedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y).normalized * 5;
        
    }

    private void RotateToCharacter()
    {
        if (!_character)
            return;

        Vector2 direction = _character.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


}

namespace EnemyType
{
    public enum EnemyTypes
    {
        Fire,
        Water
    }
}
