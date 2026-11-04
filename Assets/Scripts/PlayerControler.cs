using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movementSpeed; 
    [SerializeField] private float _minX = -7.5f;

    [SerializeField] private float _maxX = 7.5f;
    [SerializeField] private float _minY = -4.5f;

    [SerializeField] private float _maxY = 4.5f;
    Rigidbody2D rb2d;    
    InputAction moveAction;
    [SerializeField] public float player1Health = 100;
    [SerializeField] public float player2Health = 100;
    void Start()
    {
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
