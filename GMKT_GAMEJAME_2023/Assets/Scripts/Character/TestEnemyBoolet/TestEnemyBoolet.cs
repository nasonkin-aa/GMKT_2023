using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBoolet : MonoBehaviour
{
    private float _speed = 5f;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.up * _speed;
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletCharacter>())
        {
            _rigidbody.velocity = other.transform.GetComponent<Rigidbody2D>().velocity.normalized * _speed;
        }
    }
    
}
