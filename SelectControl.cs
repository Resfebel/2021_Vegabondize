using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControl : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;   // CommandControl 스크립트에서 접근 가능하기 위해
    // 네 가지 색의 풍등 스프라이트 -> 외부에서 설정하기 위해 //
    public Sprite Red;
    public Sprite Blue;
    public Sprite Black;
    public Sprite White;

    void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Red;    // 디폴트 색 = 빨강.
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))         // A 누르면 적색 스프라이트로 변경
        {
            SpriteRenderer.sprite = Red;
        }
        else if(Input.GetKeyDown(KeyCode.S))    // S 누르면 청색 스프라이트로 변경
        {
            SpriteRenderer.sprite = Blue;
        }
        else if (Input.GetKeyDown(KeyCode.D))   // D 누르면 흑색 스프라이트로 변경
        {
            SpriteRenderer.sprite = Black;
        }
        else if (Input.GetKeyDown(KeyCode.F))   // F 누르면 백색 스프라이트로 변경
        {
            SpriteRenderer.sprite = White;
        }
    }
}
