using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachinemovCamera : MonoBehaviour
{
    public static cinemachinemovCamera instance;
    private CinemachineVirtualCamera cinemachineVirtualcamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultichannelPerlin;

    private float tiempoMovimiento;
    private float tiempoMovimientoTotal;
    private float insensidadInicial;

    private void Awake()
    {
        instance = this;
        cinemachineVirtualcamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultichannelPerlin = cinemachineVirtualcamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    void Update()
    {
        if(tiempoMovimiento > 0)
        {
            tiempoMovimiento -= Time.deltaTime;
            cinemachineBasicMultichannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(insensidadInicial, 0, 1 - (tiempoMovimiento / tiempoMovimientoTotal));
        }
    }

    public void moverCamara(float insensidad, float frecuencia, float tiempo)
    {
        cinemachineBasicMultichannelPerlin.m_AmplitudeGain = insensidad;
        cinemachineBasicMultichannelPerlin.m_FrequencyGain = frecuencia;
        insensidadInicial = insensidad;
        tiempoMovimientoTotal = tiempo;
        tiempoMovimiento = tiempo;
    }
}
