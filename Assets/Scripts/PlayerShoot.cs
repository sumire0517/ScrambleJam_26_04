using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBullet;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))  
        {
            if (gameObject.CompareTag("Player")){
                Instantiate(PlayerBullet, this.transform.position, Quaternion.identity); 
            }                        
        }

        if (Input.GetKeyDown(KeyCode.Return))   
        {
            if (gameObject.CompareTag("Player2")){
                Instantiate(PlayerBullet, this.transform.position, Quaternion.identity); 
            }                        
        }


    }
}
