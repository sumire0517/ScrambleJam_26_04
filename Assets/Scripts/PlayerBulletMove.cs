using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    private float playerBulletSpeed = 20f;
    public float playerBulletDamage = 15f;
    public Collider2D other;
    public AudioClip hitSe; 
    public Sprite[] deathSprites;
    private bool isHit = false;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) return;
        transform.Translate(0, playerBulletSpeed * Time.deltaTime, 0);
        if (transform.position.y > 5f)
        {
            DestroyBullet();
        }


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            BossControler boss = other.GetComponent<BossControler>();
            if (boss != null)
            {
                boss.bossHealth -= playerBulletDamage;
                PlayerShotSound();
                DestroyBullet();
            }
            
    }

    private void PlayerShotSound()
    {
        if (hitSe != null)
        {
            AudioSource.PlayClipAtPoint(hitSe, transform.position);
        }
    }



    public void DestroyBullet()
    {
        isHit = true;
        StartCoroutine(DeathAnimation());
    }
    private IEnumerator DeathAnimation()
    {
        // 画像を順番に切り替える
        
        for (int i = 0; i < deathSprites.Length; i++)
        {
       
            spriteRenderer.sprite = deathSprites[i];

            yield return new WaitForSeconds(0.08f);
        }

        // 最後にプレイヤーを消す
        Destroy(gameObject);
    }


}
