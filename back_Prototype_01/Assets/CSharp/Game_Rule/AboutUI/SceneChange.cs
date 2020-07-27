using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [Header("進入指定名稱的關卡"), Tooltip("進入指定名稱的關卡")]
    /// <summary>
    /// 進入指定名稱的關卡
    /// </summary>
    public string SceneName;

    [Header("音量儲存的字串名"), Tooltip("音量儲存的字串名")]
    /// <summary>
    /// 指定音量儲存的字串名稱
    /// </summary>
    string SaveAudioSlider = "SaveAudioSlider";




    public void NextScene()
    {//選擇下一關
        PlayerPrefs.SetFloat(SaveAudioSlider, AudioListener.volume);
        Application.LoadLevel(SceneName);


    } //選擇下一關 結束

}
