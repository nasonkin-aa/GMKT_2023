using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    
    private CinemachineVirtualCamera _cinemahineCamera;
    private CinemachineBasicMultiChannelPerlin _cameraModule;
    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startingIntensity;
    private void Awake()
    {
        Instance = this;
        _cinemahineCamera = GetComponent<CinemachineVirtualCamera>();
        _cameraModule =
            _cinemahineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float intensity = 2f, float time = 0.4f)
    {
        _cameraModule.m_AmplitudeGain = intensity;
        _startingIntensity = intensity;
        _shakeTimerTotal = time;
        _shakeTimer = time;
    }

    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            _cameraModule.m_AmplitudeGain = Mathf.Lerp(0f, _startingIntensity, _shakeTimer / _shakeTimerTotal);
        }
    }
}
