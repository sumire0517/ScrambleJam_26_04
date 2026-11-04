using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] public float bulletDamage = 10;
    public Collider2D other;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
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
                boss.bossHealth -= bulletDamage;
            }
            Destroy(gameObject);
    }


}
