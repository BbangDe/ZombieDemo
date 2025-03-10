using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControl : MonoBehaviour
{
    // 바퀴 오브젝트
    [SerializeField]
    Transform backWheel_tf;
    [SerializeField]
    Transform frontWheel_tf;
    // 바퀴 회전 속도
    [SerializeField]
    float speed;

    // 현재 이동중인 상황인지
    bool isMoviong;

    private void Start()
    {
        // 본 데모에서는 계속 이동할 예정이므로 true로 고정
        isMoviong = true;
    }

    private void Update()
    {
        // 이동중인 상황이라면
        if(isMoviong)
        {
            // 바퀴를 지속적으로 회전
            backWheel_tf.Rotate(Vector3.back * speed * Time.deltaTime);
            frontWheel_tf.Rotate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
