using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GPSLocation : MonoBehaviour
{

    public TextMeshProUGUI GPSStatus;
    public TextMeshProUGUI latitudeValue;
    public TextMeshProUGUI longitudeValue;
    public TextMeshProUGUI TimeStampValue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GPSLoc());
    }
    
    IEnumerator GPSLoc()
    {
        // check if user has location sevice enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        //start service before querying location
        Input.location.Start();

        //wait until service initailize
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        //service didn't init in 20 secs
        if (maxWait < 1)
        {
            GPSStatus.text = "Time Out";
            yield break;
        }
        //connection failed 
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            //Access granted
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            //Access granted to GPS values and it has been init
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            TimeStampValue.text = Input.location.lastData.timestamp.ToString();
        }
        else
        {
            //Service is stopped
        }
    }
}
