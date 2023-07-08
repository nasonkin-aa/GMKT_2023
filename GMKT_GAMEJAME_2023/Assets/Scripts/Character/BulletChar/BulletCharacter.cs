using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletCharacter : MonoBehaviour
{
   private float _speed = 20f;
   private Rigidbody2D _rigidbody;
   
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
      _rigidbody.velocity = transform.up * _speed;
      Destroy(gameObject, 1f);
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<TestEnemyBoolet>())
      {
         Debug.Log("2222");
         Destroy(gameObject);
      }
   }
}
