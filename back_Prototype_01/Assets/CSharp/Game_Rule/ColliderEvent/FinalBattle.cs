using UnityEngine;

public class FinalBattle : MonoBehaviour
{
    /// <summary>
    /// 打開介面中的決戰畫面 1 跟2
    /// </summary>
    [SerializeField]
    private GameObject image1, image2;

    private void image2Open()
    {
        image1.SetActive(false);
        image2.SetActive(true);
    }

    private void image2Close()
    {
        image2.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LR")
        {
            image1.SetActive(true);
            Invoke("image2Open", 1);
            Invoke("image2Close", 3);
        }
    }

}
