using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpawnerManager : MonoBehaviour
{
    private SpeedController speedCntrl;
    private PlayerController playerCntrl;
    private GameObject dirt;
    private float speed;
    private bool _isOnGround;
    private bool _isGameOver;
    void Start()
    {
        speedCntrl = gameObject.GetComponent<SpeedController>();
        playerCntrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dirt = GameObject.FindGameObjectWithTag("Dirt");
    }

    void Update()
    {
        _isGameOver = playerCntrl._isGameOver;
        if (!_isGameOver)
        {
            _isOnGround = playerCntrl._isOnGround;
            dirt.GetComponent<ParticleSystem>().maxParticles = (_isOnGround) ? 100 : 0;
            speed = speedCntrl.speed;
            var velocityOverLifetimeModule = dirt.GetComponent<ParticleSystem>().velocityOverLifetime;
            velocityOverLifetimeModule.speedModifier = speed * 0.5f;
        }
        else
        {
            dirt.GetComponent<ParticleSystem>().maxParticles = 0;
        }
        
    }
}
