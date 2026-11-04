using UnityEngine;

public class BossControler : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public float bossHealth = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            DestroyBoss();
        }
    }

    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
