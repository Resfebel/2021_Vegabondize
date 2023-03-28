using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GaugeUI : MonoBehaviour
{
    public Image gauge;
    public float fillAmount;                    // 게이지가 채워지는 양 -> 스테이지마다 다르기 때문에 외부에서 설정할 수 있게
    SceneDirector sceneDirector;                // loadNextstage() 메소드 호출 위해.

    // 몬스터 잡을 때 게이지가 증가하는 메소드
    public void gaugeUp()
    {
        this.gauge.fillAmount += fillAmount;    // 잡을 때 마다 지정한 양 만큼 게이지 증가
    }
    void Start()
    {
        sceneDirector = GameObject.Find("SceneDirector").GetComponent<SceneDirector>();
        gauge.fillAmount = 0;                   // 시작했을 때 게이지 0으로 초기화
    }
    void Update()
    {
        // 할당 게이지 이상으로 채워졌을 시
        if(gauge.fillAmount >= 0.39f)
        {
            // 다음 스테이지로 이동 : sceneDirector 스크립트의 loadNextstage() 메소드 호출
            sceneDirector.loadNextStage();
        }
    }
}
