using UnityEngine;

// 讓狼爪特效消失
public class Scrach : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
