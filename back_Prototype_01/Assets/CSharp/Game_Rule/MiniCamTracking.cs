using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamTracking : MonoBehaviour
{
    #region 基礎欄位
    /// <summary>
    /// 玩家位移元件
    /// </summary>
    private Transform Player;

    [Header("追蹤速度"), Range(0.1f, 60.0f)]
    public float ChasingSpeed;

    public float A = 0;
    public float B = 100;

    public Vector2 v2A = Vector2.zero;
    public Vector2 v2B = Vector2.one * 1000;

    #endregion 基礎欄位 結束

    #region 設定方法
    private void Track()
    {
        Vector3 posTrack = Player.position;
        posTrack.y += 100.0f;
        //posTrack.z += -25f;

        Vector3 posCam = transform.position;

        posCam = Vector3.Lerp(posCam, posTrack, 0.5f * Time.deltaTime * ChasingSpeed);
        transform.position = posCam;

    }
    #endregion 設定方法結束


    #region 事件
    void Start()
    {
        // 最後請把要追蹤的角色名字替換掉
        Player = GameObject.Find("New little red (1)FINISH").transform;
    }


    void Update()
    {
        A = Mathf.Lerp(A, B, 0.5f);
        v2A = Vector2.Lerp(v2A, v2B, 0.5f);
    }

    private void LateUpdate()
    {
        Track();
    }
    #endregion 事件 結束

}
