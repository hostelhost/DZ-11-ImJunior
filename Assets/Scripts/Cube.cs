using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _separationProbability = 100;
    private int _decreaseNumber = 2;

    public event Action<Cube> Separation;

    private void Start()
    {
        SetRandomColor();
    }

    private void OnMouseUpAsButton()
    {
        OnClick(GetProbability(_separationProbability));
    }

    private void OnDestroy()
    {
        Separation = null;
    }

    public void MitigateImpact()
    {
        _separationProbability /= _decreaseNumber;
        transform.localScale /= _decreaseNumber;
    }

    private void OnClick(bool isSeparation)
    {
        if (isSeparation)
            Separation?.Invoke(this);
           
        Destroy(this.gameObject);   
    }

    private bool GetProbability(int separationProbability)
    {
        int minimum = 1;
        int maximum = 100;
        return UnityEngine.Random.Range(minimum, ++maximum) <= separationProbability;
    }

    private void SetRandomColor()
    {
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
    }
}
