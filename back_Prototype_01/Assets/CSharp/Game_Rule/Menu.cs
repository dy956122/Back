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
    bool MusicSwith;

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
    /// 聲音開啟圖
    /// </summary>
    public Sprite MusicCloseButton;

    [Header("螢幕大小調整"), Tooltip("螢幕大小調整")]
    /// <summary>
    /// 螢幕大小調整
    /// </summary>
    public Dropdown ScreenSize;

    #endregion 屬性與欄位設定 結束


    // Start is called before the first frame update
    void Start()
    {
        ControlThemeMusic();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = GameThemeMusic.value;
        ScreenSizeAction();
    }


    #region 方法創建
    public void ScreenSizeAction() // 螢幕調整
    {
        switch (ScreenSize.value) // 設定螢幕大小
        {
            case 0:
                Screen.SetResolution(1024, 768, false);
                break;

            case 1:
                Screen.SetResolution(1280, 720, false);
                break;

            case 2:
                Screen.SetResolution(1920, 720, false);
                break;
        } // 設定螢幕大小 結束
    } // 螢幕調整 結束

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
