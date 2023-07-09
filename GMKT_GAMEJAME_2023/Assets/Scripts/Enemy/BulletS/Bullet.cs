using System.Collections.Generic;
using UnityEngine;
using EffectType;

public class Bullet : MonoBehaviour
{
    public LayerMask targetLayer;
    public EffectTypes type ;
    private float _speed = 20f;
    private Rigidbody2D _rigidbody;
    protected Renderer _renderer;

    public List<Material> BulletMaterial;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
        switch (type)
        {
            case EffectTypes.None:
                _renderer.material = BulletMaterial[0];
                _renderer.material.color = Color.white;
                break;
            case EffectTypes.Rock:
                _renderer.material = BulletMaterial[1];
                _renderer.material.color = Color.gray;
                break;
            case EffectTypes.Fire:
                _renderer.material = BulletMaterial[2];
                _renderer.material.color = Color.red;
                break;
            case EffectTypes.Water:
                _renderer.material = BulletMaterial[3];
                _renderer.material.color = Color.blue;
                break;
            case EffectTypes.Ice:
                //_renderer.material = BulletMaterial[4];
                _renderer.material.color = Color.cyan;
                break;
            default:
                break;
        }
    }

    public virtual void GetEffect (GameObject playerProjectile)
    {
        BulletCharacter bulletCharacter = playerProjectile.GetComponent<BulletCharacter>();
        if (bulletCharacter == null)
            return;

        if (EffectTypes.None == bulletCharacter.type)
        {
            bulletCharacter.type = type;

            playerProjectile.GetComponent<Renderer>().material = _renderer.material;
            
        }
    } 
}
