using UnityEngine;

public class BossShoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BossBullet; 
    private double lastShootTime = 0.0f;
    private float angle = 0f; // Variable to keep track of the current angle
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 3.0f)
        {
            if (Time.time - lastShootTime > 0.02f)  
            {
                angle += 10f; // Increment the angle for the next bullet
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
                Instantiate(BossBullet, this.transform.position, rotation);                         
                lastShootTime = Time.time;
            }
        }
        
    }
}
