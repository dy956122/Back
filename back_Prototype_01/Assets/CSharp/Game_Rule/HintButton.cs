using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    # region 陣列欄位
    /// <summary>
    /// 提示圖
    /// </summary>
    [Header("提示圖"),Tooltip("提示圖")]
    public Image[] teachButon;

    /// <summary>
    /// 移動時的提示圖
    /// </summary>
    [Header("移動時的提示圖"), Tooltip("移動時的提示圖")]
    public Sprite[] teachOpenButon;

    /// <summary>
    /// 不移動時的提示圖
    /// </summary>
    [Header("不移動時的提示圖"), Tooltip("不移動時的提示圖")]
    public Sprite[] teachCloseButon;

    #endregion 陣列欄位 結束

    private void Update()
    {
        ImageChange();
    }

    void ImageChange()
    {
        // 利用 陣列 以及 三元運算子 來調換圖片
        // 對應按鈕 = 壓下按鈕後，如果答案為真，則為 啟用的圖片，否則為 關閉的圖片
        teachButon[0].sprite = Input.GetKey(KeyCode.W)? teachOpenButon[0]: teachCloseButon[0];
        teachButon[1].sprite = Input.GetKey(KeyCode.S)? teachOpenButon[1]: teachCloseButon[1];
        teachButon[2].sprite = Input.GetKey(KeyCode.A)? teachOpenButon[2]: teachCloseButon[2];
        teachButon[3].sprite = Input.GetKey(KeyCode.D)? teachOpenButon[3]: teachCloseButon[3];
    }

}
