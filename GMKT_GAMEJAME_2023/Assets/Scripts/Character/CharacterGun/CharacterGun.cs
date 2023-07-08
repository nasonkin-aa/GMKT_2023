using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using EffectType;

public class CharacterGun : MonoBehaviour
{
    public Transform firePoint;
    private GameObject _bulletPrefab;
    public EffectTypes _type = EffectTypes.None;
    Vector3 direction;
    private Camera mainCamera;
    
    private void Awake()
    {
        _bulletPrefab = Resources.Load<GameObject>("BulletChar");
        _bulletPrefab.GetComponent<Bullet>().type = _type;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; 

         direction = mousePosition - transform.position;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        transform.rotation = rotation;
    }
    void Shoot()
    {
        GameObject spawnedObject = Instantiate(_bulletPrefab, firePoint.position, Quaternion.identity);
        spawnedObject.GetComponent<Bullet>().type = _type;
        spawnedObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * 5;
        spawnedObject.layer = LayerMask.NameToLayer("CharacterBullet");

    }
}
