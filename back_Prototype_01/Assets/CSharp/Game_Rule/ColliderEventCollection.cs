using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderEventCollection : ColliderEvent
{
    public GameManager GM;

    protected override void OnTriggerEnter(Collider storyHappen)
    {
        if (true)
        {
            if (storyHappen.GetComponent<Collider>().tag == "Player")
            {
                SceneManager.LoadScene(SceneName);
            }
        }
      
    }
}
