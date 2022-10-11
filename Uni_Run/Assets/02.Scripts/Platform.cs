using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //�������μ� �ʿ��� ������ ���� ��ũ��Ʈ
    public GameObject[] obsatacle;//��ֹ� ������Ʈ
    private bool stepped = false;//�÷��̾� ĳ���Ͱ� ��Ҵ°�

    //������Ʈ�� Ȱ��ȭ�� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //������ �����ϴ� ó��
        stepped = false;

        //��ֹ��� ����ŭ ����
        //for (int i = 0; i < obsatacle.Length; i++)
        //{
        //    //���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
        //    if (random.range(0, 3) == 0)
        //    {
        //        obsatacle[i].setactive(true);
        //    }
        //    else
        //    {
        //        obsatacle[i].setactive(false);
        //    }
        //}

        foreach(GameObject a in obsatacle)
        {
            a.SetActive(Random.Range(0, 3) == 0 ? true : false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
        //�浹�� ������ �±װ� Player�̰� ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        if(collision.collider.tag == "Player" && !stepped)
        {
            //������ �߰��ϰ� ���� ���¸� ������ ����
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
