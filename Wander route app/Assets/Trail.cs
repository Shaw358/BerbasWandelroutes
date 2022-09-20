using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float speed;
    [SerializeField] GameObject particleSystem;
    int currWaypoint;

    bool playing;

    void Update()
    {
        if(!playing)
        {
            return;
        }

        if(Vector3.Distance(particleSystem.transform.position, waypoints[currWaypoint].position) < 30)
        {
            currWaypoint++;
        }

        if(currWaypoint == waypoints.Count)
        {
            playing = false;
            particleSystem.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            particleSystem.transform.LookAt(waypoints[currWaypoint]);
            particleSystem.transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    public void EnableTrail()
    {
        particleSystem.SetActive(true);
        particleSystem.GetComponent<ParticleSystem>().Play();
        currWaypoint = 0;
        playing = true;
    }
}