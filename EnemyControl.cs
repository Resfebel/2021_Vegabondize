using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject player;                   // 플레이어 위치 찾기, ouchMotion() 메소드 호출 위해          
    GameObject hpUI;                     // 피격 시 hp아이콘을 삭제하기 위해.
    SceneDirector sceneDirector;         // loadGameover() 메소드 호출 위해.

    static int count = 0;


    void Start()
    {
        // 플레이어 캐릭터를 찾기
        player = GameObject.Find("Player");
        sceneDirector = GameObject.Find("SceneDirector").GetComponent<SceneDirector>();
    }

    void Update()
    {
        // 몬스터 이동 : 플레이어를 향해 움직이도록.
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.02f);

        // 충돌 판정 //
        Vector2 p1 = this.transform.position;   p1.y -= 0.4f;   // 몬스터 원점 좌표
        Vector2 p2 = this.player.transform.position;            // 플레이어 원점 좌표
        Vector2 dir = p1 - p2;                                  // 두 원점 사이의 간격 
        float d = dir.magnitude;
        float r1 = 1f;                                          // 몬스터 반지름
        float r2 = 0.7f;                                        // 플레이어 반지름

        // 플레이어와 충돌했을 시.
        if (d < r1 + r2)
        {
            // 플레이어 공격받는 모션 : PlayerMotionControl 스크립트에 있는 ouchMotion() 메소드 호출
            player.gameObject.GetComponent<PlayerMotionControl>().ouchMotion();

            // 몬스터 사라지기 -> 커맨드는 몬스터에 상속되어있으므로 이때 같이 사라짐.
            Destroy(gameObject);

            // 체력 감소 : HP 오브젝트를 삭제, count 증가
            hpUI = GameObject.Find("HP");
            Destroy(hpUI);
            count++;
            // 만약 체력이 다 떨어졌다면
            if(count == 3)
                // 게임오버씬으로 이동 : sceneDirector 스크립트의 loadGameover() 메소드 호출
                sceneDirector.loadGameover();
        }
    }
}
