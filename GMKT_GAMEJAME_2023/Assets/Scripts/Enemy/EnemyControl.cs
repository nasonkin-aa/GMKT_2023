using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    
    public EnemyControl(Transform transform , float speed)
    {
        _speed = speed;
        _transform = transform;
    }
    
}
