using UnityEngine;

public class FakeHouse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().tag == "Player")
        {
            GameObject.Find("LR").GetComponent<Player>().GameOver1();
        }
    }
}
