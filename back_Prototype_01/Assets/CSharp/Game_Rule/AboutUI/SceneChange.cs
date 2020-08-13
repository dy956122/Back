using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void NextSceneDelay()
    {
        Invoke("NextScene", 2);
    }

   public void NextScene()
    {//選擇下一關
        PlayerPrefs.SetFloat(SaveAudioSlider, AudioListener.volume);
        SceneManager.LoadScene(SceneName);
    } //選擇下一關 結束

}
