using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;
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
            _camera.orthographicSize -= 250;
        }
    }

    public void ZoomOut()
    {
        if (currentZoomLevel < 5)
        {
            currentZoomLevel++;
            _camera.orthographicSize += 250;
        }
    }

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

    void LeftMouseDrag()
    {
        current_position.z = hit_position.z = camera_position.y;
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);
        direction = direction * -1;
        Vector3 position = camera_position + direction;
        transform.position = position;
    }
}