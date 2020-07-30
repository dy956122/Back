using UnityEngine;

public class SkullProp : MonoBehaviour
{
    // 使用GameManager管理數值及劇情
    // 主要用來呼叫 GM 紀錄取得 聖骸的數量
    // 然後取得 一定數量後, 讓小紅帽碰到中央場景,觸發變人事件
    // 控制 小紅帽未收集 全部道具, 但是在路途中被小怪殺死的結局
    // 或是 小紅帽收集全部聖骸, 但是被大野狼打到,觸發第二結局
    // 最後是, 如果滿血打倒大野狼了, 觸發 完美結局專用
    public GameManager GM;

    // public Transform Target;

    /// <summary>
    /// 讓 玩家靠近道具後,道具自動被吸附的指令
    /// </summary>
   /* public void TrackPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position,Target.position) < 25f)
        {
            gameObject.transform.position =  Vector3.Lerp(gameObject.transform.position, Target.position, 5f);
        }
    }*/

   /* private void Update()
    {
        TrackPlayer();
    }*/

    private void OnTriggerEnter(Collider collet)
    {
        GM.CollectSkullNum();
        Destroy(gameObject);
    }

}
