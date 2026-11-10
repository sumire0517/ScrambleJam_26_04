using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float playerBulletSpeed = 20f;
    public float playerBulletDamage = 15f;
    public Collider2D other;
    public AudioClip hitSe; 

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
        if (hitSe != null)
        {
            AudioSource.PlayClipAtPoint(hitSe, transform.position);
        }
    }


}
