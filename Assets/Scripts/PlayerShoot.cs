using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBullet;  
    private double lastShootTime_1 = 0.0f;
    private double lastShootTime_2 = 0.0f;
    public AudioClip shotSe; 
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && gameObject.CompareTag("Bullet1") && (Time.time - lastShootTime_1 > 0.1f))  
        {
            Instantiate(PlayerBullet, this.transform.position, Quaternion.identity);                         
            lastShootTime_1 = Time.time;
            PlayShotSound();
        }

        if (Input.GetKey(KeyCode.Return) && gameObject.CompareTag("Bullet2") && (Time.time - lastShootTime_2 > 0.1f))   
        {
            Instantiate(PlayerBullet, this.transform.position, Quaternion.identity); 
            lastShootTime_2 = Time.time;    
            PlayShotSound();
        }
    }

        private void PlayShotSound()
    {
        audioSource.PlayOneShot(shotSe);
        Debug.Log("Shot sound played");
    }
}
