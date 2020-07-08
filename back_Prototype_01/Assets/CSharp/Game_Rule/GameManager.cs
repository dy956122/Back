using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 介面顯示用視窗
    /// </summary>
    [Header("介面顯示用視窗")]
    public GameObject SettingButton;
    private bool settingSwith;

    private void FixedUpdate()
    {
        SettingButtonControl();
    }

    /// <summary>
    /// 使用 ESC 鍵 啟動畫面左上方設定鍵
    /// </summary>
    public void SettingButtonControl()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            settingSwith = !settingSwith;
            if (settingSwith)
            {
                //Time.timeScale = 0f;
                SettingButton.SetActive(true);
            }
            else
            {
                //Time.timeScale = 1.0f;
                SettingButton.SetActive(false);
            }
        }
    }
}
