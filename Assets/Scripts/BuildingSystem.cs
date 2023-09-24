using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.XR.Interaction.Toolkit;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase whiteTile;
    [SerializeField] private XRRayInteractor buildRay;

    public GameObject prefab1, prefab2;

    private PlaceableObject objectToPlace;

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Debug.Log("Coordinates on the ground: " + XRRayHitCoordinate(buildRay));
    }

    public Vector3 XRRayHitCoordinate(XRRayInteractor xrRay)
    {
        RaycastHit rayHit;
        if (xrRay.TryGetCurrent3DRaycastHit(out rayHit))
        {
            return rayHit.point; // the coordinate that the ray hits
        }
        else
        {
            return Vector3.zero;
        }
    }
}
