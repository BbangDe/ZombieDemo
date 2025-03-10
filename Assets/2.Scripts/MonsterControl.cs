using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    // MonsterManager 연동
    MonsterManager monsterManager;
 
    // 몬스터 이동 스피드
    [SerializeField]
    float speed;
    // 몬스터 기어오르는 스피드
    [SerializeField]
    float upSpeed;
    // 몬스터의 리지드바디
    [SerializeField]
    Rigidbody2D rb;

    // 기어오르기 여부
    bool upOk;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 앞에 부딪힌 오브젝트가 Monster라면
        if(collision.gameObject.tag == "Monster")
        {
            // 뒤에 있는 몬스터의 경우
            if(transform.position.x > collision.gameObject.transform.position.x)
            {
                // 확률에 따라 기어 오를지 아닐지 결정
                upOk = monsterManager.GetUpOk();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Monster콜라이더를 빠져나오면 기어오르기 종료
        if (collision.gameObject.tag == "Monster")
        {
            upOk = false;
        }
    }

    // 생성될때 MonsterManager 연동에 사용할 함수
    public void SetMonsterManager(MonsterManager _manager)
    {
        monsterManager = _manager;
    }

    private void Update()
    {
        // 앞으로 지속적으로 이동
        rb.velocity = Vector3.zero;
        rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);

        // 기어오르기 상태라면
        if (upOk)
        {
            // 중력을 1로 설정 후 위로 올라가기
            rb.gravityScale = 1;
            rb.MovePosition(rb.position + Vector2.up * upSpeed * Time.deltaTime);
        }
        // 기어 오르기 종료라면
        else
        {
            // 중력을 강하게 변경
            rb.gravityScale = 10;
        }
    }
}
