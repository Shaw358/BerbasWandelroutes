using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using TMPro;

public class GPSLocation : MonoBehaviour
{
    public TextMeshProUGUI GPSOut;
    public bool isUpdating;
    private void Update()
    {
        if (!isUpdating)
        {
            StartCoroutine(GetLocation());
            isUpdating = !isUpdating;
        }
    }

    IEnumerator GetLocation()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation)) 
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        if (!Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(3);
        }

        Input.location.Start();

        int maxWait = 3;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            GPSOut.text = "Timed Out";
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSOut.text = "Unable to determine device location";
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            GPSOut.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
                print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
        }

        isUpdating = !isUpdating;
        Input.location.Stop();
    }
}
