using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandmaHouseDoor : MonoBehaviour
{
    #region 小紅帽滿血通關
    [SerializeField]
    private Player LR;

    /// <summary>
    /// 完美結局
    /// </summary>
    private void FullHpPass()
    {
        //當玩家的血量是滿的,且場上沒有大野狼時,觸發完美結局
        if (LR.LR_HP == 5 && !GameObject.Find("wolf"))
        {
            SceneManager.LoadScene("win");
        }
    }
    #endregion 小紅帽滿血通關 結束

    private void OnTriggerEnter(Collider other)
    {
        FullHpPass();
    }
}
