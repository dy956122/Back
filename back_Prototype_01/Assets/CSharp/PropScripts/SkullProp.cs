using UnityEngine;

public class SkullProp : MonoBehaviour
{
    // 使用GameManager管理數值及劇情
    // 主要用來呼叫 GM 紀錄取得 聖骸的數量
    // 然後取得 一定數量後, 讓小紅帽碰到中央場景,觸發變人事件
    // 控制 小紅帽未收集 全部道具, 但是在路途中被小怪殺死的結局
    // 或是 小紅帽收集全部聖骸, 但是被大野狼打到,觸發第二結局
    // 最後是, 如果滿血打倒大野狼了, 觸發 完美結局專用
    private GameManager GM;

    // 讓聖骸剛出現時,有個可以追蹤的目標座標
    private Transform Target;

    /// <summary>
    /// 讓 玩家靠近道具後,道具自動被吸附的指令
    /// </summary>
    public void TrackPlayer()
    {
        if (Vector3.Distance(transform.position, Target.position) < 10f)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, Target.position, Time.deltaTime * 3f);
        }
    }

    /// <summary>
    /// 初始化,讓目標在最初被定義
    /// </summary>
    private void Awake()
    {
        // 定義最初目標的座標: 場地(Hierachy)上標記為 player 物件 的座標
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        TrackPlayer();
    }

    private void OnTriggerEnter(Collider collect)
    {
        // 如果 接觸到玩家
        if (collect.GetComponent<Rigidbody>().tag == "Player")
        {
            // 呼叫
            GM.CollectSkullNum();
            Destroy(gameObject);
        }
    }



}
