using UnityEngine;
using System.Collections;

public class BossBulletMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float bossBulletSpeed = 3f;
    [SerializeField] public float bossBulletDamage = 20f;
    public Collider2D other;
    public AudioClip hitSe; 
    private AudioSource audioSource;
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
        transform.Translate(0, -bossBulletSpeed * Time.deltaTime, 0);
        if ((transform.position.y < -5f) || (transform.position.y > 5f) ||(transform.position.x < -9f) || (transform.position.x > 9f))
        {
            Destroy(gameObject);
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
            PlayerControler player = other.GetComponent<PlayerControler>();
            string objName = gameObject.name;
            
            if (player != null)
            {
                if (player.CompareTag("Player"))
                {
                    if (objName == "BulletBossMinus(Clone)")
                    {
                        player.player1Health -= 1.5f * bossBulletDamage; 
                        bossShotSound();
                        
                    }
                    else if (objName == "BulletBossPlus(Clone)")
                    {
                        player.player1Health += 0.5f * bossBulletDamage; 
                        if (player.player1Health > player.maxPlayer1Health)
                        {
                            player.player1Health = player.maxPlayer1Health;
                        }
                        
                    }
                    else
                    {
                        player.player1Health -= bossBulletDamage; 
                        bossShotSound();
                        
                    }
                   
                    

                }
                else if (player.CompareTag("Player2"))
                {
                    if (objName == "BulletBossMinus(Clone)")
                    {
                        player.player2Health += 0.5f * bossBulletDamage; 
                        if (player.player2Health > player.maxPlayer2Health)
                        {
                            player.player2Health = player.maxPlayer2Health;
                        }
                    }
                    else if (objName == "BulletBossPlus(Clone)")
                    {
                        player.player2Health -= 1.5f * bossBulletDamage; 
                        bossShotSound();
                    }
                    else
                    {
                        player.player2Health -= bossBulletDamage; 
                        bossShotSound();
                    }
                    
                }

                DestroyBullet();
            
            }
                   
    }

    private void bossShotSound()
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

            yield return new WaitForSeconds(0.05f);
        }

        // 最後にプレイヤーを消す
        Destroy(gameObject);
    }
}
