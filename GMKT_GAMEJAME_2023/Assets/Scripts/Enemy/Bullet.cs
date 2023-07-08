using System.Collections;
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
    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
        switch (type)
        {
            case EffectTypes.None:
                _renderer.material.color = Color.white;
                break;
            case EffectTypes.Rock:
                _renderer.material.color = Color.gray;
                break;
            case EffectTypes.Fire:
                _renderer.material.color = Color.red;
                break;
            case EffectTypes.Water:
                _renderer.material.color = Color.blue;
                break;
            default:
                break;
        }
    }
   
    
}
