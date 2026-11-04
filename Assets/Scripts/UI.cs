using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image bossHealth;
    [SerializeField] private Image player1Health;
    [SerializeField] private Image player2Health;
    private BossControler bossControler;
    private PlayerControler[] playerControler;
    void Start()
    {
    bossControler = FindFirstObjectByType<BossControler>();
    playerControler = FindObjectsByType<PlayerControler>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossControler != null)
        {
            bossHealth.fillAmount =
                bossControler.bossHealth / bossControler.maxBossHealth;
        }

        foreach (PlayerControler player in playerControler)
    {
        if (player == null) continue;

        if (player.CompareTag("Player"))
        {
            player1Health.fillAmount =
                player.player1Health / player.maxPlayer1Health;
        }
        else if (player.CompareTag("Player2"))
        {
            player2Health.fillAmount =
                player.player2Health / player.maxPlayer2Health;
        }
    }
    }


}
