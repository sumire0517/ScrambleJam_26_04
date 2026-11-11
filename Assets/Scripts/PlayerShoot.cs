using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBullet;  
    public GameObject shotEffect;
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
        bool isBullet1 = gameObject.CompareTag("Bullet1");
        bool isBullet2 = gameObject.CompareTag("Bullet2");
        if (!isBullet1 && !isBullet2)
        {
            return;
        }

        Keyboard keyboard = Keyboard.current;
        bool isShootingBullet1 = isBullet1 && keyboard != null && (keyboard.spaceKey.isPressed || keyboard.enterKey.isPressed || Keyboard.current.zKey.isPressed);
        bool isShootingBullet2 = isBullet2 && keyboard != null && keyboard.enterKey.isPressed;

        if (shotEffect != null)
        {
            shotEffect.SetActive(isShootingBullet1 || isShootingBullet2);
        }

        if (isShootingBullet1 && (Time.time - lastShootTime_1 > 0.1f))
        {
            Instantiate(PlayerBullet, transform.position, Quaternion.identity);
            lastShootTime_1 = Time.time;
            PlayShotSound();
        }

        if (isShootingBullet2 && (Time.time - lastShootTime_2 > 0.1f))
        {
            Instantiate(PlayerBullet, transform.position, Quaternion.identity);
            lastShootTime_2 = Time.time;
            PlayShotSound();
        }
    }

    private void PlayShotSound()
    {
        audioSource.PlayOneShot(shotSe);

    }
}
