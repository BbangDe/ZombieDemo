using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    // ���� ��� �ִ� �� ������Ʈ
    [SerializeField]
    GameObject prev;

    // ������ ������ �� ������Ʈ
    [SerializeField]
    GameObject next;

    // �� �̵� ���ǵ�
    [SerializeField]
    float speed;

    // �� ������Ʈ���� �Ÿ� ����
    [SerializeField]
    float pivot;

    // ���� �̵� �Ÿ� ����
    float count;

    // �̵��Ÿ� 0���� �ʱ�ȭ
    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        // 2���� �� ������Ʈ�� �̵��ӵ��� ���� �̵�
        prev.transform.position += Vector3.left * speed * Time.deltaTime;
        next.transform.position += Vector3.left * speed * Time.deltaTime;
        // �̵��Ÿ� ���� ������Ʈ
        count += speed * Time.deltaTime;

        // �� ������Ʈ ���� �Ÿ� �̻����� �̵����� ���
        if(count >= pivot)
        {
            // �� �� ������Ʈ, ���� �� ������Ʈ�� ���� ��ȯ�ϰ�
            GameObject tmp = prev;
            prev = next;
            next = tmp;

            // ���� �� ������Ʈ�� pivot����ŭ ���������� �̵��Ͽ� �������� ���� ���� �� �ְ� ����
            next.transform.position = prev.transform.position + Vector3.right * pivot;
            // �̵��Ÿ� �ʱ�ȭ
            count = 0;
        }
    }
}
