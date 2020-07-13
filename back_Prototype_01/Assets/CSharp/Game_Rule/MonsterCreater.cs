using UnityEngine;

public class MonsterCreater : MonoBehaviour
{
    public GameObject Voodoo;
    public GameObject CreaterPonit;

    void Update()
    {
        Invoke("Create", 1);

    }


    public void Create()
    {
        Instantiate(Voodoo, Vector3.zero, Quaternion.identity);
    }

}
