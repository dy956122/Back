using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderEvent : MonoBehaviour
{
    public string SceneName;

    protected virtual void OnTriggerEnter(Collider storyHappen)
    {
        if (storyHappen.GetComponent<Collider>().tag == "Player" )
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
