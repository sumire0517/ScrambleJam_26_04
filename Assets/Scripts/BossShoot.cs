using UnityEngine;
using Random = UnityEngine.Random;
public class BossShoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BossBullet; 
    public GameObject BossBulletPlus; 
    public GameObject BossBulletMinus; 
    private double lastShootTime = 0.0f;
    private float angle = 0f; 
    BossControler bossControler;
    private int bulletCount = -6;
    public AudioClip shotSe; 
    private AudioSource audioSource;
    bool flag = true;
    void Start()
    {
        bossControler = GetComponentInParent<BossControler>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossControler == null || BossBullet == null)
        {
            return;
        }

        if (Time.time > 5.0f)
        {
            if (bossControler.bossHealth > 4000)
            {
                if (Time.time - lastShootTime > 0.6f)
                {
                    
                    for (int i = 0; i < 36; i++)
                    {
                        Quaternion rotation = Quaternion.Euler(0f, 0f, angle + 10 * i);
                        Instantiate(nextBullet(), this.transform.position, rotation); 
                    }
                    lastShootTime = Time.time;
                    PlayShotSound();
                }
            }
            else if  (bossControler.bossHealth > 3000)
            {
                
                if (Time.time - lastShootTime > 0.08f)
                {
                    
                    Quaternion rotation = Quaternion.Euler(0f, 0f, 10 * bulletCount);
                    Instantiate(nextBullet(), this.transform.position, rotation); 
                    PlayShotSound();
                
                    lastShootTime = Time.time;
                    if (flag)
                    {
                        bulletCount += 1;
                        //Debug.Log("TrueBullet Count: " + bulletCount);
                        if (bulletCount >= 6)
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        bulletCount -= 1;
                        //Debug.Log("FalseBullet Count: " + bulletCount);
                        if (bulletCount <= -6)
                        {
                            flag = true;
                        }
                    }
                }


            }
            else if  (bossControler.bossHealth > 2000)
            {
                if (Time.time - lastShootTime > 0.01f)
                {
                    lastShootTime = Time.time;
                    float add = Random.Range(-3f, 3f);
                    Quaternion rotation = Quaternion.Euler(0f, 0f, 10 * bulletCount + add);
                    Instantiate(nextBullet(), this.transform.position, rotation); 
                    PlayShotSound();
                }
                bulletCount += 1;


            }
            else if  (bossControler.bossHealth > 1000)
            {
                if (Time.time - lastShootTime > 0.4f)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            float add = Random.Range(0f, 40f);
                            Quaternion rotation = Quaternion.Euler(0f, 0f, angle + 2 * i + j * 60 + add);
                            Instantiate(nextBullet(), this.transform.position, rotation); 
                        }
                    }
                    PlayShotSound();
                    lastShootTime = Time.time;
                }

            }
            else
            {

                if (Time.time - lastShootTime > 0.03f)  
                {
                    angle += 10f; 
                    Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
                    Instantiate(nextBullet(), this.transform.position, rotation); 
                    Quaternion rotation2 = Quaternion.Euler(0f, 0f, -angle + 2f);
                    Instantiate(nextBullet(), this.transform.position, rotation2);
                    PlayShotSound();
                    lastShootTime = Time.time;
                }
            }
        }
        

        
    }

    private void PlayShotSound()
    {
        audioSource.PlayOneShot(shotSe);
    }

    private GameObject nextBullet()
    {
        int n = Random.Range(0, 100);
        if (n < 5)
        {
            return BossBulletPlus; 
        }
        else if (n < 10)
        {
            return BossBulletMinus; 
        }
        else
        {
            return BossBullet; 
        }
    }
}
