using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBegin : MonoBehaviour
{
    public string sceneName;
    public int animationTime;

    void Start()
    {
        Invoke("LoadScene", 6.0f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
