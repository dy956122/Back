using UnityEngine;
using System.Linq; // 引用 系統.查詢語言 Lin Query
using System.Threading;
using UnityEngine.AI;

public class AiTrack : MonoBehaviour
{
    // 使用navigation來寫的,但這是copy老師之前寫的殭屍
    [Header("移送速度"), Range(0, 10)]
    public float speed = 1.5f;


    /// <summary>
    /// 導覽代理器
    /// </summary>
    protected NavMeshAgent agent;

    /// <summary>
    /// 動畫控制器
    /// </summary>
    protected Animator ani;


    /// <summary>
    ///  目標
    /// </summary>
    protected Transform target;

    /// <summary>
    /// 人類陣列
    /// </summary>
    public Player[] player;

    /// <summary>
    /// 距離
    /// </summary>
    public float[] distance;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // 取的元件 <代理器>
        ani = GetComponent<Animator>();       // 取得元件 <動畫控制器>

        agent.speed = speed;                  // 代理器.速度 = 速度
    }


    protected virtual void Start()
    {
        // 人類陣列 = 透過類型尋找物件<泛型>()
        // FindObjectsOfType 中間有個s, 要注意不一樣
        player = FindObjectsOfType<Player>();
        // 距離陣列的數量 = 人列陣列的數量
        distance = new float[player.Length];
        // 設定目的地(原點) - 避免一開始導覽錯誤
        agent.SetDestination(Vector3.zero);
    }

    private void Update()
    {
        Track();
    }


    protected virtual void Track()
    {
        // 儲存所有人跟此物件的距離
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i] == null || player[i].transform.name == "Enemy")
            {
                if (player[i] == null) distance[i] = 1000;              // 如果人類死亡 距離 改為 1000
                else distance[i] = 999;                                 // 與怪物物件的距離改為 999
                continue;                                               // 繼續 - 跳過並執行下一次迴圈
            }
            distance[i] = Vector3.Distance(transform.position, player[i].transform.position);
        }

        // 判斷最近
        float min = distance.Min();                   // 最小值 = 距離.最小值

        // 清單是更靈活的陣列
        int index = distance.ToList().IndexOf(min);     // 索引值 = 距離.轉清單.取得索引值(最小值)
        target = player[index].transform;               // 目標 = 人類[索引值].變形

        // 追蹤最近目標
        agent.SetDestination(target.position);

        // if (agent.remainingDistance <= 1f && min != 999) HitPeople(); // 判斷  距離 < 1  傷害人類
    }

}
