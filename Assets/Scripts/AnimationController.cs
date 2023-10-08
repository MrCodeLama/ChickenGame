using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private bool _isGameOver;
    public float speed;
    private SpeedController speedController;
    void Start()
    {
        speedController = Camera.main.GetComponent<SpeedController>();
    }
    void Update()
    {
        _isGameOver = Camera.main.GetComponent<PlayMode>()._isGameOver;
        speed = _isGameOver ? 0f : speedController.speed;

        GameObject[] skins = GameObject.FindGameObjectsWithTag("Skin");
            foreach (var el in skins)
            {
                el.GetComponent<Animator>().speed = speed*0.7f;
            }
    }
    
}
