using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // 네 가지 색의 몬스터 프리팹 -> 외부에서 설정하기 위해 //
    public GameObject redEnemy;
    public GameObject blueEnemy;
    public GameObject blackEnemy;
    public GameObject whiteEnemy;

    GameObject colorEnemy;              // 랜덤으로 결정된 색의 몬스터
    public GameObject commandList;      // 몬스터 밑에 올 커맨드
    public float span;                  // 몬스터가 새로 나타나는 시간 간격 -> 스테이지마다 다르기 때문에 외부에서 설정할 수 있게
    float delta = 0;
    int posX, posY;                     // 몬스터의 생성 위치

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;

            // 몬스터 색 랜덤으로 설정
            switch (Random.Range(0, 4))
            {
                case 0: colorEnemy = redEnemy; break;
                case 1: colorEnemy = blueEnemy; break;
                case 2: colorEnemy = blackEnemy; break;
                case 3: colorEnemy = whiteEnemy; break;
            }

            // 몬스터가 생성될 위치 랜덤으로 설정 (화면 바깥에서 생성되도록)
            switch (Random.Range(0, 4))
            {
                    case 0: posX = -10; posY = Random.Range(-6, 7); break;
                    case 1: posX = 10; posY = Random.Range(-6, 7); break;
                    case 2: posX = Random.Range(-10, 11); posY = -6; break;
                    case 3: posX = Random.Range(-10, 11); posY = 6; break;
            }
            Vector2 pos = new Vector2(posX, posY);

            // 몬스터 생성
            GameObject enemy = Instantiate(colorEnemy, pos, Quaternion.identity);

            // 몬스터 밑에 커맨드도 같이 생성
            Vector2 posCommand = new Vector2(posX, posY - 1f);
            GameObject command = Instantiate(commandList, posCommand, Quaternion.identity);

            // 커맨드를 몬스터에게 상속시키기 위해 부모가 될 몬스터 오브젝트를 보내줌.
            command.GetComponent<CommandControl>().currentEnemy = enemy;


        }
    }
}
