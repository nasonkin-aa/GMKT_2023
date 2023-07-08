using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    private CharacterControl _characterControl;
    void Start()
    {
        _characterControl = new CharacterControl(transform, _speed);
    }
    void Update()
    {
        _characterControl.Move();   
    }
}
