using UnityEngine;
using EffectType;
using System;
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

    private void Awake()
    {
        string prefabName = _type.ToString() + "Bullet";

        if (_type == EffectTypes.None)
            prefabName = "Bullet";

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
    }
    protected virtual void Start()
    {
        cooldownTime = cooldown;
        _character = Character.Instance;
    }

    void Update()
    {
        Rotate();
        Shoot();
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
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void TakeBulletSpawnPoint()
    {
        BulletSpawnPoint spawnPoint = GetComponentInChildren<BulletSpawnPoint>();
        if (spawnPoint)
            bulletSpawnPoint = spawnPoint.gameObject;
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletCharacter>() 
            && TypeMatching.IsKilled(other.gameObject.GetComponent<BulletCharacter>().type,
                _type))
        {
            Die();
        }
      
    }

    protected virtual void Die()
    {
        OnDie.Invoke();
        Destroy(gameObject);
    }
}
