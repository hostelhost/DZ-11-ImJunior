using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    public void BlowUp(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)        
            rigidbody.AddForce(RandomForce());        
    }

    private Vector3 RandomForce()
    {
        return new Vector3(RandomNumber(), RandomNumber(), RandomNumber());
    }

    private int RandomNumber()
    { 
        int minimum = 1;
        int maximum = 25;
        return Random.Range(minimum, ++maximum);
    }
}
