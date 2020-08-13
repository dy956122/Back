using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BookScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject bookAni;

    private AudioSource bookSound;

    private AudioClip bookOpen;

    private void Awake()
    {
        bookSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().tag == "Player")
        {
            bookAni.SetActive(true);
            Destroy(gameObject);
            bookSound.Play();
        }
    }
}