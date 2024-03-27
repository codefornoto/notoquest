using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSoundScript : MonoBehaviour
{
    public bool DontDestroyEnabled = true;
    public AudioSource music; // assuming you have an AudioSource component attached to the GameObject

    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        // 現在のシーン名を取得
        string currentSceneName = SceneManager.GetActiveScene().name;

        // シーン名が "Goal" の場合、音楽を停止
        if (currentSceneName == "Goal")
        {
            Debug.Log("Stop!");
            music.Stop();
        }
    }
}
