using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    // MonsterManager ����
    MonsterManager monsterManager;
 
    // ���� �̵� ���ǵ�
    [SerializeField]
    float speed;
    // ���� �������� ���ǵ�
    [SerializeField]
    float upSpeed;
    // ������ ������ٵ�
    [SerializeField]
    Rigidbody2D rb;

    // �������� ����
    bool upOk;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �տ� �ε��� ������Ʈ�� Monster���
        if(collision.gameObject.tag == "Monster")
        {
            // �ڿ� �ִ� ������ ���
            if(transform.position.x > collision.gameObject.transform.position.x)
            {
                // Ȯ���� ���� ��� ������ �ƴ��� ����
                upOk = monsterManager.GetUpOk();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Monster�ݶ��̴��� ���������� �������� ����
        if (collision.gameObject.tag == "Monster")
        {
            upOk = false;
        }
    }

    // �����ɶ� MonsterManager ������ ����� �Լ�
    public void SetMonsterManager(MonsterManager _manager)
    {
        monsterManager = _manager;
    }

    private void Update()
    {
        // ������ ���������� �̵�
        rb.velocity = Vector3.zero;
        rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);

        // �������� ���¶��
        if (upOk)
        {
            // �߷��� 1�� ���� �� ���� �ö󰡱�
            rb.gravityScale = 1;
            rb.MovePosition(rb.position + Vector2.up * upSpeed * Time.deltaTime);
        }
        // ��� ������ ������
        else
        {
            // �߷��� ���ϰ� ����
            rb.gravityScale = 10;
        }
    }
}
