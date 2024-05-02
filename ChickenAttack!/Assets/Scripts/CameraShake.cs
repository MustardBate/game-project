using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera CinemachineVirtualCamera;

    //private float startingIntensity;
    //private float shakeTimerTotal;

    private float timer;

    private void Awake()
    {
        Instance = this;
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();    
    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera(float ShakeIntensity, float ShakeTime)
    {
        CinemachineBasicMultiChannelPerlin cmbcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbcp.m_AmplitudeGain = ShakeIntensity;

        //startingIntensity = ShakeIntensity;
        //shakeTimerTotal = timer;

        timer = ShakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cmbcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbcp.m_AmplitudeGain = 0f; /*Mathf.Lerp(startingIntensity, 0f, 1 - (timer/shakeTimerTotal));*/

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }
    }
}
