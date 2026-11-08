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

    private double lastMoveTime = 0.0f;
    private Vector3 targetPosition;
    public float smoothTime = 0.4f;
    

    void Start()
    {
        bossHealth = maxBossHealth;
        transform.position = ClampBossPosition(transform.position);
        targetPosition = new Vector3(transform.position.x, 3.0f, 0f);
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

        if (Time.time - lastMoveTime > 2.5f)
        {
            lastMoveTime = Time.time;

            Vector3 pos = transform.position;
            float nextX = Random.Range(pos.x - 1f, pos.x + 1f);


            nextX = Mathf.Clamp(nextX, _minX, _maxX);



            targetPosition = new Vector3(nextX, 3.0f, 0f);
        }

        transform.position = ClampBossPosition(
            Vector3.MoveTowards(transform.position, targetPosition, smoothTime * Time.deltaTime));
    }

    private Vector3 ClampBossPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, _minX, _maxX);
        position.y = 3.0f;
        position.z = 0f;
        return position;
    }

    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
