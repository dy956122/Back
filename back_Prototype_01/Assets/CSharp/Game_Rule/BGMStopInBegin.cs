using UnityEngine;

public class BGMStopInBegin : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("MainBGM").GetComponent<AudioSource>().enabled = false;
    }

}
