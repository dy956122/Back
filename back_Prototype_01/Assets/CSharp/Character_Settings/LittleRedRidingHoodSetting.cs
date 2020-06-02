using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedRidingHoodSetting : MonoBehaviour
{
    #region 基礎欄位與屬性

    /// <summary>
    /// 小紅帽的生命值
    /// </summary>
    [Header("小紅帽的生命值"), Tooltip("生命值")]
    [Range(1, 12)]
    public byte HP = 12;

    /// <summary>
    /// 小紅帽的魔力值
    /// </summary>
    [Header("小紅帽的魔力值"), Tooltip("魔力值")]
    [Range(1, 10)]
    public byte MP = 5;

    /// <summary>
    /// 小紅帽的攻擊力
    /// </summary>
    [Header("小紅帽的攻擊力"), Tooltip("攻擊力")]
    [Range(1, 5)]
    public byte force = 2;

    /// <summary>
    /// 小紅帽的攻擊速度
    /// </summary>
    [Header("小紅帽的攻擊速度"), Tooltip("攻擊速度")]
    [Range(1.0f, 5.0f)]
    public float attackSpeed = 1.5f;

    /// <summary>
    /// 小紅帽的走路速度
    /// </summary>
    [Header("小紅帽的走路速度"), Tooltip("走路速度")]
    [Range(1.0f, 50.0f)]
    public float walkSpeed = 1.0f;

    /// <summary>
    /// 小紅帽的跑步加速度
    /// </summary>
    [Header("小紅帽的跑步加速度"), Tooltip("跑步加速度")]
    [Range(1, 3)]
    public byte runAccelerate;

    /// <summary>
    /// 小紅帽的走路旋轉角度
    /// </summary>
    public Vector3 angle;

    //private Animator LR_ani;

    /// <summary>
    /// 小紅帽的角色本體
    /// </summary>
    private Rigidbody LR_rigibogy;

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


    #endregion 基礎欄位與屬性 結束




    #region 方法

    private void Move() //移動功能
    {

        #region 角色移動
        float v = Input.GetAxis("Vertical"); // 前後移動

        float h = Input.GetAxis("Horizontal"); // 左右移動

        // 前後推進
        LR_rigibogy.AddForce(transform.forward * walkSpeed * Mathf.Abs(v));

        // 左右移動
        LR_rigibogy.AddForce(transform.forward * walkSpeed * Mathf.Abs(h));

        #endregion 角色移動 結束

        #region 角色轉向
        if (v == 1) angle = new Vector3(0, 0, 0);
        else if (v == -1) angle = new Vector3(0, 180, 0);
        else if (h == 1) angle = new Vector3(0, 90, 0);
        else if (h == -1) angle = new Vector3(0, 270, 0);

        transform.eulerAngles = angle;
        #endregion 角色轉向 結束

    } // 移動功能 結束



    #endregion 方法結束



    #region 事件

    void Start()
    {
        LR_rigibogy = GetComponent<Rigidbody>();
        // print("哈囉,我是小紅帽,大野狼不要欺負我喔!");
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        
    }

    #endregion 事件 結束
}
