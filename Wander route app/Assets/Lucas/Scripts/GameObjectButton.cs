using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectButton : MonoBehaviour
{
    [SerializeField] UnityEvent ev;
    bool canBeTriggered;

    private void OnMouseDown()
    {
        if (canBeTriggered)
        {
            ev?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBeTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canBeTriggered = false;
    }
}