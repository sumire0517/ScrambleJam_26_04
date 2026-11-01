using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBullet;  
    private double lastShootTime_1 = 0.0f;
    private double lastShootTime_2 = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && gameObject.CompareTag("Player") && (Time.time - lastShootTime_1 > 0.1f))  
        {
            Instantiate(PlayerBullet, this.transform.position, Quaternion.identity);                         
            lastShootTime_1 = Time.time;
        }

        if (Input.GetKey(KeyCode.Return) && gameObject.CompareTag("Player2") && (Time.time - lastShootTime_2 > 0.1f))   
        {
            Instantiate(PlayerBullet, this.transform.position, Quaternion.identity); 
            lastShootTime_2 = Time.time;               
        }
    }
}
