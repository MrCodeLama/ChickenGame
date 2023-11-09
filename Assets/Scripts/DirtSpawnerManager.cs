using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpawnerManager : MonoBehaviour
{
    private SpeedController speedcntrl;
    private PlayerController playercntrl;
    private GameObject dirt;
    public float speed;
    public bool _isOnGround;
    public bool _isGameOver;
    void Start()
    {
        speedcntrl = gameObject.GetComponent<SpeedController>();
        playercntrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dirt = GameObject.FindGameObjectWithTag("Dirt");
    }

    void Update()
    {
        _isGameOver = playercntrl._isGameOver;
        if (!_isGameOver)
        {
            _isOnGround = playercntrl._isOnGround;
            dirt.GetComponent<ParticleSystem>().maxParticles = (_isOnGround) ? 100 : 0;
            speed = speedcntrl.speed;
            var velocityOverLifetimeModule = dirt.GetComponent<ParticleSystem>().velocityOverLifetime;
            velocityOverLifetimeModule.speedModifier = speed * 0.5f;
        }
        else
        {
            dirt.GetComponent<ParticleSystem>().maxParticles = 0;
        }
        
    }
}
