using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBullet;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   // Enterキーを押した場合
        {
            Instantiate(PlayerBullet, this.transform.position, Quaternion.identity);  // 弾を表示させて座標を移動させる処理
        }
    }
}
