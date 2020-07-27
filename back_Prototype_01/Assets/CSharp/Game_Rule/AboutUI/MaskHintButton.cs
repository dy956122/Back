using UnityEngine;

public class MaskHintButton : MonoBehaviour
{
    float turnspeed = 1f;
    public void maskHintButtonHide()
    {
        if (gameObject.transform.position.x > - 190.85f)
        {
            gameObject.transform.Translate(Vector3.right * turnspeed * Time.deltaTime);
        }
    }

    public void maskHintButtonShow()
    {
        if (gameObject.transform.position.x < 206.8f)
        {
            gameObject.transform.Translate(Vector3.left * turnspeed * Time.deltaTime);
        }
    }
}
