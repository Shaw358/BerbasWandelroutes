using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotation : MonoBehaviour
{

    private bool startTracking = false;

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        StartCoroutine(InitializeCompass());
    }

    void Update()
    {
        if (startTracking)
        {
            transform.rotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
        }
    }

    IEnumerator InitializeCompass()
    {
        yield return new WaitForSeconds(1f);
        startTracking |= Input.compass.enabled;
    }
}
