using UnityEngine;

public class BookScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject Bookani;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().tag == "Player")
        {
            Bookani.SetActive(true);
            Destroy(gameObject);
        }
    }
}