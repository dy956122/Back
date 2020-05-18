using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextScene() {//選擇下一關
        Application.LoadLevel(SceneName);
    } //選擇下一關 結束

    public void Exit()
    {
        Application.Quit();
    }

}
