using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region 屬性與欄位設定

    [Header("遊戲開頭音樂"), Tooltip("遊戲開頭音樂")]
    /// <summary>
    /// 遊戲開頭音樂
    /// </summary>
    public Slider GameThemeMusic;

    [Header("音樂開關"), Tooltip("音樂開關")]
    /// <summary>
    /// 音樂開關按鈕
    /// </summary>
    bool MusicSwith = false;

    [Header("音樂開關按鈕"), Tooltip("音樂開關按鈕")]
    /// <summary>
    /// 音樂開關按鈕
    /// </summary>
    public Image MusicControlButton;


    [Header("聲音開啟圖"), Tooltip("聲音開啟圖")]
    /// <summary>
    /// 聲音開啟圖
    /// </summary>
    public Sprite MusicOpenButton;

    [Header("聲音關閉圖"), Tooltip("聲音關閉圖")]
    /// <summary>
    /// 聲音關閉圖
    /// </summary>
    public Sprite MusicCloseButton;

    #endregion 屬性與欄位設定 結束


    void Start()
    {
        ControlThemeMusic();
    }


    void Update()
    {
        AudioListener.volume = GameThemeMusic.value;
    }


    #region 方法創建
   
    public void ChangeThemeMusic() // 調整音量功能
    {
        if (GameThemeMusic.value == 0)
        {
            MusicSwith = true;
            ControlThemeMusic();
        }
        else
        {
            MusicSwith = false;
            ControlThemeMusic();
        }
    }  // 調整音量功能 結束

    public void ControlThemeMusic() // 音量開關
    {
        MusicSwith = !MusicSwith;
        if (MusicSwith == true)
        {
            AudioListener.pause = false;

            MusicControlButton.sprite = MusicOpenButton;
        }
        else
        {
            AudioListener.pause = true;

            MusicControlButton.sprite = MusicCloseButton;
        }
    } // 音量開關 結束

    public void Exit() // 離開
    {
        Application.Quit();
    } // 離開 結束

    #endregion 方法創建 結束

}
