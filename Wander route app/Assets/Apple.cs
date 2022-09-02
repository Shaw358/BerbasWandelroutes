using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}