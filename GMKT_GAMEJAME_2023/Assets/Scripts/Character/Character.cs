using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    public static Character Instance { get; private set; }
    public  CharacterControl _characterControl;

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _characterControl = new CharacterControl(transform, _speed);
    }
    void Update()
    {
        _characterControl.Move();   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Debug.Log("GetDamage");
        }
    }
}
