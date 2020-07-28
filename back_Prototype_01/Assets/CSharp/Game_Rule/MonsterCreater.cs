using UnityEngine;

public class MonsterCreater : MonoBehaviour
{
    /// <summary>
    /// 創建小怪
    /// </summary>
    [Header("創建小怪"), Tooltip("創建小怪")]
    public GameObject Voodoo;

    /// <summary>
    /// 生怪點
    /// </summary>
    [Header("生怪點"),Tooltip("生怪點")]
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
        Instantiate(Voodoo, CreaterPonit[Random.Range(0,CreaterPonit.Length)].transform.position, Quaternion.identity);
    }

}
