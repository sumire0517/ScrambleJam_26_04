using UnityEngine;
using UnityEngine.SceneManagement;
public class Relode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentScene();
        }
        
    }
        public void ReloadCurrentScene()
    {
        // 現在アクティブなシーンの名前を取得して再読み込みする
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        
        // または1行で書く場合
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
