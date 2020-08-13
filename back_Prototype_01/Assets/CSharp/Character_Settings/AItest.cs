using UnityEngine;

public class AItest : MonoBehaviour
{
    // AI角色 試寫

    private int HP = 4;

    private float Att = 2;

    private float timer = 5;

    private float speed = 2;

    private Transform Target;

    #region 掉落物產生
    /// <summary>
    /// 產生掉落物
    /// </summary>
    public GameObject dropThing;

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



    private void Track()
    {
        if (Vector3.Distance(transform.position, Target.position) <= 50f)
        {
            transform.LookAt(Target);
            transform.position = Vector3.Lerp(gameObject.transform.position, Target.position, Time.deltaTime * speed);
        }
    }


    private void Attack()
    {
        timer -= Time.deltaTime;

        if (Vector3.Distance(transform.position, Target.position) <= 5f)
        {
            if (timer <= 0)
            {
                Target.GetComponent<Player>().LR_Hurt(Att);
                // 啟動攻擊動畫
                GetComponentInChildren<Animator>().SetBool("Att", true);
                // GetComponent<Animator>().SetBool("Att", true);
                timer = 5;
                if (timer <= 4f)
                {
                    GetComponentInChildren<Animator>().SetBool("Att", false);
                }
            }
        }
    }

    public void Hurt(int damage)
    {
        HP -= damage;
        if (HP <= 0f)
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Die");
            speed = 0;
            Destroy(gameObject,2);
            PropDrop();
        }
    }

    /// <summary>
    /// 掉落道具
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
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Track();
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
