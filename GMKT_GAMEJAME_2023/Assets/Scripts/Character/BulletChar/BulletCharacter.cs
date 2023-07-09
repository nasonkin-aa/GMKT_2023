using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using EffectType;

public class BulletCharacter : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            if (EffectTypes.None == type)
            {
                type = other.gameObject.GetComponent<Bullet>().type; 
                _renderer.material.color = other.gameObject.GetComponent<Renderer>().material.color;
                Destroy(other.gameObject);
            }
        }
    }
 
}
