using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    public int SeparationProbability { get; private set; }
    private int _decreaseNumber = 2;

    public event Action<Cube> Separation;

    private void OnMouseUpAsButton()
    {
        if (IsProbable(SeparationProbability))
            Separation?.Invoke(this);

        Destroy(this.gameObject);
    }

    public void Initialize(int separationProbability)
    {
        SeparationProbability = separationProbability;
        SetRandomColor();
        ReduceImpact();
        Debug.Log(SeparationProbability);
    }

    private void ReduceImpact()
    {
        SeparationProbability /= _decreaseNumber;
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
