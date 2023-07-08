using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl
{
    private Transform _transform;
    private float _speed = 5f;
   
    public CharacterControl(Transform transform , float speed)
    {
        _speed = speed;
        _transform = transform;
    }
    
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized * _speed * Time.deltaTime;
        _transform.Translate(movement);
    }
}
