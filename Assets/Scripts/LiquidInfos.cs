using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidInfos : MonoBehaviour
{
    public Material liquidMaterial;
    public float dropSize;

    public Color color;

    private void Start()
    {
        liquidMaterial = GetComponent<Renderer>().material;

        dropSize = gameObject.GetComponentInParent<Bottle>().dropSize_l;
    }
}
