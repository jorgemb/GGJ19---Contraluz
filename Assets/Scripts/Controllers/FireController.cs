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
    public float fireVariation = 0.5f;

    public float startDelay = 120.0f;
    public float dimPerSecond = 0.42f;


    const float maxFire = 3.0f;
    bool fireStartDim = false;
    float fireTime = 0.0f;

    // Components
    ParticleSystem particles;
    Light childLight;

    public void AddIntensity()
    {
        fireIntensity = Mathf.Clamp(fireIntensity + 1.0f, 0.0f, maxFire);
    }

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        childLight = GetComponentInChildren<Light>();
    }

    void Update()
    {
        // Check dimming
        if (!fireStartDim)
        {
            // Initial state
            fireTime += Time.deltaTime;
            if (fireTime > startDelay) fireStartDim = true;
        } else
        {
            fireIntensity -= dimPerSecond / 100.0f * Time.deltaTime;
            fireIntensity = Mathf.Clamp(fireIntensity, 0.0f, maxFire);
        }


        float sin_result = Mathf.Sin(Time.time * changeVelocity);

        // Change fire
        float fireRatio = fireIntensity / maxFire;
        float realIntensityStart = fireRatio * intensityStart;

        float fireStrength = Mathf.Clamp(fireRatio * 2.0f + (sin_result * fireVariation), 0.0f, maxFire);
        if (fireIntensity == 0.0f)
            fireStrength = 0.0f;

        var main = particles.main;
        main.startSize = fireStrength;

        // Change light
        if (fireIntensity > 0.0f)
            childLight.intensity = Mathf.Clamp(sin_result * intensityVariation + realIntensityStart + Random.Range(-flickerRange, flickerRange), 0.1f, 3.5f);
        else
            childLight.intensity = 0.0f;
    }
}
