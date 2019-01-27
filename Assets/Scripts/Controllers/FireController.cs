using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // Public options
    [Header("Light Controls")]
    public float intensityVariation = 1.0f;
    public float intensityStart = 2.5f;
    public float changeVelocity = 1.1f;
    public float flickerRange = 0.1f;

    [Header("Fire Control")]
    [Range(0.0f, 3.0f)]
    public float fireIntensity = 3.0f;

    // Components
    ParticleSystem particles;
    Light childLight;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        childLight = GetComponentInChildren<Light>();
    }

    void Update()
    {
        // Change fire
        float fireRatio = fireIntensity / 3.0f;
        float realIntensityStart = fireRatio * intensityStart;
        float fireStrength = fireRatio * 2.0f;

        var main = particles.main;
        main.startSize = fireStrength;

        // Change light
        if (fireIntensity > 0.0f)
            childLight.intensity = Mathf.Clamp(Mathf.Sin(Time.time * changeVelocity) * intensityVariation + realIntensityStart + Random.Range(-flickerRange, flickerRange), 0.1f, 3.5f);
        else
            childLight.intensity = 0.0f;
    }
}
