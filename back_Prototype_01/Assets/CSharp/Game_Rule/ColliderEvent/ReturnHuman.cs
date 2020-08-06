using UnityEngine;

public class ReturnHuman : MonoBehaviour
{
   [SerializeField]
    private GameManager GM;

    /// <summary>
    /// 觸發GM裡面的方法
    /// 如果小紅帽收集到7個聖骸,碰到此物件就會觸發變成人類的情節
    /// </summary>
    /// <param name="hit"></param>
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<Rigidbody>().tag =="Player")
        {
            GM.ReturnHumanEvent();                                    // 觸發GM裡面的變回人形方法,開啟相關UI
            GetComponent<Collider>().enabled = false;                 // 自身的碰撞器關閉,不然會因為玩家一直碰到碰撞器而當機
        }
    }
}
