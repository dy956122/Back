using UnityEngine;

public class AItest : MonoBehaviour
{
    // AI角色 試寫

    private int HP = 2;

    private float Att = 2;

    // public GameObject LR;

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
                GameObject.Find("LR").GetComponent<Player>().LR_Hurt(Att);
                // 啟動攻擊動畫
                timer = 5;
            }
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
