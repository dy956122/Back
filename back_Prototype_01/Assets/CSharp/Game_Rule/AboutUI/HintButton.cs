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
    [Header("提示圖"), Tooltip("提示圖"), SerializeField]
    private Image[] teachButon;

    /// <summary>
    /// 移動時的提示圖
    /// </summary>
    [Header("移動時的提示圖"), Tooltip("移動時的提示圖"), SerializeField]
    private Sprite[] teachOpenButon;

    /// <summary>
    /// 不移動時的提示圖
    /// </summary>
    [Header("不移動時的提示圖"), Tooltip("不移動時的提示圖"), SerializeField]
    private Sprite[] teachCloseButon;

    /// <summary>
    /// 滑鼠的提示
    /// </summary>
    [Header("滑鼠的提示"), Tooltip("滑鼠的提示"), SerializeField]
    private Image mouse;

    /// <summary>
    /// 滑鼠壓下後的反應,所對應的圖示
    /// </summary>
    [Header("滑鼠壓下後的反應"), Tooltip("滑鼠壓下後的反應"), SerializeField]
    private Sprite[] mouseClickButton;

    #endregion 陣列欄位 結束

    private void Update()
    {
        ImageChange();
        ImageMouseChange();
    }

    void ImageChange()
    {
        // 利用 陣列 以及 三元運算子 來調換圖片
        // 對應移動按鈕 = 壓下按鈕後，如果答案為真，則為 啟用的圖片，否則為 關閉的圖片
        teachButon[0].sprite = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? teachOpenButon[0] : teachCloseButon[0];
        teachButon[1].sprite = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? teachOpenButon[1] : teachCloseButon[1];
        teachButon[2].sprite = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? teachOpenButon[2] : teachCloseButon[2];
        teachButon[3].sprite = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? teachOpenButon[3] : teachCloseButon[3];
    }

    void ImageMouseChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse.sprite = mouseClickButton[0];
        }
        else if (Input.GetMouseButtonDown(1))
        {
            mouse.sprite = mouseClickButton[1];
        }
        else
        {
            mouse.sprite = mouseClickButton[2];
        }
    }
    }
