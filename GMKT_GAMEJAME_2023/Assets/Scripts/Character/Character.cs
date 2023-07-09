using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : Entity
{
    public static Character Instance { get; private set; }
    public  CharacterControl _characterControl;
    private Camera mainCamera; // Ссылка на главную камеру
    private int hpInt = 0;

    public List<Image> hp;

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

    [Obsolete("Obsolete")]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            var particle = gameObject.GetComponent<ParticleSystem>();
            particle.startColor = other.gameObject.GetComponent<Renderer>().material.color;
            particle.Play();
            CameraShake.Instance.Shake();
            if (hpInt < 2)
            {
                Debug.Log(SceneManager.sceneCount);
                hpInt++;
                Destroy(hp[hp.Count - hpInt]);
            }
            else
            {
                SceneManagers.Restart();
            }
        }
    }
    public void FlipCharacter()
    {
        Vector3 cursorScreenPos = Input.mousePosition;

        Vector3 cursorWorldPos = mainCamera.ScreenToWorldPoint(cursorScreenPos);
        cursorWorldPos.y = transform.position.y;
        Vector3 direction = cursorWorldPos - transform.position;

        transform.GetComponent<SpriteRenderer>().flipX = direction.x >= 0f;

    }
}
