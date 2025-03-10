using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // 몬스터 프리팹 변수
    [SerializeField]
    MonsterControl monster;

    // 플레이어의 트럭 오브젝트
    [SerializeField]
    GameObject truck;

    // 몬스터 소환사이 간격시간
    [SerializeField]
    float term;
    // 몬스터 소환 수
    [SerializeField]
    int numOfMonster;
    // 플레이어로부터 얼마나 떨어진 곳에서 소환할지
    [SerializeField]
    float distance;

    // 몬스터 기어오르기 판단 확률값
    List<(bool result, float weight)> up_weight = new List<(bool, float)>();

    private void OnEnable()
    {
        // 몬스터 소환 코루틴 실행
        StartCoroutine(Spawn());
        // 기어오르기를 사용할 확률 60%
        up_weight.Add((true, 60f));
        up_weight.Add((false, 40f));
    }

    // 트럭의 Transform 가져올 함수
    public Transform GetTruck()
    {
        return truck.transform;
    }

    // 기어오르기 판단 함수
    public bool GetUpOk()
    {
        // 확률리스트의 전체 확률값을 더한 총 가중치를 계산
        float total_weight = 0;
        for (int i = 0; i < up_weight.Count; i++)
        {
            total_weight += up_weight[i].weight;
        }

        // 0 ~ 총 가중치 사이의 랜덤값 생성
        float random_value = Random.value * total_weight;
        // 리스트 내의 가중치들을 빼주면서 랜덤값이 해당하는 항목을 찾기
        for (int i = 0; i < up_weight.Count; i++)
        {
            random_value -= up_weight[i].weight;
            if(random_value <= 0)
            {
                return up_weight[i].result;
            }
        }

        // 위에서 못찾았으면 첫번째 값 리턴
        return up_weight[0].result;
    }

    // 몬스터 소환 코루틴
    IEnumerator Spawn()
    {
        // 소환 수 만큼 반복
        for (int i = 0; i < numOfMonster; i++)
        {
            // 몬스터 생성
            MonsterControl newMonster = Instantiate(monster, transform);
            // 지정한 거리만큼 떨어져서 소환
            Vector3 _pos = newMonster.transform.position;
            _pos += Vector3.right * distance;
            newMonster.transform.position = _pos;
            // MonsterManager 연동
            newMonster.SetMonsterManager(this);
            // 몬스터 오브젝트 활성화
            newMonster.gameObject.SetActive(true);

            // 소환 대기시간만큼 대기
            yield return new WaitForSeconds(term);
        }
    }
}
