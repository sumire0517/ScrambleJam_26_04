using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float playerBulletSpeed = 20f;
    public float playerBulletDamage = 15f;
    public Collider2D other;
    public AudioClip hitSe; 
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, playerBulletSpeed * Time.deltaTime, 0);
        if (transform.position.y > 5f)
        {
            Destroy(gameObject);
        }


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            BossControler boss = other.GetComponent<BossControler>();
            if (boss != null)
            {
                boss.bossHealth -= playerBulletDamage;
                PlayerShotSound();
                Destroy(gameObject);
            }
            
    }

    private void PlayerShotSound()
    {
        audioSource.PlayOneShot(hitSe);
        Debug.Log("Player hit sound played");
    }


}
