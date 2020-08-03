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
    [SerializeField]
    private GameObject[] skull;

    /// <summary>
    /// 聖骸數量累計
    /// </summary>
    [Header("聖骸數量累計"), Tooltip("聖骸數量累計")]
    private int skullNum = 0;

    /// <summary>
    /// 會被聖骸腳本呼叫的參數,因此聖骸的腳本裡面也需要一個 GM
    /// 如果玩家撿到聖骸,聖骸的腳本會呼叫此指令
    /// </summary>
    public void CollectSkullNum()
    {
        skull[skullNum].SetActive(true);
        skullNum++;
        print(skullNum);
    }

    [Header("啟動 小紅帽變回人形的劇情畫面")]
    [SerializeField]
    private GameObject story_ReturnHuman;

    /// <summary>
    /// 想要藉由達到一定數量之後,呼叫破關之類的場景
    /// 其中要追加 分別事件, 此段寫在update會一直呼叫,所以圖會變成永遠開啟
    /// </summary>
    private void FinalStory()
    {
        if (skullNum == 7)
        {
            story_ReturnHuman.SetActive(true);
            skullNum++; // 讓數量變為8,那麼在Update裡面會因為數量不為7,而中斷此段程式碼
            print(skullNum);
            /* if (true)
             {

             }*/
        }
    }

    /// <summary>
    /// 關閉劇情圖片
    /// </summary>
    public void CloseStoryImage(GameObject CloseThing)
    {
        CloseThing.SetActive(false);
    }

    #endregion  聖骸圖像顯示專用 結束


    private void Update()
    {
        SettingButtonControl();
        FinalStory();
    }
}
