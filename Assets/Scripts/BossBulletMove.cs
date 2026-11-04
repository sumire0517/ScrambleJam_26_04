using UnityEngine;

public class BossBulletMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float bossBulletSpeed = 10f;
    [SerializeField] public float bossBulletDamage = 25f;
    public Collider2D other;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -bossBulletSpeed * Time.deltaTime, 0);
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
            PlayerControler player = other.GetComponent<PlayerControler>();
            
            if (player != null)
            {
                player.player2Health -= bossBulletDamage; 
                              
            
                player.player1Health -= bossBulletDamage;
                Destroy(gameObject); 
            
            }
            
                
                
        
            
    }
}
