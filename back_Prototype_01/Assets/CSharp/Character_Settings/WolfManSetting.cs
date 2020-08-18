using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfManSetting : AItest
{
    public GameObject wolfScratch;

    public Transform CreatePos;

    protected override void GameOver()
    {
        if (LR._scriptHp <= 0)
        {
            LR.GameOver1();             // 如果此角色被開啟,則所有在場上的小怪腳本,內部的GameOver功能都會被替換成GameOver1 (此腳本從玩家腳本呼叫)
        }
    }

    protected override void Track()
    {
        if (Vector3.Distance(transform.position, Target.position) <= trackRange)
        {
            transform.LookAt(Target);
            transform.position = Vector3.Lerp(gameObject.transform.position, Target.position, Time.deltaTime * speed);
            GetComponent<Animator>().SetBool("Move", true);     // 追加移動動畫(開啟)
        }
        else if(Vector3.Distance(transform.position, Target.position) <= 0)
        {
            GetComponent<Animator>().SetBool("Move", false);    // 追加移動動畫(結束)
        }
    }

    public void Hurt(int damage)
    {
        HP -= damage;
        if (HP <= 0f)
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Die");

            speed = 0;
            
            Destroy(gameObject, 2.5f);

            LR.HappyScequence();
        }
    }

    public void CreateWolfScratch()
    {
        Transform temp = Instantiate(wolfScratch, CreatePos).transform;

        temp.localPosition = Vector3.zero;          // 讓暫存物件座標位置歸零
        temp.localEulerAngles = Vector3.zero;    // 讓暫存物件座標角度歸零

        temp.SetParent(null);                            // 產生後的物件,使其誕生在原位置,不會因為角色移動而有其他位移、旋轉
    }
}
