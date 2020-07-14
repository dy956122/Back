using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBegin : MonoBehaviour
{
    /// <summary>
    /// 配合轉場動畫用的接關
    /// </summary>
    public string sceneName;
    public float animationTime;

    void Start()
    {
        Invoke("LoadScene", animationTime);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
