using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // 使用GameManager管理數值及劇情
    // 主要用來呼叫 GM 紀錄取得 聖骸的數量
    // 然後取得一定數量的聖骸後, 讓小紅帽碰到中央場景,觸發變人事件
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
                Time.timeScale = 0f;
                SettingButton.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                SettingButton.SetActive(false);
            }
        }
    }


    /*IEnumerator timestop()
    {
        yield return new WaitForSeconds();

    }*/


    #endregion 介面視窗顯示專用

    #region 聖骸相關數值與方法
    /// <summary>
    /// 聖骸圖像顯示
    /// </summary>
    [Header("聖骸圖像顯示"), Tooltip("聖骸圖像顯示"), SerializeField]
    private GameObject[] skull;

    /// <summary>
    /// 聖骸數量累計
    /// </summary>
    [Header("聖骸數量累計"), Tooltip("聖骸數量累計")]
    public int skullNum = 0;

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
    public void ReturnHumanEvent()
    {
        if (skullNum == 7)
        {
            story_ReturnHuman.SetActive(true);      // 開啟 相關UI
            skullNum++;                             // 讓數量變為8,那麼在Update裡面會因為數量不為7,而中斷此段程式碼
            print(skullNum);
        }
    }

    /// <summary>
    /// 關閉劇情圖片
    /// </summary>
    public void CloseStoryImage(GameObject CloseThing)
    {
        CloseThing.SetActive(false);
    }

    #endregion  聖骸相關數值與方法 結束

    #region 存檔相關方法

    public static PlayerData data;  // 需要儲存的資料
    public static bool load;        // 紀錄玩家是否選擇讀取模式

    /// <summary>
    /// 全新冒險：選單 - 全新冒險 按鈕
    /// </summary>
    public void GameNew()
    {
        load = false;   // 非讀取檔案
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// 讀取檔案：選單 - 讀取檔案 按鈕
    /// </summary>
    public void GameOld()
    {
        load = true;    // 是讀取檔案
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// 存檔：遊戲場景 - 存檔 按鈕
    /// </summary>
    public void GameSave()
    {
        // 玩家按存檔按鈕 呼叫 資料寫入
        DataWrite();
        SceneManager.LoadScene("GameTitle");
    }

    /*
    /// <summary>
    /// 返回選單：遊戲場景 - 返回選單 按鈕
    /// </summary>
    public void BackToMenu()
    {
        load = false;       // 非讀取檔案
        SceneManager.LoadScene("選單");
    }*/

    /// <summary>
    /// 資料讀取
    /// </summary>
    private void DataRead()
    {
        // 1. 取得
        string json = PlayerPrefs.GetString("儲存資料1");

        // 2. JSON 轉為資料類型
        data = JsonUtility.FromJson<PlayerData>(json);

        // 3. 取得要寫入資料的物件
        Transform target = GameObject.Find("LR").transform;
        // Player player = GameObject.Find("Unity 醬").GetComponent<Player>();
        // Text textCoin = GameObject.Find("SkullNum").GetComponent<Text>();

        // 4. 讀取資料
        target.position = data.playerpos;
        target.eulerAngles = data.playerrot;
        data.Skull = skullNum;
        // textCoin.text = "聖骸數量：" + data.Skull;
    }

    /// <summary>
    /// 資料寫入
    /// </summary>
    private void DataWrite()
    {
        // 1. 取得要寫入資料的物件
        Transform target = GameObject.Find("LR").transform;
        Player player = GameObject.Find("LR").GetComponent<Player>();

        // 2. 寫入資料
        data.playerpos = target.position;
        data.playerrot = target.eulerAngles;
        data.Skull = skullNum;

        // 3. 轉為 JSON
        string json = JsonUtility.ToJson(data);

        // 4. 儲存
        PlayerPrefs.SetString("儲存資料1", json);
    }
    #endregion  存檔相關方法 結束

    private void Start()
    {
        // 玩家選取讀取檔案 呼叫 資料讀取方法
        if (load) DataRead();
    }

    private void Update()
    {
        SettingButtonControl();
    }
}
