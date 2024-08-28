using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _separationProbability = 100;

    private void Start()
    {
        GetRandomColor();
    }

    private void OnEnable()
    {
        //�������� �� ������� ���� �� ����
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy() //��� ����������� ������ ������������ ����� �������� �����
    {
        
    }

    private void Click(bool isSeparation)
    {
        if (isSeparation)
        {
            //������� �� 2 �� 6 �����
            //�������� � ��� ���� ����������� ������� ������� �� 2 � ��� sale ������� �� 2
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private bool GetProbability(int separationProbability)
    {
        System.Random random = new System.Random();
        int maximum = 100;

        return random.Next(++maximum) <= separationProbability;
    }

    private void GetRandomColor()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
