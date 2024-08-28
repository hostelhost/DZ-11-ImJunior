using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.Separation += CreateCubes;
    }

    private void OnDisable()
    {
        _cube.Separation -= CreateCubes;
    }

    private void CreateCubes(Cube cube)
    {
        Cube newCube;
        int minimumNumberObjects = 2;
        int maximumNumberObjects = 6;
        int creatingObjects = UnityEngine.Random.Range(minimumNumberObjects, ++maximumNumberObjects);

        for (int i = 0; i < creatingObjects; i++)
        {
            newCube = Instantiate(cube, transform.position, Quaternion.identity);
            newCube.Separation += CreateCubes;
            newCube.MitigateImpact();
        }
    }
}
