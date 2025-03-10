using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControl : MonoBehaviour
{
    // ���� ������Ʈ
    [SerializeField]
    Transform backWheel_tf;
    [SerializeField]
    Transform frontWheel_tf;
    // ���� ȸ�� �ӵ�
    [SerializeField]
    float speed;

    // ���� �̵����� ��Ȳ����
    bool isMoviong;

    private void Start()
    {
        // �� ���𿡼��� ��� �̵��� �����̹Ƿ� true�� ����
        isMoviong = true;
    }

    private void Update()
    {
        // �̵����� ��Ȳ�̶��
        if(isMoviong)
        {
            // ������ ���������� ȸ��
            backWheel_tf.Rotate(Vector3.back * speed * Time.deltaTime);
            frontWheel_tf.Rotate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
