using UnityEngine.AI;                   // 使用Navigation

using UnityEngine;
    // 還有東西要修正,像是追蹤功能要處理

public class VoodooDollSetting : MonoBehaviour
{

    #region 設定基礎欄位

    #region 設定基礎數值
    /// <summary>
    /// 怪物的生命值
    /// </summary>
    [Header("怪物的生命值"), Tooltip("生命值")]
    [Range(1, 12)]
    public float HP = 6;

    /// <summary>
    /// 怪物的攻擊力
    /// </summary>
    [Header("怪物的攻擊力"), Tooltip("攻擊力")]
    [Range(1, 5)]
    public float force = 1;

    /// <summary>
    /// 怪物的攻擊速度
    /// </summary>
    [Header("怪物的攻擊速度"), Tooltip("攻擊速度")]
    [Range(1.0f, 5.0f)]
    public float attackSpeed = 1f;

    /// <summary>
    /// 小怪的攻擊時間間隔
    /// </summary>
    [Header("小怪的攻擊時間間隔"),Tooltip("小怪的攻擊時間間隔")]
    [Range(1f,5f)]
    public float attackTime = 5f;

    /// <summary>
    /// 怪物的走路速度
    /// </summary>
    [Header("怪物的走路速度"), Tooltip("走路速度")]
    [Range(1.0f, 3.0f)]
    public float walkSpeed = 1.0f;

    #region 掉落物產生
    /// <summary>
    /// 產生掉落物
    /// </summary>
    public GameObject dropThing;

    /// <summary>
    /// 掉落機率 (分子),開頭d為小寫
    /// </summary>
    [Header("掉落機率(分子)"),Range(0f,10f),Tooltip("掉落機率(分子)")]
    public float dropProbability;

    /// <summary>
    /// 掉落機率 (分母),開頭D為大寫
    /// </summary>
    ///  [Header("掉落機率(分母)"),Range(0f,10f),Tooltip("掉落機率(分母)")]
    private float DropProbability = 10;

    #endregion  掉落物產生 結束

    #endregion 設定數值 結束

    #region 設定動畫腳本相關欄位

    // public Animator MonsterAni;

    private Transform redPos;

    #endregion  設定動畫腳本相關欄位 結束

    #endregion 設定基礎欄位 結束


    #region 設定方法

    /// <summary>
    /// 怪物攻擊
    /// </summary>
    public virtual void Att()
    {
        attackTime -= Time.deltaTime;

        if (Vector3.Distance(transform.position, redPos.position) <= 2f)
        {
            if (attackTime <= 0)
            {
                GameObject.Find("LR").GetComponent<Player>().LR_Hurt(force);
                // GetComponent<Animator>().SetBool("Att", true);// 啟動攻擊動畫
                attackTime = 5;
            }
        }
    }

    /// <summary>
    /// 怪物追蹤
    /// </summary>
    protected virtual void Track()
    {
        // MonsterAni.SetFloat("Walk", 0.6f);                                          // 啟動怪物動畫(移動)
        base.gameObject.GetComponent<Animator>().SetFloat("Walk", 0.6f);

        // 怪物緩慢移動至玩家附近
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, redPos.position, Time.deltaTime * walkSpeed);                            

        gameObject.transform.LookAt(redPos);                                           // 怪物面向玩家
    }

    /// <summary>
    /// 怪物受傷的指令,需要被玩家腳本呼叫
    /// </summary>
    /// <param name="Damage"></param>
    public void Hurt(byte Damage)
    {
        HP -= Damage;                              // HP 受損

        base.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
    }


    /// <summary>
    /// 怪物死亡的指令
    /// </summary>
    protected virtual void Dead()
    {
        // 如果 Hp 小於等於 0
        if (HP <= 0)
        {
            // MonsterAni.SetTrigger("Dead");              // 觸發怪物動畫(死亡)
            base.gameObject.GetComponent<Animator>().SetTrigger("Dead");

            GetComponent<Collider>().enabled = false;   // 怪物碰撞器關閉
            Destroy(base.gameObject, 2);                     // 兩秒後刪除怪物

            // GameObject.Find("MonsterCreaterGroup").GetComponent<MonsterCreater>().MonsterNum--; // 因為是預製物,所以只能使用這方法來讓小怪找到MonsterCreaterGroup

            //PropDrop();                                 // 呼叫產生道具的方法(在下方)
        }
    }


    /// <summary>
    /// 掉落道具
    /// </summary>
    protected virtual void PropDrop()
    {
        // 如果掉落機率 大於 0.3
        if ((Random.Range(0, dropProbability) / DropProbability) > 0.3f)
        {
            // 產生掉落物(掉落物由自己指定,在此遊戲為聖骸)
            Instantiate(dropThing, transform.position, Quaternion.identity);
        }
    }


    /// <summary>
    /// 觸發事件,之後要給大野狼繼承腳本,因此使用protected
    /// </summary>
    /// <param name="inAttackArea"></param>
    protected virtual void OnTriggerEnter(Collider inAttackArea)
    {
        // 當玩家進入怪物的collider內部後
        if (inAttackArea.GetComponent<Collider>().tag == "Player")
        {
            // 怪物開始跟蹤玩家
            Track();

            // 如果距離小於 0.5f
            if (Vector3.Distance(gameObject.transform.position, redPos.position) < 0.5f)
            {
                // 開始攻擊
                Att();
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        // 如果玩家離開怪物的Collider範圍,關閉攻擊模式,進入待機狀態
        //  MonsterAni.SetBool("Att", false);
        base.gameObject.GetComponent<Animator>().SetBool("Att", false); ; 

    }


    void Awake()
    {

    }

    void Update()
    {
        Dead();
    }


    #endregion 設定方法 結束
}
