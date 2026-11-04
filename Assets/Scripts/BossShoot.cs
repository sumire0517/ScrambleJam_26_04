using UnityEngine;

public class BossShoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BossBullet; 
    private double lastShootTime = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastShootTime > 0.5f)  
        {
            Instantiate(BossBullet, this.transform.position, Quaternion.identity);                         
            lastShootTime = Time.time;
        }
    }
}
