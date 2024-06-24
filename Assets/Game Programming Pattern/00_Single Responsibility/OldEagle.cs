using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OldEagle : MonoBehaviour
{
    // ��� �ϱ�

    bool hunt;

    [SerializeField]
    GameObject fly;

    [SerializeField]
    GameObject pickFish;

    [SerializeField]
    GameObject pickRice;

    [SerializeField]
    GameObject Effect;

    // ���⼭���� ���������

    [Header("�߰���")] // � ����Ʈ 
    [SerializeField]
    Transform middlePoint;

    [Header("������")] // � ����Ʈ
    [SerializeField]
    Transform endPoint;

    [Header("�̵� ���ǵ�")]
    [SerializeField]
    float speed = 0.15f;

    Vector2[] point = new Vector2[4]; // ������, �߰�����Ʈ, �����, ����

    float currentTime;

    Vector3 targetPo;   // �����ġ, � ����Ʈ

    private void Awake()
    {
        // �Ʒ� ���� ������ ����
        point[0] = transform.position;  // � ������
        point[3] = endPoint.position;   // � ����
    }

    private void OnEnable()
    {
        transform.position = point[0];
        Init(); // �ʱ�ȭ
    }

    void Init()
    {
        currentTime = 0;

        if (transform.name.Contains("1"))   // ���� �� ����Ұ���
        {
            FindHuntObjectByTag("GoodEat", 1);  // Ÿ�� ���ϰ�
            point[1] = new Vector3(targetPo.x, targetPo.y - 300);
            point[2] = middlePoint.position;
        }
        else                  // ������ ���
        {
            FindHuntObjectByTag("GoodEat", 2);  // Ÿ�� ���ϰ�
            point[2] = targetPo;
            point[1] = middlePoint.position;
        }
    }

    private void Update()
    {
        if (currentTime > 1) return;    // � �̵��� ���θ� ������ �̾ 0~1 ���̸� �����̴� ���� = 1�� ���� ������

        currentTime = currentTime + Time.deltaTime * speed;
        Move();

        /*
        if(Mathf.Abs(transform.position.x - targetPo.x) < 50)
        {
            huntPower.enabled = true;
        }
        */
    }

    void Move()
    {
        transform.position = new Vector2(
            BezierPoint(point[0].x, point[1].x, point[2].x, point[3].x),
            BezierPoint(point[0].y, point[1].y, point[2].y, point[3].y)
            );
    }

    float BezierPoint(float a, float b, float c, float d)   // � ����Ʈ ��� �뵵, ���� ��
    {
        return Mathf.Pow((1 - currentTime), 3) * a
            + Mathf.Pow((1 - currentTime), 2) * 3 * currentTime * b
            + Mathf.Pow(currentTime, 2) * 3 * (1 - currentTime) * c
            + Mathf.Pow(currentTime, 3) * d;
    }


    private void FindHuntObjectByTag(string tag, int num)    // ��ɰ� ã��
    {
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();  // Ư�� �±� ������Ʈ ���� ����Ʈ�� ����


        var neareastObject = objects    // �������� ����
            .OrderBy(obj =>
            {
                return Mathf.Abs(transform.position.x - obj.transform.position.x);  // ���� Ȯ��
            });

        if (num == 1)   // ���� ���ʲ� ����� ����
        {
            foreach (GameObject targetObject in neareastObject)
            {
                if ((transform.position.y - targetObject.transform.position.y > 400) && targetObject.transform.position.x < 0)    // ������ ���� �ְ� ���ʲ���
                {
                    targetPo = targetObject.transform.position;  // Ÿ������ ��ƶ�
                    break;
                }
            }
        }
        else
        {
            foreach (GameObject targetObject in neareastObject)
            {
                if ((transform.position.y - targetObject.transform.position.y > 400) && targetObject.transform.position.x > 0)    // ������ ���� �ְ� �����ʲ���
                {
                    targetPo = targetObject.transform.position;  // Ÿ������ ��ƶ�
                    break;
                }
            }
        }
    }

    private void OnDisable()
    {
        hunt = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���̳� ������ε�, ������ �Ʒ��� �ְ� ������ �����
        if (other.transform.name.Contains("Good") && Mathf.Abs(transform.position.y - other.transform.position.y) < 100 && Mathf.Abs(transform.position.x - other.transform.position.x) < 200)
        {
            if (!hunt)
            {
                hunt = true;
                //other.transform.GetComponent<TargetObject>().HP--;
                Instantiate(Effect, transform.position, Quaternion.identity); // ���� ��ġ�� ��ƼŬ ����

                fly.SetActive(false);

                if (other.transform.name.Contains("Fish"))
                {
                    pickFish.SetActive(true);
                }
                else if (other.transform.name.Contains("Rice"))
                {
                    pickRice.SetActive(true);
                }
            }
        }

    }

}