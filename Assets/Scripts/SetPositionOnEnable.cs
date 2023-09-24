using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionOnEnable : MonoBehaviour
{
    public Transform targetPosition;

    private void OnEnable()
    {
        transform.position = targetPosition.position;
        transform.rotation = targetPosition.rotation;
    }
}
