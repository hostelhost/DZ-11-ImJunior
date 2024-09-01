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
        ReduceImpact();
        Debug.Log(_separationProbability);
    }

    private void OnMouseUpAsButton()
    {
        if (IsProbable(_separationProbability))
            Separation?.Invoke(this);

        Destroy(this.gameObject);
    }

    private void ReduceImpact()
    {
        _separationProbability /= _decreaseNumber;
        transform.localScale /= _decreaseNumber;
    }

    private bool IsProbable(int separationProbability)
    {
        int minimum = 1;
        int maximum = 100;
        return UnityEngine.Random.Range(minimum, ++maximum) <= separationProbability;
    }

    private void SetRandomColor() =>
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();

}
