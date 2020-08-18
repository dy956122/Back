using UnityEngine;

// 教學關專用的腳本
public class Teach : MonoBehaviour
{
    // 改成碰到碰撞器就關掉

    public int buttonNum;

    /*
    [SerializeField]
    private GameObject[] teachButton, teachText;

    private int teachButtonNum = 0;

    public void TeachButtonVanish()
    {
        if (Input.GetMouseButtonDown(0))
        {
            teachButton[teachButtonNum].SetActive(false);
            teachText[teachButtonNum].SetActive(false);
            teachButtonNum++;
        }
    }

    public void TeachButtonAppear()
    {
        if (Input.GetMouseButtonDown(0) && teachButtonNum <=4)
        {
            teachButton[teachButtonNum+1].SetActive(true);
            teachText[teachButtonNum+1].SetActive(true);
        }
    }
    */

    public void VanishButton()
    {
        buttonNum++;

    }

    private void Awake()
    {
       // teachButton[teachButtonNum].SetActive(true);
       // teachText[teachButtonNum].SetActive(true);
    }

    private void Update()
    {
       // TeachButtonVanish();
       // TeachButtonAppear();
    }
}
