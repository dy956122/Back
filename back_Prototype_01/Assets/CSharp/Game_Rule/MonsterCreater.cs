using UnityEngine;

public class MonsterCreater : MonoBehaviour
{
    /// <summary>
    /// 創建小怪
    /// </summary>
    public GameObject Voodoo;

    /// <summary>
    /// 生怪點
    /// </summary>
    public GameObject[] CreaterPonit;

    void Update()
    {
        // InvokeRepeating("Create", 1,2);
    }


    /// <summary>
    /// 創建 小怪
    /// </summary>
    public void Create()
    {
        Instantiate(Voodoo, Vector3.zero, Quaternion.identity);
    }

}
