using UnityEngine;

public class AItest : MonoBehaviour
{
    // AI角色 試寫

    public int HP = 4;

    public float Att = 2;

    public float timer = 5;

    public float speed = 2;

    [Range(10f, 100f)]
    public float trackRange;

    [Range(2f, 10f)]
    public float attackRange;

    protected Transform Target;

    protected Player LR;

    #region 掉落物產生
    /// <summary>
    /// 產生掉落物
    /// </summary>
    private GameObject dropThing;

    /// <summary>
    /// 掉落機率 (分子),開頭d為小寫
    /// </summary>
    [Header("掉落機率(分子)"), Range(0f, 10f), Tooltip("掉落機率(分子)")]
    public float dropProbability;

    /// <summary>
    /// 掉落機率 (分母),開頭D為大寫
    /// </summary>
    ///  [Header("掉落機率(分母)"),Range(0f,10f),Tooltip("掉落機率(分母)")]
    private float DropProbability = 10;

    #endregion  掉落物產生 結束


    // 使大野狼繼承追蹤腳本
    protected virtual void Track()
    {
        if (Vector3.Distance(transform.position, Target.position) <= trackRange)
        {
            transform.LookAt(Target);
            transform.position = Vector3.Lerp(gameObject.transform.position, Target.position, Time.deltaTime * speed);
        }
    }

    // 使大野狼繼承攻擊腳本
    protected virtual void Attack()
    {
        timer -= Time.deltaTime;
        if (Vector3.Distance(transform.position, Target.position) <= attackRange)
        {
            if (timer <= 0)
            {
                // 啟動攻擊動畫
                GetComponentInChildren<Animator>().SetBool("Att", true);
                // 呼叫玩家損血 功能
                Target.GetComponent<Player>().LR_Hurt(Att);

                // GetComponent<Animator>().SetBool("Att", true);
                timer = 5;

            }
            else if (timer <= 5f)
            {
                GetComponentInChildren<Animator>().SetBool("Att", false);
            }
        }


    }

    // 受傷腳本
    public void Hurt(int damage)
    {
        HP -= damage;
        if (HP <= 0f)
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Die");
            speed = 0;
            Destroy(gameObject, 2);
            PropDrop();
        }
    }

    // 呼叫玩家身上的結束遊戲腳本
    protected virtual void GameOver()
    {
        if (LR._scriptHp <= 0)
        {
            LR.GameOver2();
        }
    }

    /// <summary>
    /// 掉落道具,僅限於小怪使用(大野狼無法繼承此段程式碼)
    /// </summary>
    private void PropDrop()
    {
        // 如果掉落機率 大於 0.3
        if ((Random.Range(0, dropProbability) / DropProbability) > 0.3f)
        {
            // 產生掉落物(掉落物由自己指定,在此遊戲為聖骸)
            Instantiate(dropThing, transform.position, Quaternion.identity);
        }
    }





    // Start is called before the first frame update
    void Awake()
    {
        Target = GameObject.Find("LR").transform;
        dropThing = GameObject.Find("skull");
        LR = GameObject.Find("LR").GetComponent<Player>() ;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Track();
        GameOver();
    }

    /*
    private void OnTriggerEnter(Collider other)
    {

    }*/
}
