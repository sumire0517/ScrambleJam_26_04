using UnityEngine;

public class BossControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bossHealth;
    [SerializeField] public float maxBossHealth = 1000;
    void Start()
    {
        bossHealth = maxBossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            DestroyBoss();
            Debug.Log("Boss Destroyed");
        }
    }

    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
