using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] int fruitsCollected;
    [SerializeField] int fruitsToCollect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Apple"))
        {
            fruitsCollected++;
            if(fruitsCollected >= fruitsToCollect)
            {
                //Victory!
            }
        }
    }
}