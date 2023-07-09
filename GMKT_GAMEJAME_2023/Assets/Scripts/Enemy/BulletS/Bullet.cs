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
    private Sprite curSprite;

    public List<Material> BulletMaterial;
    
    public List<Sprite> BulletSpriteRenderers;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
        switch (type)
        {
            case EffectTypes.None:
                _renderer.material = BulletMaterial[0];
                gameObject.GetComponent<SpriteRenderer>().sprite = BulletSpriteRenderers[0];
                curSprite = BulletSpriteRenderers[0];
                _renderer.material.color = Color.white;
                break;
            case EffectTypes.Rock:
                _renderer.material = BulletMaterial[1];
                gameObject.GetComponent<SpriteRenderer>().sprite = BulletSpriteRenderers[1];
                curSprite = BulletSpriteRenderers[1];
                _renderer.material.color = Color.gray;
                break;
            case EffectTypes.Fire:
                _renderer.material = BulletMaterial[2];
                gameObject.GetComponent<SpriteRenderer>().sprite = BulletSpriteRenderers[2];
                curSprite = BulletSpriteRenderers[2];
                _renderer.material.color = Color.red;
                break;
            case EffectTypes.Water:
                _renderer.material = BulletMaterial[3];
                gameObject.GetComponent<SpriteRenderer>().sprite = BulletSpriteRenderers[3];
                curSprite = BulletSpriteRenderers[3];
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
            playerProjectile.GetComponent<SpriteRenderer>().sprite = curSprite;


        }
    } 
}
