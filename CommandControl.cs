using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CommandControl : MonoBehaviour
{
    public TextMesh commandText;
    public GameObject currentEnemy;                  // 부모를 상속받아옴
    StringBuilder commandList = new StringBuilder(); // 랜덤으로 만든 커맨드를 담아두는 곳
    int num;                                         // 한번 만들 때 만들어질 커맨드 수
    SelectControl currentColor;                      // 현재 선택중인 색이 무엇인지 SelectControl에서 가져오기 위해.
    GaugeUI gauge;                                   // gaugeUp() 메소드 호출 위해.
    PlayerMotionControl player;                      // catchMotion() 메소드 호출 위해.

    void Start()
    {
        currentColor = GameObject.Find("Select Color").GetComponent<SelectControl>();
        gauge = GameObject.Find("Image").GetComponent<GaugeUI>();
        player = GameObject.Find("Player").GetComponent<PlayerMotionControl>();

        // 받아온 몬스터 오브젝트에 커맨드를 상속시킴
        this.gameObject.transform.SetParent(currentEnemy.transform);

        // 랜덤으로 커맨드 생성 : 스테이지마다 만들어진느 커맨드 수 다르게.
        // 게이지가 채워지는 양으로 스테이지 구분해서 만들 커맨드 수 결정
        if (gauge.fillAmount == 0.08f) num = 4;
        else if (gauge.fillAmount == 0.06f) num = 5;
        else if (gauge.fillAmount == 0.05f) num = 6;
        for (int i = 0; i < num; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 0: commandList.Append("↑"); break;
                case 1: commandList.Append("↓"); break;
                case 2: commandList.Append("←"); break;
                case 3: commandList.Append("→"); break;
            }
            // TextMesh의 텍스트 내용을 랜덤으로 만든 커맨드로 변경
            commandText = GetComponent<TextMesh>();
            commandText.text = commandList.ToString();
        }
    }

    void Update()
    {
        // 커맨드 입력 //
        // 현재 선택중인 색과 같은 색인 몬스터들만 해당되도록
        if (currentEnemy.name.Contains(currentColor.SpriteRenderer.sprite.name))
        {
            // 방향키가 커맨드와 일치할 때 해당 커맨드 삭제 //
            // 위쪽 방향키 눌렀을 때
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (this.commandText.text[0].Equals('↑')) commandText.text = commandText.text.Substring(1);
            }
            // 아래쪽 방향키 눌렀을 때
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (this.commandText.text[0].Equals('↓')) commandText.text = commandText.text.Substring(1);
            }
            // 왼쪽 방향키 눌렀을 때
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (this.commandText.text[0].Equals('←')) commandText.text = commandText.text.Substring(1);
            }
            // 오른쪽 방향키 눌렀을 때
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (this.commandText.text[0].Equals('→')) commandText.text = commandText.text.Substring(1);
            }

            // 커맨드 모두 없앴을 시 //
            if (commandText.text.Length == 0)
            {
                // 플레이어가 잡는 모션 : PlayerMotionControl 스크립트에 있는 catchMotion() 메소드 호출
                player.catchMotion();
                // 몬스터 삭제
                Destroy(currentEnemy);
                // 게이지 증가
                gauge.gaugeUp();

            }
        }
    }
}
