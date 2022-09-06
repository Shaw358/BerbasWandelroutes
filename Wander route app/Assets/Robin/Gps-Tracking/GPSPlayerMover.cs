using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GPSPlayerMover : MonoBehaviour
{
    [SerializeField] Vector2 topLeft;
    [SerializeField] Vector2 topRight;
    [SerializeField] Vector2 bottomLeft;
    [SerializeField] Vector2 bottomRight;

    [SerializeField] double lengthOfMap = 52.16373 - 52.1639;
    [SerializeField] double heightOfMap = 5.961646388030587 - 5.9351892900643675;

    public bool isUpdating;

    public TextMeshProUGUI test;

    IEnumerator Start()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            yield break;

        // Starts the location service.
        Input.location.Start();

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            isUpdating = true;
        }

        if (isUpdating)
        {
            while (true)
            {
                test.text = Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
                yield return new WaitForSeconds(2.5f);
            }
        }
    }

    private void DoMagicCalculations()
    {
        float currentX = Mathf.InverseLerp(topLeft.x, topRight.x, Input.location.lastData.latitude);
        float currentY = Mathf.InverseLerp(topLeft.y, bottomLeft.y, Input.location.lastData.longitude);
    }
}