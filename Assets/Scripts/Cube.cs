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
        //подписка на событие клик по кубу
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy() //тут реализовать эффект раскидывания ранее созданых кубор
    {
        
    }

    private void Click(bool isSeparation)
    {
        if (isSeparation)
        {
            //создать от 2 до 6 кубов
            //Передаем в них нашу вероятность деления деленую на 2 и наш sale деленый на 2
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
