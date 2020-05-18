using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManSetting : MonoBehaviour
{
    /// <summary>
    /// 大野狼的生命值
    /// </summary>
    [Header("大野狼的生命值"),Tooltip("生命值")]
    [Range(1,12)]
    public byte HP = 12;

    /// <summary>
    /// 大野狼的攻擊力
    /// </summary>
    [Header("大野狼的攻擊力"), Tooltip("攻擊力")]
    [Range(1, 5)]
    public byte force = 3;

    /// <summary>
    /// 大野狼的攻擊速度
    /// </summary>
    [Header("大野狼的攻擊速度"), Tooltip("攻擊速度")]
    [Range(1.0f, 5.0f)]
    public float attackSpeed = 2.5f;

    /// <summary>
    /// 大野狼的走路速度
    /// </summary>
    [Header("大野狼的走路速度"), Tooltip("走路速度")]
    [Range(1.0f, 3.0f)]
    public float walkSpeed = 2.0f;

    /// <summary>
    /// 大野狼的跑步加速度
    /// </summary>
    [Header("大野狼的跑步加速度"), Tooltip("跑步加速度")]
    [Range(1, 3)]
    public byte runAccelerate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
