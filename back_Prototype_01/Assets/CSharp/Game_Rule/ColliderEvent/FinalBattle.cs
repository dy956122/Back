using UnityEngine;

public class FinalBattle : MonoBehaviour
{
    /// <summary>
    /// 打開介面中的決戰畫面 1 跟2,順便讓狼人出現
    /// </summary>
    [SerializeField]
    private GameObject image1, image2, wolf;

    // 第一、二張圖,及大野狼出現的時間
    public float image1AppearTime, image2AppearTime, wolfAppearTime;

    private void image2Open()
    {
        image1.SetActive(false);
        image2.SetActive(true);
    }

    private void image2Close()
    {
        image2.SetActive(false);
    }

    private void WolfAppear()
    {
        wolf.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LR")
        {
            image1.SetActive(true);
            Invoke("image2Open", image1AppearTime);         // 隔幾秒鐘後呼叫功能
            Invoke("image2Close", image2AppearTime);
            Invoke("WolfAppear", wolfAppearTime);
        }
    }
}
