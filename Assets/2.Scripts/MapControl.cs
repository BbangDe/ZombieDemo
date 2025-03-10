using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    // 현재 밟고 있는 맵 오브젝트
    [SerializeField]
    GameObject prev;

    // 다음에 등장할 맵 오브젝트
    [SerializeField]
    GameObject next;

    // 맵 이동 스피드
    [SerializeField]
    float speed;

    // 맵 오브젝트같의 거리 차이
    [SerializeField]
    float pivot;

    // 현재 이동 거리 측정
    float count;

    // 이동거리 0으로 초기화
    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        // 2개의 맵 오브젝트를 이동속도에 따라 이동
        prev.transform.position += Vector3.left * speed * Time.deltaTime;
        next.transform.position += Vector3.left * speed * Time.deltaTime;
        // 이동거리 같이 업데이트
        count += speed * Time.deltaTime;

        // 맵 오브젝트 간의 거리 이상으로 이동했을 경우
        if(count >= pivot)
        {
            // 현 맵 오브젝트, 다음 맵 오브젝트를 서로 교환하고
            GameObject tmp = prev;
            prev = next;
            next = tmp;

            // 다음 맵 오브젝트를 pivot값만큼 오른쪽으로 이동하여 다음에도 맵이 나올 수 있게 세팅
            next.transform.position = prev.transform.position + Vector3.right * pivot;
            // 이동거리 초기화
            count = 0;
        }
    }
}
