using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    Cube cube;
    private void Awake()
    {
        cube = GetComponent<Cube>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Cube otherCube = collision.gameObject.GetComponent<Cube>();
         // check if contacted with other cube
         if (otherCube != null && cube.CubeID>otherCube.CubeID) 
        { 
            // check if both cube are the same
            if (cube.CubeNumber == otherCube.CubeNumber)
            {
                Vector3 contactpoint = collision.contacts[0].point;
                // check if cubes number less than max number in cuvespawner
                if (otherCube.CubeNumber < CubeSpawner.Instance.maxCubeNumber)
                {
                    Cube newCube = CubeSpawner.Instance.Spawn(cube.CubeNumber * 2, contactpoint + Vector3.up * 1.6f);
                    float pushForce = 2.5f;
                    newCube.CubeRigidBody.AddForce(new Vector3(0, 0.3f, 1f) * pushForce,ForceMode.Impulse);

                    // add some torque
                    float randomValue = Random.Range(-20f, 20f);
                    Vector3 randomDirection = Vector3.one * randomValue;
                    newCube.CubeRigidBody.AddTorque(randomDirection);
                }
                // the explosion should affect surrounded cubes too!
                Collider[] surroundedCubes = Physics.OverlapSphere(contactpoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach (Collider coll in surroundedCubes)
                {
                    if (coll.attachedRigidbody != null)
                    {
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactpoint, explosionRadius);
                    }
                }
                // TODO: Explosion FX 

                FX.Instance.PlayCubeExplosionFX(contactpoint, cube.CubeColor);
                // destroy two cubes
                CubeSpawner.Instance.DestroyCube(cube);
                CubeSpawner.Instance.DestroyCube(otherCube);
                    
            }
        }
    }
}
