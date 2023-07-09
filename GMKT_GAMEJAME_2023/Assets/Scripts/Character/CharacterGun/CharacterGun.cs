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
            SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
        }
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        direction = mousePosition - transform.position;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.right, direction);
        var fLocalPosition = gameObject.transform.GetChild(0).localPosition;
        if (gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            if (fLocalPosition.y < 0)
            {
                fLocalPosition.y = -fLocalPosition.y;
            }
            gameObject.transform.GetChild(0).localPosition = fLocalPosition;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            if (fLocalPosition.y > 0)
            {
                fLocalPosition.y = -fLocalPosition.y;
            }
            gameObject.transform.GetChild(0).localPosition = fLocalPosition;
        }
        
        transform.rotation = rotation;
        

    }
    void Shoot()
    {
        GameObject spawnedObject = Instantiate(_bulletPrefab, firePoint.position, Quaternion.FromToRotation(Vector3.right, direction));
        spawnedObject.GetComponent<Bullet>().type = _type;
        spawnedObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * 5;
        spawnedObject.layer = LayerMask.NameToLayer("CharacterBullet");

    }
}
