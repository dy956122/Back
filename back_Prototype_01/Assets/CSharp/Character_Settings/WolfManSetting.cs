using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfManSetting : AItest
{
    protected override void GameOver()
    {
        if (LR._scriptHp <= 0)
        {
            LR.GameOver1();
        }
    }
}
