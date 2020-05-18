using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedRidingHoodSetting : MonoBehaviour
{
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
    [Range(1.0f, 3.0f)]
    public float walkSpeed = 1.0f;

    /// <summary>
    /// 小紅帽的跑步加速度
    /// </summary>
    [Header("小紅帽的跑步加速度"), Tooltip("跑步加速度")]
    [Range(1, 3)]
    public byte runAccelerate;

    void Start()
    {
        print("哈囉,我是小紅帽,大野狼不要欺負我喔!");
    }

   
   void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.W)) {
        
        }*/
    }
}
