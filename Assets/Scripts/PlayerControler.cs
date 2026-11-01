using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movementSpeed; 
    Rigidbody2D rb2d;
    
    InputAction moveAction;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions["Move"];
        moveAction.Enable();
    }



    // Update is called once per frame
    void Update()
    {

        var x = moveAction.ReadValue<Vector2>().x; 
        rb2d.linearVelocityX = x * movementSpeed;
        var y = moveAction.ReadValue<Vector2>().y; 
        rb2d.linearVelocityY = y * movementSpeed;
    
    }
}
