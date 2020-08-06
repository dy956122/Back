using UnityEngine;
// 使用武器 削減敵人生命值

public class Weapon : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().name == "Voodoo")
        {
            GetComponent<AItest>().Hurt(2);
            print("A");
        }
    }
}
