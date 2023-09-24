using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersionPrefab;

    public float destroyForce;

    private void OnCollisionEnter(Collision other)
    {
        float collisionForce = other.impulse.magnitude / Time.deltaTime;

        if (collisionForce > destroyForce)
        {
            Shatter();
        }
    }

    public void Shatter()
    {
        Instantiate(destroyedVersionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}