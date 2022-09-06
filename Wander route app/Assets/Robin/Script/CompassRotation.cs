using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class CompassRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        //Roteer de compas op de Y angle richting de noordpool
        transform.rotation = Quaternion.Euler(0, 0, -Input.compass.trueHeading);    
    }
}
