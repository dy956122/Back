using UnityEngine;
using UnityEngine.UI;

public class MagicCircle : MonoBehaviour
{
    [SerializeField]
    private GameObject returnHuman;
    [SerializeField]
    private GameManager GM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().tag == "Player")
        {
            if (GM.skullNum == 7)
            {
                returnHuman.SetActive(true);
            }
        }
    }
}
