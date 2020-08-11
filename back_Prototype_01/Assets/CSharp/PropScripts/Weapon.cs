using UnityEngine;
// 使用武器 削減敵人生命值

public class Weapon : MonoBehaviour
{
    private Rigidbody Voodoo;
    private Rigidbody WolfMan;

    private void WeaponHurt()
    {
        /*if (Voodoo.tag == "Voodoo")
        {
            Voodoo.GetComponent<AItest>().Hurt(2);
        }
        else if (WolfMan.tag == "WolfMan")
        {
            WolfMan.GetComponent<AItest>().Hurt(0);
        }*/
    }


    private void Awake()
    {
        // Voodoo = GameObject.FindGameObjectWithTag("Voodoo").GetComponent<Rigidbody>();
        //WolfMan = GameObject.Find("WolfMan").GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);


        if (other.name == "voodoo idle")
        {
            Voodoo.GetComponent<AItest>().Hurt(2);
        }
        /*else if (WolfMan.tag == "WolfMan")
        {
            WolfMan.GetComponent<AItest>().Hurt(0);
        }*/
    }
}
