using UnityEngine;

public class AItest : MonoBehaviour
{
    // AI角色 試寫

    private int HP = 2;

    private float Att = 2;

    private float timer = 5;

    private Transform Target;

    private void Track()
    {
        if (Vector3.Distance(transform.position, Target.position) <= 50f)
        {
            transform.LookAt(Target);
            transform.position = Vector3.Lerp(gameObject.transform.position, Target.position, Time.deltaTime);
        }
    }


    private void Attack()
    {
        timer -= Time.deltaTime;

        if (Vector3.Distance(transform.position, Target.position) <= 2f)
        {
            if (timer <= 0)
            {
                
                Target.GetComponent<Player>().LR_Hurt(Att);
                // 啟動攻擊動畫
                GetComponentInChildren<Animator>().SetBool("Att", true);
                // GetComponent<Animator>().SetBool("Att", true);
                timer = 5;
            }
            // GetComponentInChildren<Animator>().SetBool("Att", false);
        }

    }

    public void Hurt(int damage)
    {
        HP -= damage;
        if (HP <= 0f)
        {
            GameObject.Destroy(gameObject);
        }
    }





    // Start is called before the first frame update
    void Awake()
    {
        Target = GameObject.Find("LR").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Track();
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
