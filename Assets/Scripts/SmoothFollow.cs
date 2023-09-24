using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;

    [Range(0, 1)]
    public float positionDamping;
    [Range(0, 1)]
    public float rotationDamping;

    private void OnEnable()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, positionDamping);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping);
    }
}
