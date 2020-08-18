using UnityEngine;

public class CloseTeaachHint : MonoBehaviour
{
    public GameObject TeachButton;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LR")
        {
            TeachButton.SetActive(false);
        }
    }
}
