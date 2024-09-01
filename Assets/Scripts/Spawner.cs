using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _explosiveForce = 10f;

    private void OnEnable() =>
        _cube.Separation += Initialize;

    private void OnDisable() =>
        _cube.Separation -= Initialize;
    
    private void Initialize(Cube cube)
    {
        CreateCubes(cube);
        BlowUp(cube.transform.position, cube.transform.localScale.x);
    }

    private void CreateCubes(Cube cube)
    {
        Cube newCube;
        int minimumNumberObjects = 2;
        int maximumNumberObjects = 6;
        int creatingObjects = UnityEngine.Random.Range(minimumNumberObjects, ++maximumNumberObjects);

        for (int i = 0; i < creatingObjects; i++)      
            newCube = Instantiate(cube, transform.position, Quaternion.identity);       
    }

    private void BlowUp(Vector3 explosionPosition, float radius)
    {
        foreach (Rigidbody rigidbody in GetNearRigidbodies(explosionPosition, radius))
            rigidbody.AddExplosionForce(_explosiveForce, explosionPosition, radius);
    }

    private List<Rigidbody> GetNearRigidbodies(Vector3 explosionPosition, float radius )
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        List<Rigidbody> rigidbodies = new();

        foreach (Collider collider in colliders)
            if (collider.attachedRigidbody != null)
                rigidbodies.Add(collider.attachedRigidbody);

        return rigidbodies;
    }

}
