using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using TMPro;

public class GPSLocation : MonoBehaviour
{
    public bool isUpdating;
    
    private Vector3 previouscoords;
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
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            transform.position = new Vector3(previouscoords.x - Input.location.lastData.latitude, 0, previouscoords.z - Input.location.lastData.longitude);

            previouscoords = new Vector3(Input.location.lastData.latitude, 0, Input.location.lastData.longitude);
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
            //Update Player Location with Gps location
            //Assign GPS locations to pinpionts 1 to 4
            //GPS BerBas = 52.16205567892675, 5.96111707115013
        }

        isUpdating = !isUpdating;
        Input.location.Stop();
    }
}
