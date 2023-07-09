using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    public static Character Instance { get; private set; }
    public  CharacterControl _characterControl;
    private Camera mainCamera; // Ссылка на главную камеру


    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        mainCamera = Camera.main;
        _characterControl = new CharacterControl(transform, _speed);
    }
    void Update()
    {
        _characterControl.Move();
        FlipCharacter();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Debug.Log("GetDamage");
        }
    }
    public void FlipCharacter()
    {
        Vector3 cursorScreenPos = Input.mousePosition;

        Vector3 cursorWorldPos = mainCamera.ScreenToWorldPoint(cursorScreenPos);
        cursorWorldPos.y = transform.position.y; 

        Vector3 direction = cursorWorldPos - transform.position;

        transform.GetComponent<SpriteRenderer>().flipX = (direction.x >= 0f) ? transform.GetComponent<SpriteRenderer>().flipX = true
            : transform.GetComponent<SpriteRenderer>().flipX = false;

    }
}
