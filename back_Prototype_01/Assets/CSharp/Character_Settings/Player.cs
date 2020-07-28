using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.ShaderGraph.Internal;

public class Player : MonoBehaviour
{
    #region 基礎欄位與屬性

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
    private float SkillTimer;

    #endregion 技能倒數計時 結束


    // 使用GameManager管理數值及劇情
    public GameManager GM;

    #region 小紅帽物理特性

    /// <summary>
    /// 小紅帽的走路旋轉角度
    /// </summary>
    public Vector3 angle;

    //private Animator LR_ani;

    // private Transform Cam;
    // private float RotateCam = 5.0f;

    /// <summary>
    /// 小紅帽的角色本體
    /// </summary>
    private Rigidbody LR_rigibogy;
    /// <summary>
    /// 剛體
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


    #endregion 基礎欄位與屬性 結束

    #region 方法
    #region 角色移動(old)
    private void LR_Move() //移動功能
    {


        /* float v = Input.GetAxis("Vertical"); // 前後移動

        float h = Input.GetAxis("Horizontal"); // 左右移動

        // LR_rigibogy.AddForce(Cam.forward * walkSpeed * Mathf.Abs(v) + Cam.right * walkSpeed * Mathf.Abs(h));

        // float x = Input.GetAxis("Mouse X");
        // float y = Input.GetAxis("Mouse Y");
        // Cam.Rotate(y * RotateCam, RotateCam * x, 0);

        // 前後推進
        // LR_rigibogy.AddForce(transform.forward * walkSpeed * Mathf.Abs(v));

        // 左右移動
        // LR_rigibogy.AddForce(transform.forward * walkSpeed * Mathf.Abs(h));

        // 原本的是長這樣
        // LR_rigibogy.velocity = Vector3.forward * walkSpeed * Mathf.Abs(v) + Vector3.forward * walkSpeed * Mathf.Abs(h);
        LR_rigibogy.velocity = Vector3.forward * walkSpeed * v + Vector3.right * walkSpeed * h;

        #endregion 角色移動(old) 結束

        #region 角色轉向(old)
        if (v == 1) angle = new Vector3(0, 0, 0);
        else if (v == -1) angle = new Vector3(0, 180, 0);
        else if (h == 1) angle = new Vector3(0, 90, 0);
        else if (h == -1) angle = new Vector3(0, 270, 0);

        // 八方轉向 測試中
        else if (0 < h && 0 < v) angle = new Vector3(0, 45, 0);
        else if (h < 0 && v < 1) angle = new Vector3(0, -45, 0);
        else if (0 < h && v < 0) angle = new Vector3(0, 135, 0);
        else if (h < 0 && v < 0) angle = new Vector3(0, -135, 0);

        transform.eulerAngles = angle;*/
    }
    #endregion 角色轉向(old) 結束

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



        //GetComponent<Animator>().SetBool("LR_Walk", Mathf.Abs(v) > 0 || Mathf.Abs(v) > 0);
    } // 移動功能 結束

    public void LR_Attack()
    {
        if (Input.GetMouseButton(0))
        {

            // GetComponent<Animator>().SetBool(1, true);
            // GetComponent<Animator>().SetTrigger("Hurt");
        }

        // 按下滑鼠右鍵,產生鎖住大野狼的線圈
        if (Input.GetMouseButton(2))
        {
            GetComponent<Animator>().SetBool("Skill", true);
            TimeCountAdd();
            // Instantiate(SkillObj,transform.position,Quaternion.identity);

            /*if (_skillTimer -= 3f)
            {

            }*/

        }
    }

    public void LR_Hurt(float hurt)
    {
        _scriptHp -= hurt;
        LR_HPBar.fillAmount = _scriptHp / LR_HP;
        //gameObject.GetComponent<Animator>().SetTrigger("Hurt");
    }

    public void UseSkill(float Consume)
    {
        _scriptMp -= Consume;
        LR_MPBar.fillAmount = _scriptMp / LR_MP;
    }

    /// <summary>
    /// 發動技能時,倒數直接從 3 開始
    /// </summary>
    public void TimeCountAdd()
    {
        // 分子直接加 3 秒
        _skillTimer += 3f;
        skillTimerImage.fillAmount = _skillTimer / SkillTimer;
    }

    /// <summary>
    /// 倒數計時變成3時, 隨時間減少,直到0為止
    /// </summary>
    public void TimeCountMinus()
    {
        // print("OK");
        _skillTimer -= 1f ;
        skillTimerImage.fillAmount = _skillTimer / SkillTimer;

        /*if (0 <= _skillTimer )
        {
            _skillTimer -= Time.deltaTime * 1f;
            skillTimerImage.fillAmount = _skillTimer / SkillTimer;
        }*/
    }



    /// <summary>
    /// 一般結局(小紅帽變成狼人)
    /// </summary>
    private void NormalScequence()
    {
        SceneManager.LoadScene("NormalScequence");
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
    /// 小紅帽被大野狼給劇情殺,等待susan的動畫
    /// </summary>
    private void GameOver2()
    {
        SceneManager.LoadScene("GameOver2");
    }

    #endregion  方法結束

    #region 事件
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }


    void Start()
    {
        LR_rigibogy = GetComponent<Rigidbody>();
        _scriptHp = LR_HP;
        _scriptMp = LR_MP;
    }

    private void Update()
    {
        Move();
        // LR_Attack();
        GameOver1();
    }

    #endregion 事件 結束
}



