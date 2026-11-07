using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class BossControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bossHealth;
    [SerializeField] public float maxBossHealth = 1000;
    private float _minX = -5.0f;

    private float _maxX = 5.0f;
    private float _minY = 2.0f;

    private float _maxY = 4.0f;
    void Start()
    {
        bossHealth = maxBossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            DestroyBoss();
            Debug.Log("Boss Destroyed");
            PlayerControler.SuppressGameOver();
            SceneManager.LoadScene("GameClear");
        }
    }

    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
