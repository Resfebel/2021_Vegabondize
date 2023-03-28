using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // LoadScene() 메소드를 사용하기 위함

public class SceneDirector : MonoBehaviour
{
    public string nextStage;            // 씬마다 다음으로 이동해야하는 씬이 다르기 때문에 외부에서 지정할 수 있도록
    // 게임오버 씬으로 이동하는 메소드
    public void loadGameover()
    {
        SceneManager.LoadScene("GameoverScene");
    }
    // 다음 씬(클리어씬 포함)으로 이동하는 메소드
    public void loadNextStage()
    {
        SceneManager.LoadScene(nextStage);
    }
}
