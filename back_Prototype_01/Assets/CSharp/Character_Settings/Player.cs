using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using UnityEditor.ShaderGraph.Internal;

// 小紅帽的滑鼠右鍵攻擊還要寫入bool 函數,來控制關閉


public class Player : MonoBehaviour
{
    #region 基礎欄位與屬性

    #region 小紅帽的基礎能力值
    /// <summary>
    /// 小紅帽的生命值
    /// </summary>
    [Header("小紅帽的生命值"), Tooltip("生命值")]
    [Range(1, 12)]
    public float LR_HP = 5;

    /// <summary>
    /// 小紅帽的魔力值
    /// </summary>
    [Header("小紅帽的體力值"), Tooltip("體力值")]
    [Range(1, 10)]
    public float LR_MP = 4;

    /// <summary>
    /// 小紅帽的攻擊力
    /// </summary>
    [Header("小紅帽的攻擊力"), Tooltip("攻擊力")]
    [Range(1, 5)]
    public float force = 2;

    /// <summary>
    /// 小紅帽的攻擊速度
    /// </summary>
    [Header("小紅帽的攻擊速度"), Tooltip("攻擊速度")]
    [Range(1.0f, 5.0f)]
    public float attackSpeed = 1.0f;

    /// <summary>
    /// 小紅帽的走路速度
    /// </summary>
    [Header("小紅帽的走路速度"), Tooltip("走路速度")]
    [Range(1.0f, 15.0f)]
    public float walkSpeed = 1.0f;

    [Header("小紅帽走路聲音"), Tooltip("小紅帽走路聲")]
    /// <summary>
    /// 小紅帽走路聲
    /// </summary>
    // public AudioClip redWalkSound;

    /// <summary>
    /// 小紅帽HP槽
    /// </summary>
    [Header("小紅帽HP槽")]
    public Image LR_HPBar;

    float scriptHp;
    public float _scriptHp { get => scriptHp; set => scriptHp = value; }

    /// <summary>
    /// 小紅帽 MP槽
    /// </summary>
    [Header("小紅帽MP槽")]
    public Image LR_MPBar;

    float scriptMp = 4;
    public float _scriptMp { get => scriptMp; set => scriptMp = value; }

    #endregion 小紅帽的基礎能力值 結束

    /// <summary>
    /// 產生 鐮刀特效的物件
    /// </summary>
    // public GameObject sickleEffectObj;

    /// <summary>
    /// 施放技能,產生的線圈
    /// </summary>
    // public GameObject SkillObj;

    #region 技能倒數計時

    [Header("技能倒數的物件")]
    public Image skillTimerImage;

    private bool isSkill;

    /// <summary>
    /// 使用技能的冷卻時間(分子)
    /// </summary>
    private float skillTimer = 0f;
    public float _skillTimer { get => skillTimer; set => skillTimer = value; }

    /// <summary>
    /// 使用技能的冷卻時間(分母)
    /// </summary>
    private float SkillTimer = 3f;

    #endregion 技能倒數計時 結束

    #region 小紅帽物理特性

    /// <summary>
    /// 小紅帽的走路旋轉角度
    /// </summary>
    public Vector3 angle;

    //private Animator LR_ani;

    // private Transform Cam;
    // private float RotateCam = 5.0f;


    /// <summary>
    /// 小紅帽的角色本體(剛體)
    /// </summary>
    private Rigidbody rig;


    /// <summary>
    /// 是否在森林地面上方
    /// </summary>
    private bool isGround
    {
        get
        {
            if (transform.position.y < 4.8f) return true;
            else return false;
        }
    }

    #endregion 小紅帽物理特性 結束

    // 使用GameManager管理數值及劇情
    // 主要用來呼叫 GM 紀錄取得 聖骸的數量
    // 然後取得 一定數量後, 讓小紅帽碰到中央場景,觸發變人事件
    // 控制 小紅帽未收集 全部道具, 但是在路途中被小怪殺死的結局
    // 或是 小紅帽收集全部聖骸, 但是被大野狼打到,觸發第二結局
    // 最後是, 如果滿血打倒大野狼了, 觸發 完美結局專用
    public GameManager GM;


    #endregion 基礎欄位與屬性 結束

    #region 方法

    #region 基本操作
    /// <summary>
    /// 移動：八個方向
    /// </summary>
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(h, 0, v);

