using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 使用GameManager管理數值及劇情
    // 主要用來呼叫 GM 紀錄取得 聖骸的數量
    // 然後取得 一定數量後, 讓小紅帽碰到中央場景,觸發變人事件
    // 控制 小紅帽未收集 全部道具, 但是在路途中被小怪殺死的結局
    // 或是 小紅帽收集全部聖骸, 但是被大野狼打到,觸發第二結局
    // 最後是, 如果滿血打倒大野狼了, 觸發 完美結局專用

    #region 介面視窗顯示專用
    /// <summary>
    /// 介面顯示用視窗
    /// </summary>
    [Header("介面顯示用視窗")]
    public GameObject SettingButton;
    private bool settingSwith;

    /// <summary>
    /// 使用 ESC 鍵 啟動畫面左上方設定鍵
    /// </summary>
    public void SettingButtonControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    #endregion 介面視窗顯示專用

    #region 聖骸圖像顯示專用
    /// <summary>
    /// 聖骸圖像顯示
    /// </summary>
    [Header("聖骸圖像顯示"), Tooltip("聖骸圖像顯示")]
    public GameObject[] skull;

    /// <summary>
    /// 聖骸數量累計
    /// </summary>
    [Header("聖骸數量累計"), Tooltip("聖骸數量累計")]
    public int skullNum = 0;

    /// <summary>
    /// 會被聖骸腳本呼叫的參數,因此聖骸的腳本裡面也需要一個 GM
    /// 如果玩家撿到聖骸,聖骸的腳本會呼叫此指令
    /// </summary>
    public /* 先用按鈕測試會不會有效果 */ /* private */ void CollectSkullNum()
    {
        skullNum++;
        skull[skullNum -1 ].SetActive(true);

        print(skullNum);

        /*for (int i = skullNum; i < skull.Length; i++)
        {
            skull[i].SetActive(true);
        }*/
    }

    [Header("啟動 劇情畫面")]
    public GameObject Story_TurnHuman;


    private void FinalStory()
    {
        if (skullNum == 7)
        {
            if (true)
            {

            }
        }
    }

    #endregion  聖骸圖像顯示專用 結束




    private void Update()
    {
        SettingButtonControl();
        
    }



}
