using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class BossControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bossHealth;
    [SerializeField] public float maxBossHealth = 1000;

    private float _minX = -5.0f;

    private float _maxX = 5.0f;
    private float _minY = 2.0f;

    private float _maxY = 4.0f;
    private double lastMoveTime = 0.0f;
    private Vector3 targetPosition;
    public float smoothTime = 4f;
    

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

        if (Time.time - lastMoveTime > 4.0f)
        {
            lastMoveTime = Time.time;

            float nextX = Random.Range(_minX, _maxX);
            float nextY = Random.Range(_minY, _maxY);

            Vector3 pos = transform.position;
            targetPosition.x = Mathf.Clamp(nextX, _minX, _maxX);
            targetPosition.y = Mathf.Clamp(nextY, _minY, _maxY);
            targetPosition.z = transform.position.z;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
    }

    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