        // 如果 按下移動鍵 角度 = 角度.插值(原本角度，要前往的方向角度，插值百分比)
        if (h != 0 || v != 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        // 剛體.移動(原本座標 + 輸入的移動量 * 速度 * 1 / 60)
        rig.MovePosition(transform.position + new Vector3(h, 0, v) * walkSpeed * Time.deltaTime);

        GetComponent<Animator>().SetBool("Walk", Mathf.Abs(v) > 0 || Mathf.Abs(v) > 0);
        // 此段動畫會有問題
    } // 移動功能 結束

    /// <summary>
    /// 攻擊的方法
    /// </summary>
    public void LR_Attack()
    {
        // 按下滑鼠左鍵
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("Att", true);  // 普通攻擊
            UseSkill(1);                                    // 扣除 1 點體力值

            // 如果 MP 值 小於等於 0,就暫時不能攻擊
            if (scriptMp <= 0f)
            {
                
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Att", false);
        }


        // 按下滑鼠右鍵,產生鎖住大野狼的線圈
        if (Input.GetMouseButtonDown(1))
        {
            // GetComponent<Animator>().SetBool("Skill", true); // 施放技能的動畫還沒有處理好
            TimeCountAdd();
            // Instantiate(SkillObj,transform.position,Quaternion.identity);

        }
    }

    /// <summary>
    /// 受傷的方法
    /// </summary>
    /// <param name="hurt"></param>
    public void LR_Hurt(float hurt)
    {
        _scriptHp -= hurt;
        LR_HPBar.fillAmount = _scriptHp / LR_HP;
        //gameObject.GetComponent<Animator>().SetTrigger("Hurt");
    }

    /// <summary>
    /// 使用攻擊後的狀態,現階段用按鈕暫時呼叫測試,OK了再改 private(以下時間倒數計時都一樣)
    /// </summary>
    /// <param name="Consume"></param>
    public void UseSkill(float Consume)
    {
        _scriptMp -= Consume;
        LR_MPBar.fillAmount = _scriptMp / LR_MP;
    }

    /// <summary>
    /// 體力值若小於4, 會隨著時間經過回復
    /// </summary>
    private void SkillFiller()
    {
        if (_scriptMp < 4f)
        {
            _scriptMp += 0.5f * Time.deltaTime;
            LR_MPBar.fillAmount = _scriptMp / LR_MP;        // 必須加此段,不然會沒有體力填充的動畫去跑
        }
    }

    /// <summary>
    /// 發動技能時,倒數直接從 3 開始
    /// </summary>
    public void TimeCountAdd()
    {
        // 如果倒數計時小於等於0秒時
        if(_skillTimer <= 0f)
        {
            _skillTimer += 3f;                                          // 秒數直接加 3 秒
            skillTimerImage.fillAmount = _skillTimer / SkillTimer;
        }
    }

    /// <summary>
    /// 倒數計時變成3時, 隨時間減少,直到0為止
    /// </summary>
    public void TimeCountMinus()
    {
        if (_skillTimer >= 0f && _skillTimer < 3f)
        {
            _skillTimer -= Time.deltaTime * 1f;
            skillTimerImage.fillAmount = _skillTimer / SkillTimer;
        }
    }

    #endregion 基本操作 結束

    #region 呼叫各結局
    /// <summary>
    /// 完美結局(小紅帽平安回到奶奶家)
    /// </summary>
    private void HappyScequence()
    {
        if (_scriptHp == LR_HP)
        {
            //SceneManager.LoadScene("NormalScequence");
        }
    }

    /// <summary>
    /// 一般結局(小紅帽變成狼人)
    /// </summary>
    private void NormalScequence()
    {

        if (_scriptHp < LR_HP)
        {
            SceneManager.LoadScene("NormalScequence");
        }
    }

    /// <summary>
    /// 小紅帽被小怪打倒(已銜接),最後由狼人那邊呼叫
    /// </summary>
    public void GameOver1()
    {
        if (_scriptHp <= 0)
        {
            SceneManager.LoadScene("GameOver1");
        }
    }

    /// <summary>
    /// 小紅帽被大野狼給劇情殺,因為要別的場景呼叫,所以需要改成 public(等待susan的動畫)
    /// </summary>
    public void GameOver2()
    {
        SceneManager.LoadScene("GameOver2");
    }

    #endregion 呼叫各結局 結束

    #endregion  方法結束

    #region 事件
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        _scriptHp = LR_HP;
        _scriptMp = LR_MP;
    }

    private void Update()
    {
        Move();
        LR_Attack();
        GameOver1();    // 最後由狼人那邊呼叫,因此此段可以刪除
        SkillFiller();
        TimeCountMinus();
    }

    #endregion 事件 結束
}