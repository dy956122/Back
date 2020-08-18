using UnityEngine;
using UnityEngine.SceneManagement;
// 強制開啟結局


public class MysteryButton : MonoBehaviour
{
    public string sceneName;

    // 開啟指定場景結局
    public void StoryHappen()
    {
        SceneManager.LoadScene(sceneName);
    }
}
