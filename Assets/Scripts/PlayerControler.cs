using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movementSpeed  = 6.0f; 
    private float _minX = -7.5f;

    private float _maxX = 7.5f;
    private float _minY = -4.0f;

    private float _maxY = 4.5f;
    Rigidbody2D rb2d;    
    InputAction moveAction;
    public float player1Health;
    public float player2Health;
    public float maxPlayer1Health = 100f;
    public float maxPlayer2Health = 100f;
    private static int activePlayerCount;
    private static bool hadMultiplePlayers;
    private static bool suppressGameOver;
    private bool isRegistered;

    void Start()
    {
        if (activePlayerCount == 0)
        {
            hadMultiplePlayers = false;
            suppressGameOver = false;
        }

        activePlayerCount++;
        hadMultiplePlayers |= activePlayerCount >= 2;
        isRegistered = true;
        player1Health = maxPlayer1Health;
        player2Health = maxPlayer2Health;
        rb2d = GetComponent<Rigidbody2D>();

        if (gameObject.CompareTag("Player"))
        {
            moveAction = InputSystem.actions["Move_P1"];
        }
        else if (gameObject.CompareTag("Player2"))
        {
            moveAction = InputSystem.actions["Move_P2"];
        }
        moveAction.Enable();
    }

    void OnDestroy()
    {
        if (!isRegistered)
        {
            return;
        }

        activePlayerCount = Mathf.Max(0, activePlayerCount - 1);

        if (activePlayerCount == 0 && hadMultiplePlayers && !suppressGameOver)
        {
            Debug.Log("Both players destroyed");
            hadMultiplePlayers = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    public static void SuppressGameOver()
    {
        suppressGameOver = true;
    }


    // Update is called once per frame
    void Update()
    {
        var x = moveAction.ReadValue<Vector2>().x; 
        var y = moveAction.ReadValue<Vector2>().y; 

        rb2d.linearVelocityX = x * movementSpeed;
        rb2d.linearVelocityY = y * movementSpeed;

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;


        if ((player1Health <= 0) && gameObject.CompareTag("Player"))
        {
            DestroyPlayer();
        }

        if ((player2Health <= 0) && gameObject.CompareTag("Player2"))
        {
            DestroyPlayer();
        }   
    }

        public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
