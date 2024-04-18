using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public int cubesPerAxis = 8;
    public float force = 300f;
    public float radius = 2f;

    private Rigidbody objectToExplodeRigidbody;

    void Start()
    {
        objectToExplodeRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ExplodeCubes();
        }
    }

    public void ExplodeCubes()
    {
        if (objectToExplodeRigidbody == null)
        {
            Debug.LogError("Nenhum objeto para explodir atribuído ou Rigidbody não encontrado!");
            return;
        }

        Debug.Log("Exploding!");

        int fraction = 2;
        for (int x = 0; x < cubesPerAxis; x += fraction)
        {
            for (int y = 0; y < cubesPerAxis; y += fraction)
            {
                for (int z = 0; z < cubesPerAxis; z += fraction)
                {
                    CreateCube(new Vector3(x, y, z), transform.position);
                }
            }
        }

    }

    void CreateCube(Vector3 coordinates, Vector3 explosionCenter)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;
        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();

        rb.AddExplosionForce(force, explosionCenter, radius);
    }
}
