using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamTracking : CameraTracing
{
    #region 設定方法
    protected override void Track()
    {
        Vector3 posTrack = Player.position;
        posTrack.y += 100.0f;
        //posTrack.z += -25f;

        Vector3 posCam = transform.position;

        posCam = Vector3.Lerp(posCam, posTrack, 0.5f * Time.deltaTime * ChasingSpeed);
        transform.position = posCam;

    }
    #endregion 設定方法結束
}
