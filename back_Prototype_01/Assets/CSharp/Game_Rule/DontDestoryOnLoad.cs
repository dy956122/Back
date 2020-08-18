using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoryOnLoad : MonoBehaviour
{
    public AudioSource BGM;
    // public string gameTitle,strory;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
