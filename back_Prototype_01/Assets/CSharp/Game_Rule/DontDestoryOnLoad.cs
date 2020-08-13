using UnityEngine;

public class DontDestoryOnLoad : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

 
}
