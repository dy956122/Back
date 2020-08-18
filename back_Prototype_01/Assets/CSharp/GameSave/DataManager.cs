using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static PlayerData data;  // 需要儲存的資料
    public static bool load;        // 紀錄玩家是否選擇讀取模式

    /// <summary>
    /// 讀取檔案：選單 - 讀取檔案 按鈕
    /// </summary>
    public void GameOld()
    {
        load = true;    // 是讀取檔案
        GameManager.load = true;
        SceneManager.LoadScene("Game");
    }


   /// <summary>
   /// 全新冒險：選單 - 全新冒險 按鈕
   /// </summary>
   public void GameNew()
   {
       load = false;   // 非讀取檔案
        GameManager.load = false;
        SceneManager.LoadScene("GameTitle02");
   }

    private void Start()
    {
        // 玩家選取讀取檔案 呼叫 資料讀取方法
        if (load) DataRead();
    }

    /*
 

    /// <summary>
    /// 存檔：遊戲場景 - 存檔 按鈕
    /// </summary>
    public void GameSave()
    {
        // 玩家按存檔按鈕 呼叫 資料寫入
        DataWrite();
        SceneManager.LoadScene("GameTitle");
    }

     /// <summary>
     /// 返回選單：遊戲場景 - 返回選單 按鈕
     /// </summary>
     public void BackToMenu()
     {
         load = false;       // 非讀取檔案
         SceneManager.LoadScene("選單");
     }
     */


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
         Player player = GameObject.Find("LR").GetComponent<Player>();
         //Text textCoin = GameObject.Find("SkullNum").GetComponent<Text>();

        // 4. 讀取資料
        target.position = data.playerpos;
        target.eulerAngles = data.playerrot;
         //player.Skull = data.Skull;
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
         // data.Skull = player.Skull;

         // 3. 轉為 JSON
         string json = JsonUtility.ToJson(data);

         // 4. 儲存
         PlayerPrefs.SetString("儲存資料1", json);
     }

}