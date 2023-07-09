using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorLight : MonoBehaviour
{
    Light2D light2D;
    private void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.color = GetComponent<Renderer>().material.color;
    }

    public void ChangeColor()
    {
        light2D.color = GetComponent<Renderer>().material.color;
    }
}
