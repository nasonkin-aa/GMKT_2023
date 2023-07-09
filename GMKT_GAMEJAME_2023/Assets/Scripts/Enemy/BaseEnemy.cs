using UnityEngine;
using EffectType;
using System;
using System.Collections.Generic;
using ShootType;
using UnityEngine.Events;

public class BaseEnemy : Entity
{    
    public EffectTypes _type;
    public float cooldown = 2;
    public ShootTypes shootType;    
    public float angleBetweenShots;
    public int numberOfShots;
    public int bulletSpeed = 5;
    public GameObject bulletSpawnPoint;
    public UnityEvent OnDie;

    private Character _character = Character.Instance;
    private GameObject _bulletPrefab;
    private float cooldownTime;
    private Shoot _shooter;
    private bool _isAttackPosible = false;

    public List<Sprite> spriteMagic;

    private void Awake()
    {
        string prefabName = _type.ToString() + "Bullet";

        if (_type == EffectTypes.None)
            prefabName = "Bullet";
        
        switch (_type)
        {
            case EffectTypes.Fire:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteMagic[0];
                break;
            case EffectTypes.Water:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteMagic[1];
                break;
            case EffectTypes.Ice:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteMagic[2];
                break;
            case EffectTypes.Rock:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteMagic[3];
                break;
        }

        _bulletPrefab = Resources.Load<GameObject>(prefabName);

        if (_bulletPrefab == null)
            _bulletPrefab = Resources.Load<GameObject>("Bullet");

        _bulletPrefab.GetComponent<Bullet>().type = _type;

        Type classType = Type.GetType(shootType.ToString());

        if (classType != null)
        {
            object instance;
            switch (shootType)
            {
                case ShootTypes.ShotgunShoot:
                    instance = Activator.CreateInstance(classType, new object[] { _bulletPrefab, bulletSpeed, angleBetweenShots, numberOfShots });
                    break;
                default:
                    instance = Activator.CreateInstance(classType, new object[] { _bulletPrefab, bulletSpeed });
                    break;
            }
            _shooter = (Shoot)instance;
        }

        TakeBulletSpawnPoint();
        AddListenersForAggressiveZone();
    }
    protected virtual void Start()
    {
        cooldownTime = cooldown;
        _character = Character.Instance;
    }

    void Update()
    {
        if (_isAttackPosible)
        {
            Rotate();
            Shoot();
        }
        Move();
    }

    protected virtual void Move()
    {
        return;
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

        float angleRadians = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float x = Mathf.Cos(angleRadians);
        float y = Mathf.Sin(angleRadians);
        
        _shooter?.Fire(bulletSpawnPoint.transform.position, new Vector2(x, y).normalized, LayerMask.NameToLayer("EnemyBullet"), _type);
    }

    private void Rotate()
    {
        if (!_character)
            return;

        Vector2 direction = _character.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(Math.Abs(angle));
        
        gameObject.GetComponent<SpriteRenderer>().flipY = Math.Abs(angle) > 90;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }

    private void TakeBulletSpawnPoint()
    {
        BulletSpawnPoint spawnPoint = GetComponentInChildren<BulletSpawnPoint>();
        if (spawnPoint)
            bulletSpawnPoint = spawnPoint.gameObject;
    }

    private void AddListenersForAggressiveZone()
    {
        AggressionZone aggressiveZone = GetComponentInChildren<AggressionZone>();
        if (aggressiveZone == null)
            return;

        Debug.Log("0000");
        aggressiveZone.OnPlayerEnter.AddListener(OnPlayerEnterAggressionZone);
        aggressiveZone.OnPlayerExit.AddListener(OnPlayerExitAggressionZone);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.GetComponent<BulletCharacter>() 
            && TypeMatching.IsKilled(other.gameObject.GetComponent<BulletCharacter>().type,
                _type))
        {
            Debug.Log("die");
            Die();
        }      
    }

    protected virtual void Die()
    {
        SoundManager.PlaySound(SoundManager.Sound.EnemyDestroy);
        OnDie.Invoke();
        Destroy(gameObject);
    }

    protected virtual void OnPlayerEnterAggressionZone()
    {
        _isAttackPosible = true;
    }

    protected virtual void OnPlayerExitAggressionZone()
    {
        Debug.Log("Exit");
        _isAttackPosible = false;
    }
}
