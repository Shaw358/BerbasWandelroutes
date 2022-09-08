using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    int currentZoomLevel;

    private void Start()
    {
        currentZoomLevel = 0;
    }

    public void ZoomIn()
    {
        if(currentZoomLevel > 0)
        {
            currentZoomLevel--;
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y - 250, transform.position.z);
        }
    }

    public void ZoomOut()
    {
        if (currentZoomLevel < 2)
        {
            currentZoomLevel++;
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y + 250, transform.position.z);
        }
    }
}