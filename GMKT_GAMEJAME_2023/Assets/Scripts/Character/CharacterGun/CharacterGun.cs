using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CharacterGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Camera mainCamera;
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

        Vector3 direction = mousePosition - transform.position;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        transform.rotation = rotation;
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
