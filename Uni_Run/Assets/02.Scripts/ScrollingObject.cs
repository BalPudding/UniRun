using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; //�̵��ӵ�
    private Transform posit;
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        }
}
