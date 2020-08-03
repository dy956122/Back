using UnityEngine;

public class MonsterCreater : MonoBehaviour
{
    /// <summary>
    /// 創建小怪
    /// </summary>
    [Header("創建小怪"), Tooltip("創建小怪"), SerializeField]
    private GameObject Voodoo;

    /// <summary>
    /// 生怪點
    /// </summary>
    [Header("生怪點"), Tooltip("生怪點"), SerializeField]
    private GameObject[] CreaterPonit;

    #region 小怪的數量管理
    /// <summary>
    /// 死掉的小怪數量,要從怪物那邊的腳本呼叫,死掉後會--
    /// </summary>
    [Header("小怪的數量"), Tooltip("小怪的數量")]
    public int MonsterNum;

    #endregion 小怪的數量管理 結束

    /// <summary>
    /// 創建 小怪
    /// </summary>
    private void CreateMonster()
    {
        Instantiate(Voodoo, CreaterPonit[Random.Range(0, CreaterPonit.Length)].transform.position, Quaternion.identity);
    }

    /// <summary>
    /// 經過一段時間產生小怪
    /// </summary>
    private void timeforCreate()
    {
        InvokeRepeating("CreateMonster", 5, 10);
        MonsterNum++;
    }


    void Update()
    {
        if (MonsterNum <= 6)
        {
            timeforCreate();
        }
    }

}
