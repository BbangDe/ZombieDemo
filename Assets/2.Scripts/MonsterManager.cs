using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // ���� ������ ����
    [SerializeField]
    MonsterControl monster;

    // �÷��̾��� Ʈ�� ������Ʈ
    [SerializeField]
    GameObject truck;

    // ���� ��ȯ���� ���ݽð�
    [SerializeField]
    float term;
    // ���� ��ȯ ��
    [SerializeField]
    int numOfMonster;
    // �÷��̾�κ��� �󸶳� ������ ������ ��ȯ����
    [SerializeField]
    float distance;

    // ���� �������� �Ǵ� Ȯ����
    List<(bool result, float weight)> up_weight = new List<(bool, float)>();

    private void OnEnable()
    {
        // ���� ��ȯ �ڷ�ƾ ����
        StartCoroutine(Spawn());
        // �������⸦ ����� Ȯ�� 60%
        up_weight.Add((true, 60f));
        up_weight.Add((false, 40f));
    }

    // Ʈ���� Transform ������ �Լ�
    public Transform GetTruck()
    {
        return truck.transform;
    }

    // �������� �Ǵ� �Լ�
    public bool GetUpOk()
    {
        // Ȯ������Ʈ�� ��ü Ȯ������ ���� �� ����ġ�� ���
        float total_weight = 0;
        for (int i = 0; i < up_weight.Count; i++)
        {
            total_weight += up_weight[i].weight;
        }

        // 0 ~ �� ����ġ ������ ������ ����
        float random_value = Random.value * total_weight;
        // ����Ʈ ���� ����ġ���� ���ָ鼭 �������� �ش��ϴ� �׸��� ã��
        for (int i = 0; i < up_weight.Count; i++)
        {
            random_value -= up_weight[i].weight;
            if(random_value <= 0)
            {
                return up_weight[i].result;
            }
        }

        // ������ ��ã������ ù��° �� ����
        return up_weight[0].result;
    }

    // ���� ��ȯ �ڷ�ƾ
    IEnumerator Spawn()
    {
        // ��ȯ �� ��ŭ �ݺ�
        for (int i = 0; i < numOfMonster; i++)
        {
            // ���� ����
            MonsterControl newMonster = Instantiate(monster, transform);
            // ������ �Ÿ���ŭ �������� ��ȯ
            Vector3 _pos = newMonster.transform.position;
            _pos += Vector3.right * distance;
            newMonster.transform.position = _pos;
            // MonsterManager ����
            newMonster.SetMonsterManager(this);
            // ���� ������Ʈ Ȱ��ȭ
            newMonster.gameObject.SetActive(true);

            // ��ȯ ���ð���ŭ ���
            yield return new WaitForSeconds(term);
        }
    }
}
