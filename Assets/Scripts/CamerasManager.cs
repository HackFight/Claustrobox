using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    [Header("Smooth First Person Camera")]
    public GameObject smoothFirstPersonCamera;

    [Header("External Camera")]
    public GameObject externalCameraCanvas;
    public GameObject externalCameraScreen;
    public Transform externalCameraHomePosition;

    private void Start()
    {
        externalCameraCanvas.SetActive(false);
        externalCameraScreen.SetActive(false);
        smoothFirstPersonCamera.SetActive(true);

        externalCameraScreen.transform.position = externalCameraHomePosition.position;
        externalCameraScreen.transform.rotation = externalCameraHomePosition.rotation;
    }

    public void ToggleExternalCamera()
    {
        smoothFirstPersonCamera.SetActive(externalCameraCanvas.activeSelf);
        externalCameraScreen.SetActive(!externalCameraCanvas.activeSelf);
        externalCameraCanvas.SetActive(!externalCameraCanvas.activeSelf);

        externalCameraScreen.transform.position = externalCameraHomePosition.position;
        externalCameraScreen.transform.rotation = externalCameraHomePosition.rotation;
    }
}