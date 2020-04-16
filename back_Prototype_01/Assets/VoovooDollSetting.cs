using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoovooDollSetting : MonoBehaviour
{
    /// <summary>
    /// 巫毒娃娃的生命值
    /// </summary>
    [Header("巫毒娃娃的生命值"), Tooltip("生命值")]
    [Range(1, 12)]
    public byte HP = 6;

    /// <summary>
    /// 巫毒娃娃的攻擊力
    /// </summary>
    [Header("巫毒娃娃的攻擊力"), Tooltip("攻擊力")]
    [Range(1, 5)]
    public byte force = 1;

    /// <summary>
    /// 巫毒娃娃的攻擊速度
    /// </summary>
    [Header("巫毒娃娃的攻擊速度"), Tooltip("攻擊速度")]
    [Range(1.0f, 5.0f)]
    public float attackSpeed = 1f;

    /// <summary>
    /// 巫毒娃娃的走路速度
    /// </summary>
    [Header("巫毒娃娃的走路速度"), Tooltip("走路速度")]
    [Range(1.0f, 3.0f)]
    public float walkSpeed = 1.0f;

    /// <summary>
    /// 巫毒娃娃的跑步加速度
    /// </summary>
    [Header("巫毒娃娃的跑步加速度"), Tooltip("跑步加速度")]
    [Range(1, 3)]
    public byte runAccelerate;

    /// <summary>
    /// 巫毒娃娃的道具掉落
    /// </summary>
    [Header("是否會掉落道具"), Tooltip("是否會掉落道具")]
    public bool 是否掉道具 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
